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
        public Task<BaseOutput<string>> CreateProduct(string product)
        {
            //1.serialize the product
            var productObj = JsonConvert.DeserializeObject<OpenFoodFactProductInfoDto>(product);
            //2.validate the if main fields are present

            //3.Save data to db
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
                RawJson = product
            };
            var 
            //4.Return the save data from db
            throw new NotImplementedException();
        }

        public Task<BaseOutput<string>> GetProductByBarcode(long id)
        {
            throw new NotImplementedException();
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
