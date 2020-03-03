using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.Application.Contracts
{
    public interface IProductAppService
    {
        Task<BaseOutput<string>> GetProductById(long id);
        Task<BaseOutput<string>> GetProductByBarcode(string barcode);
        Task<BaseOutput<string>> CreateProduct(string product);
        Task<BaseOutput<string>> UpdateProduct(long id, string product);

    }
}
