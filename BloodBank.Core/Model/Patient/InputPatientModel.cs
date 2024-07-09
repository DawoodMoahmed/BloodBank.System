using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Patient
{
   public class InputPatientModel
    {
        public Guid Patientid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get;set; }
        public BloodType BloodType { get; set; }
        public Guid Quantity { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
