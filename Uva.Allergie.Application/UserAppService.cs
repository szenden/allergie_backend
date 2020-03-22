using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Models;
using Uva.Allergie.Data.Context;
using Uva.Allergie.Data.Entities;

namespace Uva.Allergie.Application
{
    public class UserAppService : IUserAppService
    {
        private readonly IAllergieDbContext _dbContext;
        public UserAppService(IAllergieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<bool> UserExists(string provider, string uid)
        {
            var userExist = await _dbContext.Users
                .Where(u => u.Provider == provider && u.UserUID == uid)
                .SingleOrDefaultAsync();
            if (userExist == null)
                return false;

            return true;
        }

        public async Task<BaseOutput<object>> CreateUserProfile(UserInput input)
        {

            if (await UserExists(input.Provider, input.UserUID))
            {
                return await GetUserByUid(input.UserUID);
            }

            var inputStr = JsonConvert.SerializeObject(input);
            var userEntity = JsonConvert.DeserializeObject<UserEntity>(inputStr);

            _dbContext.Users.Add(userEntity);
            await _dbContext.SaveChangesAsync();

            var userId = userEntity.Id;
            if (input.AllergyIds.Any())
            {
                var listOfUserAllergyEntity = new List<UserAllergyEntity>();

                foreach (var id in input.AllergyIds)
                {
                    var userAllergy = new UserAllergyEntity
                    {
                        UserId = userId,
                        AllergyId = id
                    };
                    listOfUserAllergyEntity.Add(userAllergy);
                }

                _dbContext.UserAllergies.AddRange(listOfUserAllergyEntity);
                await _dbContext.SaveChangesAsync();
            }

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = "user created",
                Payload = userEntity
            };
        }

        public async Task<BaseOutput<object>> GetUserByUid(string uid)
        {
            var user = await _dbContext.Users
                .Where(u => u.UserUID == uid)
                .SingleOrDefaultAsync();

            if(user == null)
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "user not found",
                    Payload = null
                };

            return new BaseOutput<object>
            {
                IsSuccessful = true,
                Message = $"user with uid = {uid} was found.",
                Payload = user
            };
        }
    }
}
