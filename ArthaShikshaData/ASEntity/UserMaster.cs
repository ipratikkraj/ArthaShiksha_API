using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaData.ASEntity
{
    public class UserMaster
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserCode { get; set; }

        public string MobileNo { get; set; }

        public string SecondaryMobileNo { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public int? GenderId { get; set; }

        public int? UserImageId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public DateTime? DateOfLeaving { get; set; }

        public int? ClientId { get; set; }

        public int? RoleId { get; set; }

        public int? BaseOSLevelId { get; set; }

        public int? BaseOSLevelEntityId { get; set; }

        public string Specialization { get; set; }

        public int? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

    }
}
