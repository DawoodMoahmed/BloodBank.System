using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class Donor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public int  PhoneNumbe { get; set; }
        public string Address { get; set; }
    }
}
