using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class DamagedBlood
    { 

        public DamagedBlood()
        {

        }


        public DamagedBlood(
            Guid inventoryid, 
            Guid medicalTechniciansid,
            Guid quantity, 
            string theReason, 
            DateTime deletiondate)
        {
            InventoryId = inventoryid;
            MedicalTechniciansId = medicalTechniciansid;
            Quantity = quantity; 
            TheReason = theReason;
            DeletionDate = deletiondate; 
        }

        public Guid DamagedBloodId { get;private set; }
        public Guid InventoryId { get;private set; }
        public Guid MedicalTechniciansId { get;private set; }
        public Guid Quantity { get; private set; }
        public string TheReason { get;private set; }
        public DateTime DeletionDate { get;private set; }

        public void Modify(
            Guid inventoryid,
            Guid medicalTechniciansid,
            Guid quantity,
            string theReason,
            DateTime deletiondate)
        {
            InventoryId = inventoryid;
            MedicalTechniciansId = medicalTechniciansid;
            Quantity = quantity;
            TheReason = theReason;
            DeletionDate = deletiondate;

        }
    }
}
