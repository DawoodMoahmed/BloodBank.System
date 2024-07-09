using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Donations
{
    public class InputDonationsModel
    {
        public Guid DonationsId { get; set; }
        public Guid DonorId { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime DonationDate { get; set; }
        public int Quantity { get; set; }
        public Guid MedicalTechniciansId { get; set; }

    }
}
