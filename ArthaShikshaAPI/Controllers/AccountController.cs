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
        [ProducesResponseType(typeof(APIMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIMessage), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PortalLogin([FromBody] PortalLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIMessage 
                { 
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    StatusMessage = "Invalid input",
                    Data = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                });
            }

            try
            {
                var result = await _accountService.PortalLogin(model);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login attempt for {EmailId}", model.EmailId);
                return StatusCode((int)HttpStatusCode.InternalServerError, new APIMessage
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    StatusMessage = "An unexpected error occurred",
                    Data = null
                });
            }
        }
    }
}