using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class Donations
    {
        public Guid DonationsID  { get; set; }
        public Guid DonorID { get; set; }
        public Guid BloodID { get; set; }
        public DateTime DonationDate { get; set; }
        public Guid MedicalTechniciansID { get; set; }
    }
}
