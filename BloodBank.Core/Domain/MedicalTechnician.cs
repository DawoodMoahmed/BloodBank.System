using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
   public class MedicalTechnician
    {
        public MedicalTechnician()
        {

        }

        public MedicalTechnician (
            string firstname, 
            string lastname, 
            DateTime dateOfBirth,
            Gender gender,
            string qualification, 
            DateTime yearsOfExperience, 
            string address, 
            string phonenumber)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Qualification = qualification; 
            YearsOfExperience = yearsOfExperience;
            Address = address;
            PhoneNumber = phonenumber; 

        } 

        public Guid MedicalTechniciansId { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public DateTime DateOfBirth { get;private set; }
        public Gender Gender { get;private set; }
        public string Qualification { get;private set; }
        public DateTime YearsOfExperience { get;private set; }
        public string Address  { get;private set; }
        public string  PhoneNumber  { get;private set; }



        public void Modify(
            string firstname,
            string lastname,
            DateTime dateOfBirth,
            Gender gender,
            string qualification,
            DateTime yearsOfExperience,
            string address,
            string phonenumber)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Qualification = qualification;
            YearsOfExperience = yearsOfExperience;
            Address = address;
            PhoneNumber = phonenumber;
        }

    }
}
