using ArthaShikshaBusinessModel.LoginModel;
using ArthaShikshaUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaBusiness.Interface
{
    public interface IAcountService
    {
        Task<APIMessage> PortalLogin(PortalLoginModel model);
    }
}
