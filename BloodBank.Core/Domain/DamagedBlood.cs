using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class DamagedBlood
    {
        public Guid DamagedBloodID { get; set; }
        public Guid BloodID { get; set; }
        public Guid MedicalTechniciansID { get; set; }
        public string TheReason { get; set; }
        public  DateTime DateOfDestruction { get; set; }
    }
}
