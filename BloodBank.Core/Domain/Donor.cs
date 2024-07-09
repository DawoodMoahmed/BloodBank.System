using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class Donor
    {
        public Donor()
        {

        }
        public Donor(string firstname,
            string lastname,
            Gender gender,
            DateTime dateOfBirth, 
            string address,
            DateTime? lastDonationDate,
            string  phoneNumber)
        {
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Address = address;
            LastDonationDate = lastDonationDate;
            PhoneNumber = phoneNumber;
        }

        public Guid DonorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public DateTime? LastDonationDate { get; private set; }
        public string PhoneNumber { get; private set; }


        public void Modify(string firstname,
          string lastname,
          Gender gender,
          DateTime dateOfBirth,
          string address,
          DateTime? lastDonationDate,
          string  phoneNumber)
        {
            FirstName = firstname;
            LastName = lastname;
            Gender = gender; 
            DateOfBirth = dateOfBirth;
            Address = address;
            LastDonationDate = lastDonationDate;
            PhoneNumber = phoneNumber;
        }
    }
}
