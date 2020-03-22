using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.Application.Contracts
{
    public interface IUserAppService
    {
        Task<BaseOutput<object>> GetUserByUid(string uid);

        Task<BaseOutput<object>> CreateUserProfile(UserInput input);
    }
}
