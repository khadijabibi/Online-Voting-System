using EpicConstruction.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicConstruction.Models.Data
{
    public class DBModel : IdentityDbContext<ApplicationUser>
    {

        public DBModel()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static DBModel Create()
        {
            return new DBModel();
        }

        public System.Data.Entity.DbSet<EpicConstruction.ViewModels.LoginViewModel> LoginViewModels { get; set; }

        public System.Data.Entity.DbSet<EpicConstruction.ViewModels.RegisterViewModel> RegisterViewModels { get; set; }

        
    }



}