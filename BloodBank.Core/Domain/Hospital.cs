using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class Hospital
    {
        public Guid HospitalID { get; set; }
        public string HospitalName{ get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
