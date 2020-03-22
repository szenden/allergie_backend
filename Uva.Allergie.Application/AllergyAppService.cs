using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Models;
using Uva.Allergie.Common.Models.Dto;
using Uva.Allergie.Data.Context;

namespace Uva.Allergie.Application
{
    public class AllergyAppService : IAllergyAppService
    {
        private readonly IAllergieDbContext _dbContext;
        public AllergyAppService(IAllergieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseOutput<object>> Get()
        {
            var allergiesEnt = await _dbContext.Allergies
                .Where(u => u.OriginalId != null).ToListAsync();
            var allergiesEntStr = JsonConvert.SerializeObject(allergiesEnt);
            var allergies = JsonConvert.DeserializeObject<List<AllergyDto>>(allergiesEntStr);

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "Allegies found",
                Payload = new AllergyAllDto { Allergies = allergies}
            };
        }

        public async Task<BaseOutput<object>> Get(int allergyId)
        {
            var allergyEnt = await _dbContext.Allergies
                .Where(u => u.AllergyId == allergyId).SingleOrDefaultAsync();

            if (allergyEnt == null)
            {
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "Allegy not found",
                    Payload = null
                };
            }

            var allergyStr = JsonConvert.SerializeObject(allergyEnt);
            var allergy = JsonConvert.DeserializeObject<AllergyDto>(allergyStr);

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "Allegy found",
                Payload = allergy
            };
        }
    }
}
