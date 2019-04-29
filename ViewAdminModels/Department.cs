using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicConstruction.ViewAdminModels
{
    public class Department
    {
        public int ID { get; set; }
        public string DeptName { get; set; }

        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}