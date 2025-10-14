using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaData.ASEntity
{
    public class ClientMaster
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string ClientCode { get; set; }

        public bool? IsGroup { get; set; }

        public int? GroupId { get; set; }

        public int? IndustryTypeId { get; set; }

        public int? LogoImageId { get; set; }

        public int? CountryId { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? TerminatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool? IsDeleted { get; set; }

    }

}
