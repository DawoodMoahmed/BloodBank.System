using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.MedicalTechnician
{
    public class InputMedicalTechnicianModel
    {
        public Guid MedicalTechniciansId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Qualification { get; set; }
        public DateTime YearsOfExperience { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
