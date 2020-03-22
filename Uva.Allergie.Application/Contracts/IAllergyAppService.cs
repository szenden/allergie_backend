using System.Threading.Tasks;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.Application.Contracts
{
    public interface IAllergyAppService
    {
        Task<BaseOutput<object>> Get();
        Task<BaseOutput<object>> Get(int allergyId);
    }
}
