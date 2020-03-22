using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Uva.Allergie.Application.Contracts;
using Uva.Allergie.Common.Models;

namespace Uva.Allergie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly AppSettingsOption _appSettings;
        private readonly IUserAppService _userAppService;
        public UserController(IOptionsSnapshot<AppSettingsOption> appSettings, ILogger logger,
            IUserAppService userAppService)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
            _userAppService = userAppService;
        }

        [HttpGet("getuserbyuid")]
        public async Task<ActionResult<BaseOutput<object>>> GetUserByUid(string uid)
        {
            //first check for user in db
            if (string.IsNullOrWhiteSpace(uid))
            {
                return BadRequest(new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "invalid request",
                    Payload = null
                });
            }
            var user = await _userAppService.GetUserByUid(uid);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<BaseOutput<object>>> Post([FromBody] UserInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "invalid payload.",
                    Payload = "failed"
                });
            }
            //first check for product in db
            var user = await _userAppService.CreateUserProfile(input);
            if (!user.IsSuccessful)
                return BadRequest(new BaseOutput<object>
                {
                    IsSuccessful = false,
                    Message = "failed to create user profile",
                    Payload = "failed"
                });

            return Ok(user);
        }
    }
}