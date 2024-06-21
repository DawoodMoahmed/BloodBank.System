using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class BloodRquests
    {
        public Guid BloodRquestsID  { get; set; }
        public Guid PatientsID { get; set; }
        public DateTime TheDateOfApplication { get; set; }
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }
        public Guid HospitalID { get; set; }
        public string condition { get; set; }
    }
}
