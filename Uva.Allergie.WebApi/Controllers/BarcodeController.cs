using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
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

        public BarcodeController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IWebServiceInvoker webServiceInvoker)
        {
            _webServiceInvoker = webServiceInvoker;
            _appSettings = appSettings.Value;
            _logger = logger;
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

            var getProductInfo = await _webServiceInvoker.Get(_appSettings.Service.ProductApi);
            var resp = await getProductInfo.Content.ReadAsStringAsync();
            return new BaseOutput<string> { 
                IsSuccessful = true,
                Message = "Done",
                Payload = resp
            };
        }
    }
}