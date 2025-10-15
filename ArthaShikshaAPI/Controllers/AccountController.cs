using ArthaShikshaBusiness.Interface;
using ArthaShikshaBusinessModel.LoginModel;
using ArthaShikshaUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace ArthaShikshaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Authenticates a user for portal access
        /// </summary>
        [HttpPost("PortalLogin")]
        public async Task<IActionResult> PortalLogin([FromBody] PortalLoginModel model)
        {
            try
            {
                var result = await _accountService.PortalLogin(model);
                return result != null 
                    ? Ok(new APIMessage { 
                        StatusCode = (int)HttpStatusCode.OK, 
                        StatusMessage = Constants.SUCCESSMSG, 
                        Data = result 
                    })
                    : Ok(new APIMessage { 
                        StatusCode = Constants.FAILED_OPERATION, 
                        StatusMessage = Constants.FAILUREMSG, 
                        Data = false 
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in PortalLogin for user {EmailId}", model.EmailId);
                return Ok(new APIMessage { 
                    StatusCode = Constants.FAILED_OPERATION, 
                    StatusMessage = Constants.FAILUREMSG, 
                    Data = false 
                });
            }
        }
    }
}