using ArthaShikshaBusiness.Interface;
using ArthaShikshaBusinessModel.LoginModel;
using ArthaShikshaData.ASEntity;
using ArthaShikshaUtilities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.Extensions.Logging;

namespace ArthaShikshaBusiness.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly ASDBContext _dbContext;
        private readonly ILogger<AccountService> _logger;
        public AccountService(ASDBContext dbContext, ILogger<AccountService> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<APIMessage> PortalLogin(PortalLoginModel model)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(model);

                // Trim input
                model.EmailId = model.EmailId?.Trim();
                model.Password = model.Password?.Trim();

                if (string.IsNullOrEmpty(model.EmailId) || string.IsNullOrEmpty(model.Password))
                {
                    return new APIMessage
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        StatusMessage = "Email and password are required",
                        Data = null
                    };
                }

                var user = await (from um in _dbContext.UserMaster
                                join im in _dbContext.ImageMaster
                                    on um.UserImageId equals im.Id into imageGroup
                                from img in imageGroup.DefaultIfEmpty()
                                where um.IsActive == 1
                                    && um.EmailId == model.EmailId
                                    && um.Password == model.Password
                                select new
                                {
                                    UserId = um.Id,
                                    UserName = um.UserName,
                                    EmailId = um.EmailId,
                                    ClientId = um.ClientId,
                                    RoleId = um.RoleId,
                                    UserImageId = um.UserImageId,
                                    ImageURL = img.ImageURL
                                }).FirstOrDefaultAsync();

                if (user == null)
                {
                    _logger.LogWarning("Failed login attempt for user {EmailId}", model.EmailId);
                    return new APIMessage
                    {
                        StatusCode = (int)HttpStatusCode.Unauthorized,
                        StatusMessage = "Invalid email or password",
                        Data = null
                    };
                }

                _logger.LogInformation("Successful login for user {EmailId}", model.EmailId);
                return new APIMessage
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    StatusMessage = "Login successful",
                    Data = user
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user {EmailId}", model?.EmailId);
                return new APIMessage
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    StatusMessage = "An error occurred while processing your request",
                    Data = null
                };
            }
        }
    }
}