using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
   public class Patient
    {

        public Patient()
        {

        }

        public Patient(
            string firstanme,
            string lastname,
            Gender gender,
            DateTime dateOfBirth,
            BloodType bloodtype,
            Guid quantity,
            string address,
            string phonenumber)
        {
            FirstName = firstanme;
            LastName = lastname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            BloodType = bloodtype;
            Quantity = quantity;
            Address = address;
            PhoneNumber = phonenumber;
        }


        public Guid Patientid { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public BloodType BloodType { get; private set; }
        public Guid Quantity { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

        public ICollection<BloodRquests> BloodRquests { get; set; } = new HashSet<BloodRquests>();


        public void Modify(
            string firstanme,
            string lastname,
            Gender gender,
            DateTime dateOfBirth,
            BloodType bloodtype,
            Guid quantity,
            string address,
            string phonenumber)
        {
            FirstName = firstanme;
            LastName = lastname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            BloodType = bloodtype;
            Quantity = quantity;
            Address = address;
            PhoneNumber = phonenumber;
        }
    }
}
