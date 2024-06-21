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
        public Donor(string firstName, 
            string lastName, 
            BloodType bloodType, 
            DateTime dateOfBirth, 
            int age, 
            string address,
            Gender gender,
            DateTime? lastDonationDate,
            int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            BloodType = bloodType;
            DateOfBirth = dateOfBirth;
            Age = age;
            Address = address;
            Gender = gender;
            LastDonationDate = lastDonationDate;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get;private set; }
        public BloodType BloodType { get;private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime? LastDonationDate { get; private set; }
        public int  PhoneNumber { get; private set; }


        public void Modify(string firstName,
          string lastName,
          BloodType bloodType,
          DateTime dateOfBirth,
          int age,
          string address,
          Gender gender,
          DateTime? lastDonationDate,
          int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            BloodType = bloodType;
            DateOfBirth = dateOfBirth;
            Age = age;
            Address = address;
            Gender = gender;
            LastDonationDate = lastDonationDate;
            PhoneNumber = phoneNumber;
        }
    }
}
