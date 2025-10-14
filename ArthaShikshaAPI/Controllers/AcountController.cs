using ArthaShikshaBusiness.Implemantation;
using ArthaShikshaBusiness.Interface;
using ArthaShikshaBusinessModel.LoginModel;
using ArthaShikshaUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArthaShikshaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountService _acountService;
        public AcountController(IAcountService acountService)
        {
            _acountService = acountService;
        }

        [HttpPost("PortalLogin")]
        public async Task<IActionResult> PortalLogin(PortalLoginModel model)
        {
            var result = await _acountService.PortalLogin(model);
            return result != null ? Ok(new APIMessage { StatusCode = (int)HttpStatusCode.OK, StatusMessage = Constants.SUCCESSMSG, Data = result })
                           : Ok(new APIMessage { StatusCode = Constants.FAILED_OPERATION, StatusMessage = Constants.FAILUREMSG, Data = false });
        }
       
    }
}
