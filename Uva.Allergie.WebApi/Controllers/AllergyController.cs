using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AppSettingsOption _appSettings;
        private readonly IAllergyAppService _allergyAppService;
        public AllergyController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IAllergyAppService allergyAppService)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
            _allergyAppService = allergyAppService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<BaseOutput<object>>> Get()
        {
            var allergy = await _allergyAppService.Get();

            if (!allergy.IsSuccessful)
            {
                return BadRequest(allergy);
            }

            return Ok(allergy);
        }

        [HttpGet]
        public async Task<ActionResult<BaseOutput<object>>> Get(int id)
        {
            var allergy = await _allergyAppService.Get(id);

            if (!allergy.IsSuccessful)
            {
                return BadRequest(allergy);
            }
            
            return Ok(allergy);
        }

        [HttpGet("getuserallergies")]
        public async Task<ActionResult<BaseOutput<object>>> GetUserAllergies(string uid)
        {
            var allergy = await _allergyAppService.GetUserAllergies(uid);

            if (!allergy.IsSuccessful)
            {
                return BadRequest(allergy);
            }

            return Ok(allergy);
        }

        [HttpPost("updateuserallergies")]
        public async Task<ActionResult<BaseOutput<object>>> UpdateUserAllergies(string uid, [FromBody] List<int> Ids)
        {
            var allergy = await _allergyAppService.UpdateUserAllergies(uid, Ids);

            if (!allergy.IsSuccessful)
            {
                return BadRequest(allergy);
            }

            return Ok(allergy);
        }
    }
}