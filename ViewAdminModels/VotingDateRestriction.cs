using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicConstruction.ViewAdminModels
{
    public class VotingDateRestriction
    {
        public int ID { get; set; }

        public DateTime StartVoting { get; set; }
        public DateTime EndVoting { get; set; }
    }
}