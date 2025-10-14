using ArthaShikshaBusiness.Interface;
using ArthaShikshaBusinessModel;
using ArthaShikshaData;
using ArthaShikshaData.ASEntity;
using ArthaShikshaUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaBusiness.Implemantation
{
    public class UserManagementService:IUserManagementSevice
    {
        private readonly ASDBContext _aSDBContext;
        public UserManagementService(ASDBContext aSDBContext)
        {
            _aSDBContext = aSDBContext;
        }
       

    }
}
