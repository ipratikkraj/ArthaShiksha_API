using ArthaShikshaBusinessModel.LoginModel;
using ArthaShikshaUtilities;

namespace ArthaShikshaBusiness.Interface
{
    public interface IAccountService
    {
        Task<APIMessage> PortalLogin(PortalLoginModel model);
    }
}