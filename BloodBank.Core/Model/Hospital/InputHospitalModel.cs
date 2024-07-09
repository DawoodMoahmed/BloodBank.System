using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Hospital
{
    public class InputHospitalModel
    {
        public Guid HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
