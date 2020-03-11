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
    public class FoodFactAppService : IFoodFactsAppService
    {
        private readonly IAllergieDbContext _dbContext;
        public FoodFactAppService(IAllergieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseOutput<string>> CreateAddictived(string addictive)
        {
            try
            {
                //1.serialize the product
                var addictiveObj = JsonConvert.DeserializeObject<OpenFoodFactAddictiveDto>(addictive);

                foreach (var tag in addictiveObj.tags)
                {
                    var oldAddictive = _dbContext.Additives
                        .Where(a => a.OriginalId == tag.id).SingleOrDefault();

                    if (oldAddictive != null)
                    {
                        oldAddictive.Url = tag.url;
                        oldAddictive.Name = tag.name;
                        oldAddictive.OriginalId = tag.id;
                        oldAddictive.Products = tag.products;
                        oldAddictive.SameAs = (tag.sameAs != null) ? string.Join(",", tag.sameAs) : null;
                        _dbContext.Additives.Update(oldAddictive);
                    }
                    else
                    {
                        var newAddictive = new AdditiveEntity
                        {
                            Url = tag.url,
                            Name = tag.name,
                            OriginalId = tag.id,
                            Products = tag.products,
                            SameAs = (tag.sameAs != null) ? string.Join(",", tag.sameAs) : null
                        };

                        _dbContext.Additives.Add(newAddictive);
                    }

                }
                await _dbContext.SaveChangesAsync();

                //4.Return the save data from db
                return new BaseOutput<string>
                {
                    IsSuccessful = true,
                    Message = "addictives created",
                    Payload = JsonConvert.SerializeObject(addictiveObj)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BaseOutput<string>> CreateAllergens(string allergen)
        {
            //1.serialize the product
            var allergenObj = JsonConvert.DeserializeObject<OpenFoodFactAllergenDto>(allergen);

            foreach (var tag in allergenObj.tags)
            {
                var oldAllergen = _dbContext.Allergies
                    .Where(a => a.OriginalId == tag.id && a.Url == tag.url)
                    .SingleOrDefault();

                if(oldAllergen != null)
                {
                    oldAllergen.Url = tag.url;
                    oldAllergen.Name = tag.name;
                    oldAllergen.OriginalId = tag.id;
                    oldAllergen.Products = tag.products;
                    oldAllergen.SameAs = (tag.sameAs != null) ? string.Join(",", tag.sameAs) : null;
                    _dbContext.Allergies.Update(oldAllergen);
                }
                else
                {
                    var newAllergen = new AllergyEntity
                    {
                        Url = tag.url,
                        Name = tag.name,
                        OriginalId = tag.id,
                        Products = tag.products,
                        SameAs = (tag.sameAs != null) ? string.Join(",", tag.sameAs) : null
                    };
                    _dbContext.Allergies.Add(newAllergen);
                }
                    
            }
            await _dbContext.SaveChangesAsync();

            //4.Return the save data from db
            return new BaseOutput<string>
            {
                IsSuccessful = true,
                Message = "allergen created",
                Payload = JsonConvert.SerializeObject(allergenObj)
            };
        }

    }
}
