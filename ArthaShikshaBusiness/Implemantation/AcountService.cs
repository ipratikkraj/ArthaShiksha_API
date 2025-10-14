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
    public class AcountService:IAcountService
    {
        private readonly ASDBContext _aSDBContext;
        public AcountService(ASDBContext aSDBContext)
        {
            _aSDBContext = aSDBContext;
        }
        public async Task<APIMessage> PortalLogin(PortalLoginModel model)
        {
            try
            {
                // 1️⃣ Trim spaces like SQL LTRIM/RTRIM
                model. EmailId = model.EmailId?.Trim();
                model. password = model.password?.Trim();

                // 2️⃣ Check if user exists with EmailId and Password
                var user = await (from um in _aSDBContext.UserMaster
                                  join im in _aSDBContext.ImageMaster
                                      on um.UserImageId equals im.Id into imageGroup
                                  from img in imageGroup.DefaultIfEmpty()
                                  where um.IsActive == 1
                                        && um.EmailId == model.EmailId
                                        && um.Password == model. password
                                  select new
                                  {
                                      Message = "Successful",
                                      UserId = um.Id,
                                      UserName = um.UserName,
                                      EmailId = um.EmailId,
                                      ClientId = um.ClientId,
                                      RoleId = um.RoleId,
                                      UserImageId = um.UserImageId,
                                      ImageURL = img.ImageURL
                                  }).FirstOrDefaultAsync();

                // 3️⃣ Return appropriate response
                if (user != null)
                {
                    return new APIMessage
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        StatusMessage = "SUCCESS",
                        Data = user
                    };
                }
                else
                {
                    return new APIMessage
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        StatusMessage = "EmailId or Password is wrong",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIMessage
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    StatusMessage = "Internal server error",
                    Data = ex.ToString()
                };
            }
        }


    }
}
