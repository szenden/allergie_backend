using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Models;
using Uva.Allergie.Common.Models.Dto;
using Uva.Allergie.Data.Context;
using Uva.Allergie.Data.Entities;

namespace Uva.Allergie.Application
{
    public class ProductAppService : IProductAppService
    {
        private readonly IAllergieDbContext _dbContext;
        private readonly IAllergyAppService _allergyAppService;
        private readonly IUserAppService _userAppService;
        public ProductAppService(IAllergieDbContext dbContext, IAllergyAppService allergyAppService, IUserAppService userAppService)
        {
            _dbContext = dbContext;
            _allergyAppService = allergyAppService;
            _userAppService = userAppService;
        }
        public async Task<BaseOutput<object>> CreateProduct(string product)
        {
            //1.serialize the product
            var productObj = JsonConvert.DeserializeObject<OpenFoodFactProductInfoDto>(product);
            if(productObj.status.Equals(0))
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "product not found.",
                    Payload = product
                };
            //2.validate the if main fields are present

            //3.Save data to db
            //new product
            var newProductObj = new ProductEntity
            {
                OriginalId = productObj.product.id,
                Barcode = productObj.code,
                ProductName = productObj.product.product_name,
                Brands = productObj.product.brands,
                NutritionGrades = productObj.product.nutrition_grades,
                ImageUrl = productObj.product.image_url,
                Thumbnail = productObj.product.image_thumb_url,
                KeyWords = string.Join(",",productObj.product._keywords),
                NutrientLevels = JsonConvert.SerializeObject(productObj.product.nutrient_levels),
                Quantity = productObj.product.quantity,
                Creator = productObj.product.creator,
                Nutriments = JsonConvert.SerializeObject(productObj.product.nutriments),
                Categories = productObj.product.categories,
                IngredientText = productObj.product.ingredients_text,
                Additives = string.Join(",",productObj.product.additives_tags),
                Allergens = string.Join(",", productObj.product.allergens_tags),
                RawJson = product
            };
            _dbContext.Products.Add(newProductObj);
            await _dbContext.SaveChangesAsync();
            var productId = newProductObj.Id;
            //new ingredients
            var listOfIngredientEntity = new List<IngredientEntity>();
            foreach (var ingredient in productObj.product.ingredients)
            {
                var newIngredientObj = new IngredientEntity
                {
                    ProductId = productId,
                    Vegetarian = ingredient.vegetarian,
                    Vegan = ingredient.vegan,
                    Text = ingredient.text,
                    IngreId = ingredient.id,
                    Percent = ingredient.percent,
                    Rank = ingredient.rank,
                    HasSubIngredients = ingredient.has_sub_ingredients
                };

                listOfIngredientEntity.Add(newIngredientObj);
            }
            _dbContext.Ingredients.AddRange(listOfIngredientEntity);
            await _dbContext.SaveChangesAsync();
            //new allergy

            //4.Return the save data from db
            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "product created",
                Payload = newProductObj
            };
        }

        public async Task<BaseOutput<object>> GetProductByBarcode(string barcode)
        {
            var product = await _dbContext.Products
                .Where(a => a.Barcode == barcode)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = $"product with barcode = {barcode} not found.",
                    Payload = ""
                };
            }

            var productStr = JsonConvert.SerializeObject(product);
            var productInfo = new ProductOutput
            {
                ProductInfo = JsonConvert.DeserializeObject<ProductInfo>(productStr)
            };

            var ingredients = await _dbContext.Ingredients
                .Where(a => a.ProductId == product.Id)
                .ToListAsync();
            var ingredientsStr = JsonConvert.SerializeObject(ingredients);
            productInfo.Ingredients = JsonConvert.DeserializeObject<List<IngredientOutput>>(ingredientsStr);

            var additives = await _dbContext.Additives
                .Where(a => product.Additives.Contains(a.OriginalId))
                .ToListAsync();
            var additivesStr = JsonConvert.SerializeObject(additives);
            productInfo.Additives = JsonConvert.DeserializeObject<List<AdditiveOutput>>(additivesStr);

            var splitAllergens = product.Allergens.Split(new char[] { ',' });
            var allergens = await _dbContext.Allergies
                .Where(a => splitAllergens.Contains(a.OriginalId))
                .ToListAsync();

            var allergenStr = JsonConvert.SerializeObject(allergens);
            productInfo.Allergens = JsonConvert.DeserializeObject<List<AllergyOutput>>(allergenStr);

            var wikiAllergens = await _dbContext.WikiAllergies.ToListAsync();
            foreach (var wikiAllergy in wikiAllergens)
            {
                var selected = productInfo.Allergens.Where(a => a.Name.Contains(wikiAllergy.Name)).ToList();
                selected.ForEach(a =>
                {
                    a.PotentialReactions = wikiAllergy.PotentialReactions;
                    a.Remarks = wikiAllergy.Remarks;
                });
            }

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = $"product with barcode = {barcode} found.",
                Payload = productInfo
            };
        }

        public async Task<BaseOutput<object>> GetProductByBarcodeAndUserUid(string UserUid, string barcode)
        {
            var productInfo = await GetProductByBarcode(barcode);
            var productInfoStr = JsonConvert.SerializeObject(productInfo);
            var productInfoDes = JsonConvert.DeserializeObject<BaseOutput<ProductOutput>>(productInfoStr);

            if (!productInfo.IsSuccessful)
            {
                return new BaseOutput<object> { 
                    IsSuccessful = productInfo.IsSuccessful,
                    Message = productInfo.Message,
                    Payload = productInfo.Payload
                };
            }
            //var user = await _userAppService.GetUserByUid(UserUid);
            //if(!user.IsSuccessful)
            //    return new BaseOutput<object>
            //    {
            //        IsSuccessful = productInfo.IsSuccessful,
            //        Message = productInfo.Message,
            //        Payload = productInfo.Payload
            //    };
            //Todo: add user info

            var userAllergies = await _allergyAppService.GetUserAllergies(UserUid);
            if (!userAllergies.IsSuccessful)
                return new BaseOutput<object>
                {
                    IsSuccessful = productInfo.IsSuccessful,
                    Message = productInfo.Message,
                    Payload = productInfo.Payload
                };

            userAllergies.Payload.RemoveAll(u => !u.isChecked);

            productInfoDes.Payload.UserAllergens = new List<AllergyOutput>();
            productInfoDes.Payload.Allergens.ForEach(u =>
            {
                if (userAllergies.Payload.Any(a => a.AllergyId == u.AllergyId))
                {
                    productInfoDes.Payload.UserAllergens.Add(u);
                }
            });

            return new BaseOutput<object>
            {
                IsSuccessful = productInfoDes.IsSuccessful,
                Message = productInfoDes.Message,
                Payload = productInfoDes.Payload
            };
        }

        public Task<BaseOutput<object>> GetProductById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseOutput<bool>> ProductExists(string barcode)
        {
            var product = await _dbContext.Products
                .Where(a => a.Barcode == barcode)
                .FirstOrDefaultAsync();

            return new BaseOutput<bool>
            {
                IsSuccessful = (product == null) ? false : true,
                Message = $"product with barcode = {barcode} info.",
                Payload = (product == null) ? false : true
            };
        }

        public Task<BaseOutput<object>> UpdateProduct(long id, string product)
        {
            throw new NotImplementedException();
        }
    }
}
