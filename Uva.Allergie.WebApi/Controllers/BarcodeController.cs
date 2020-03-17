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
        private readonly IFoodFactsAppService _foodFactsAppService;

        public BarcodeController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IWebServiceInvoker webServiceInvoker, IProductAppService productAppService,
            IFoodFactsAppService foodFactsAppService)
        {
            _webServiceInvoker = webServiceInvoker;
            _appSettings = appSettings.Value;
            _logger = logger;
            _productAppService = productAppService;
            _foodFactsAppService = foodFactsAppService;
        }

        [HttpPost]
        public async Task<BaseOutput<object>> Post([FromBody] BarcodeInput input)
        {
            if (!ModelState.IsValid)
            {
                return new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "Error",
                    Payload = "test"
                };
            }
            //first check for product in db
            var getProduct = await _productAppService.GetProductByBarcode(input.Barcode);
            if (getProduct.IsSuccessful)
                return getProduct;

            //get product from openfood
            var url = $"{_appSettings.Service.ProductApi}/api/v0/product/{input.Barcode}.json";
            var getProductInfo = await _webServiceInvoker.Get(url);
            var productStr = await getProductInfo.Content.ReadAsStringAsync();
            var saveProduct = await _productAppService.CreateProduct(productStr);

            if (saveProduct.IsSuccessful)
            {
                getProduct = await _productAppService.GetProductByBarcode(input.Barcode);
                return getProduct;
            }

            return saveProduct;
        }

    }
}