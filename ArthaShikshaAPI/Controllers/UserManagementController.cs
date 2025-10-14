using ArthaShikshaBusiness.Interface;
using ArthaShikshaUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArthaShikshaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementSevice _userManagementSevice;
        public UserManagementController(IUserManagementSevice userManagementSevice)
        {
            _userManagementSevice = userManagementSevice;
        }

       
        
    }
}
