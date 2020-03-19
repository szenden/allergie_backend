using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class NewsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AppSettingsOption _appSettings;
        private readonly IWebServiceInvoker _webServiceInvoker;
        private readonly INewsAppService _newsAppService;

        public NewsController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IWebServiceInvoker webServiceInvoker, INewsAppService newsAppService)
        {
            _webServiceInvoker = webServiceInvoker;
            _appSettings = appSettings.Value;
            _logger = logger;
            _newsAppService = newsAppService;
        }

        [HttpPost]
        public async Task<BaseOutput<object>> Post([FromBody] NewsInput input)
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
            //get product from openfood
            var url = $"{_appSettings.Service.Newspi}/top-headlines?country={input.Country}&apiKey={_appSettings.ApiKeys.HealthNews}&category=health";
            var getNewsInfo = await _webServiceInvoker.Get(url);
            var newsStr = await getNewsInfo.Content.ReadAsStringAsync();
            var saveNews = await _newsAppService.CreateNews(newsStr);

            return saveNews;
        }

        [HttpGet]
        public async Task<BaseOutput<object>> Get(int page, int pageSize) 
        {
            if (page == 0)
                page = 1;
            if (pageSize == 0)
                pageSize = 10;
            //first check for product in db
            var getNews = await _newsAppService.GeNews(page, pageSize);
            return getNews;
        }

        [HttpGet("GetById")]
        public async Task<BaseOutput<object>> GetById(int id)
        {
            //first check for product in db
            var getNews = await _newsAppService.GeNewsById(id);
            return getNews;
        }
    }
}