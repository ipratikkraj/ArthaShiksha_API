using ArthaShikshaBusiness.Interface;
using ArthaShikshaBusinessModel;
using ArthaShikshaBusinessModel.LoginModel;
using ArthaShikshaData.ASEntity;
using ArthaShikshaUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaBusiness.Implemantation
{
    public class AcountService : IAccountService
    {
        private readonly ASDBContext _aSDBContext;
        public Task<APIMessage> PortalLogin(PortalLoginModel model)
        {
            // Implementation here
            throw new NotImplementedException();
        }
    }
               
}
