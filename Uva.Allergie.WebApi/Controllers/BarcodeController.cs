using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Helpers;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AppSettingsOption _appSettings;
        private readonly IWebServiceInvoker _webServiceInvoker;
        private readonly IProductAppService _productAppService;

        public BarcodeController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IWebServiceInvoker webServiceInvoker, IProductAppService productAppService)
        {
            _webServiceInvoker = webServiceInvoker;
            _appSettings = appSettings.Value;
            _logger = logger;
            _productAppService = productAppService;
        }

        [HttpPost]
        public async Task<BaseOutput<string>> Post([FromBody] BarcodeInput input)
        {
            if (!ModelState.IsValid)
            {
                return new BaseOutput<string>
                {
                    IsSuccessful = false,
                    Message = "Error",
                    Payload = "test"
                };
            }
            //first check for product in db
            var savedProduct = await _productAppService.GetProductByBarcode(input.Barcode.ToString());
            if(!savedProduct.IsSuccessful)
            {
                //get product from openfood
                var url = $"{_appSettings.Service.ProductApi}/{input.Barcode}.json";
                var getProductInfo = await _webServiceInvoker.Get(url);
                var productStr = await getProductInfo.Content.ReadAsStringAsync();
                savedProduct = await _productAppService.CreateProduct(productStr);
            }

            return savedProduct;
        }
    }
}