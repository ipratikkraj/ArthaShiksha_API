using ArthaShikshaBusinessModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaData.ASEntity
{
    public class ASDBContext : DbContext
    {
        public ASDBContext(DbContextOptions<ASDBContext> options) : base(options)
        {
        }
        public DbSet<LMS_ProgramWiseReportCenter> LMS_ProgramWiseReportCenter { get; set; }
        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<ClientMaster> ClientMaster { get; set; }
        public DbSet<ImageMaster> ImageMaster { get; set; }

    }
}
