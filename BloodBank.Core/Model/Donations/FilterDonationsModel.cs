using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Donations
{
    public class FilterDonationsModel
    {
        public Guid? DonorId { get; set; }
        public BloodType? BloodType { get; set; }
        public DateTime? DonationDate { get; set; }
    }
}