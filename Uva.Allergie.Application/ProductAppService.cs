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
        public ProductAppService(IAllergieDbContext dbContext)
        {
            _dbContext = dbContext;
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
            var productId = await _dbContext.SaveChangesAsync();
            //new ingredients
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

               _dbContext.Ingredients.Add(newIngredientObj);
            }
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

            var allergens = await _dbContext.Allergies
                .Where(a => product.Allergens.Contains(a.OriginalId))
                .ToListAsync();
            var allergenStr = JsonConvert.SerializeObject(allergens);
            productInfo.Allergens = JsonConvert.DeserializeObject<List<AllergyOutput>>(allergenStr);


            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = $"product with barcode = {barcode} found.",
                Payload = productInfo
            };
        }

        public Task<BaseOutput<object>> GetProductById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseOutput<object>> UpdateProduct(long id, string product)
        {
            throw new NotImplementedException();
        }
    }
}
