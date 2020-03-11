using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.Application.Contracts
{
    public interface IFoodFactsAppService
    {
        Task<BaseOutput<string>> CreateAddictived(string product);
        Task<BaseOutput<string>> CreateAllergens(string product);
    }
}
