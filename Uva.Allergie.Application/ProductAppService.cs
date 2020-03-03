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
        public async Task<BaseOutput<string>> CreateProduct(string product)
        {
            //1.serialize the product
            var productObj = JsonConvert.DeserializeObject<OpenFoodFactProductInfoDto>(product);
            if(productObj.status.Equals(0))
                return new BaseOutput<string>
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
            return new BaseOutput<string>
            {
                IsSuccessful = true,
                Message = "product created",
                Payload = JsonConvert.SerializeObject(newProductObj)
            };
        }

        public async Task<BaseOutput<string>> GetProductByBarcode(string barcode)
        {
            var product = await _dbContext.Products
                .Where(a => a.Barcode == barcode)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return new BaseOutput<string>
                {
                    IsSuccessful = false,
                    Message = $"product with barcode = {barcode} not found.",
                    Payload = ""
                };
            }

            return new BaseOutput<string>
            {
                IsSuccessful = true,
                Message = $"product with barcode = {barcode} found.",
                Payload = JsonConvert.SerializeObject(product)
            };
        }

        public Task<BaseOutput<string>> GetProductById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseOutput<string>> UpdateProduct(long id, string product)
        {
            throw new NotImplementedException();
        }
    }
}
