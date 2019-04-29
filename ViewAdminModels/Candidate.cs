using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpicConstruction.ViewAdminModels
{
    public class Candidate
    {
        public int ID { get; set; }
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Department { get; set; }
        public int Votes { get; set; }

        public Staff Staff { get; set; }
        

       

       

    }
}