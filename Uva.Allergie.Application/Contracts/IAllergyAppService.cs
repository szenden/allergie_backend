using System.Collections.Generic;
using System.Threading.Tasks;
using Uva.Allergie.Common.Models;
using Uva.Allergie.Common.Models.Dto;

namespace Uva.Allergie.Application.Contracts
{
    public interface IAllergyAppService
    {
        Task<BaseOutput<object>> Get();
        Task<BaseOutput<object>> Get(int allergyId);
        Task<BaseOutput<List<Allergy>>> GetUserAllergies(string uid);
        Task<BaseOutput<object>> UpdateUserAllergies(string uid, List<int> allergyIds);
    }
}
