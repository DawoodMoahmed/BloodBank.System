using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class Distribution
    {
        public Distribution()
        {

        }

        public Distribution(
          Guid bloodrquestsid,
          Guid inventoryid,
          Guid medicalTechniciansid,
          Guid hospitalid,
          DateTime distributionDate,
          string condition)
        {
            BloodRquestsId = bloodrquestsid;
            InventoryId = inventoryid;
            MedicalTechniciansId = medicalTechniciansid;
            HospitalId = hospitalid;
            DistributionDate = distributionDate;
            Condition = condition;

        }
        

        public Guid DistributionId { get;private set; }
        public Guid BloodRquestsId { get; private set; }
        public Guid InventoryId { get;private set; }
        public Guid MedicalTechniciansId { get;private set; }
        public Guid HospitalId { get;private set; }
        public DateTime DistributionDate { get;private set; }
        public string Condition { get;private  set; }
        


        public void Modify(
          Guid bloodrquestsid, 
          Guid inventoryid,
          Guid medicalTechniciansid,
          Guid hospitalid,
          DateTime distributionDate,
          string condition)
        {
            BloodRquestsId = bloodrquestsid; 
            InventoryId = inventoryid;
            MedicalTechniciansId = medicalTechniciansid;
            HospitalId = hospitalid;
            DistributionDate = distributionDate;
            Condition = condition;

        }
    }
}
