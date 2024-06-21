using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class TestResults
    { 
        public Guid TestResultsID { get; set; }
        public Guid TestID { get; set; }
        public Guid BloodID { get; set; }
        public string Results { get; set; }
        public DateTime DateofAppearanceTest { get; set; }

    }
}
