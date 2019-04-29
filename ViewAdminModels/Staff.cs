using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicConstruction.ViewModels;

namespace EpicConstruction.ViewAdminModels
{
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }          
        public string Department { get; set; }
        public string Voting { get; set; }
        public DateTime VotedDate { get; set; }

                
        public ICollection<Candidate> Candidates { get; set; }
       

    }
}