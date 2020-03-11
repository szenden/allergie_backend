using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Helpers;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodFactController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AppSettingsOption _appSettings;
        private readonly IWebServiceInvoker _webServiceInvoker;
        private readonly IFoodFactsAppService _foodFactsAppService;

        public FoodFactController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IWebServiceInvoker webServiceInvoker, IFoodFactsAppService foodFactsAppService)
        {
            _webServiceInvoker = webServiceInvoker;
            _appSettings = appSettings.Value;
            _logger = logger;
            _foodFactsAppService = foodFactsAppService;
        }

        [HttpGet("getaddictive/{parameter}")]
        public async Task<BaseOutput<string>> GetAddictive([FromRoute] string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                return new BaseOutput<string>
                {
                    IsSuccessful = false,
                    Message = "Error",
                    Payload = "test"
                };
            }
            //get all
            var url = $"{_appSettings.Service.ProductApi}/{parameter}.json";
            var getAddictive = await _webServiceInvoker.Get(url);
            var addictiveStr = await getAddictive.Content.ReadAsStringAsync();
            var savedAddictive = await _foodFactsAppService.CreateAddictived(addictiveStr);

            return savedAddictive;
        }

        [HttpGet("getallergen/{parameter}")]
        public async Task<BaseOutput<string>> GetAllergen([FromRoute] string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                return new BaseOutput<string>
                {
                    IsSuccessful = false,
                    Message = "Error",
                    Payload = "test"
                };
            }
            //get all
            var url = $"{_appSettings.Service.ProductApi}/{parameter}.json";
            var getAllergen = await _webServiceInvoker.Get(url);
            var allergenStr = await getAllergen.Content.ReadAsStringAsync();
            var savedAllergen = await _foodFactsAppService.CreateAllergens(allergenStr);

            return savedAllergen;
        }
    }
}