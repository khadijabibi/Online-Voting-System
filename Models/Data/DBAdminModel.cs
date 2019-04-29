using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicConstruction.Models.Data
{
    public class DBAdminModel : IdentityDbContext
    {

        public DBAdminModel()
            : base("AdminConnection")
        {

        }

        public static DBAdminModel Create()
        {
            return new DBAdminModel();
        }

        
        public System.Data.Entity.DbSet<EpicConstruction.ViewAdminModels.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<EpicConstruction.ViewAdminModels.Candidate> Candidates { get; set; }

        public System.Data.Entity.DbSet<EpicConstruction.ViewAdminModels.Help> Helps { get; set; }

        public System.Data.Entity.DbSet<EpicConstruction.ViewAdminModels.VotingDateRestriction> VotingDateRestrictions { get; set; }

        public System.Data.Entity.DbSet<EpicConstruction.ViewAdminModels.Department> Departments { get; set; }
        public IEnumerable LoginViewModels { get; internal set; }
    }

}
