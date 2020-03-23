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
using Uva.Allergie.Data.Entities;

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
            var allergies = JsonConvert.DeserializeObject<List<Allergy>>(allergiesEntStr);

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

        public async Task<BaseOutput<object>> GetUserAllergies(string uid)
        {
            var user = await _dbContext.Users
                .Where(u => u.UserUID == uid).SingleOrDefaultAsync();
            if(user == null)
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = $"User with uid = {uid} not found",
                    Payload = ""
                };

            var userAllergyEnt = await _dbContext.UserAllergies
                .Where(u => u.UserId == user.Id)
                .Select(u => u.AllergyId)
                .ToListAsync();

            var allergiesEnt = await _dbContext.Allergies
                .Where(u => u.OriginalId != null).ToListAsync();
            var allergiesEntStr = JsonConvert.SerializeObject(allergiesEnt);
            var allergies = JsonConvert.DeserializeObject<List<Allergy>>(allergiesEntStr);

            allergies.ForEach(u => {
                if (userAllergyEnt.Contains(u.AllergyId))
                    u.isChecked = true;
            });

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "Allegies found",
                Payload = allergies
            };
        }

        public async Task<BaseOutput<object>> UpdateUserAllergies(string uid, List<int> allergyIds)
        {
            var user = await _dbContext.Users
                .Where(u => u.UserUID == uid).SingleOrDefaultAsync();

            if (user == null)
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = $"User with uid = {uid} not found",
                    Payload = ""
                };
            //remove all first
            List<UserAllergyEntity> removeUserAllergyEntities = new List<UserAllergyEntity>();
            var existList = await _dbContext.UserAllergies
                .Where(u => u.UserId == user.Id)
                .ToListAsync();

            foreach (var notExist in existList)
            {
                if(!allergyIds.Contains(notExist.AllergyId))
                    removeUserAllergyEntities.Add(notExist);
            }
            _dbContext.UserAllergies.RemoveRange(removeUserAllergyEntities);
            await _dbContext.SaveChangesAsync();
            //add new ones
            List<UserAllergyEntity> userAllergyEntities = new List<UserAllergyEntity>();
            foreach (var id in allergyIds)
            {
                var exist = await _dbContext.UserAllergies
                    .Where(u => u.AllergyId == id && u.UserId == user.Id).SingleOrDefaultAsync();

                if(exist == null)
                    userAllergyEntities.Add(new UserAllergyEntity { 
                        UserId = user.Id,
                        AllergyId = id
                    });
            }
            _dbContext.UserAllergies.AddRange(userAllergyEntities);

            await _dbContext.SaveChangesAsync();

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "Allegies updated.",
                Payload = allergyIds
            };
        }
    }
}
