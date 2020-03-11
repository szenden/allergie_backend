using System.Threading.Tasks;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.Application.Contracts
{
    public interface IProductAppService
    {
        Task<BaseOutput<object>> GetProductById(long id);
        Task<BaseOutput<object>> GetProductByBarcode(string barcode);
        Task<BaseOutput<object>> CreateProduct(string product);
        Task<BaseOutput<object>> UpdateProduct(long id, string product);

    }
}
