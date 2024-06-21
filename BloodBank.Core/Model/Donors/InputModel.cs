using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Donors
{
    public class InputModel
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public BloodType BloodType { get;  set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public int PhoneNumber { get; set; }
    }
}
