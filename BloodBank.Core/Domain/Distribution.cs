using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class Distribution
    {
        public Guid DistributionID  { get; set; }
        public Guid BloodID { get; set; }
        public Guid MedicalTechniciansID { get; set; }
        public Guid HospitalID { get; set; }
        public DateTime DistributionDate { get; set; }
        public string condition { get; set; }
    }
}
