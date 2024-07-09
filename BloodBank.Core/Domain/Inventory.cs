using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class Inventoryn
    {
        public Inventoryn()
        {

        }

        public Inventoryn (
            Guid donationsid,
            Guid quantity,
            string locationstorage,
            DateTime storagedate,
            DateTime expirydate)
        {
            DonationsId = donationsid;
            Quantity = quantity;
            LocationStorage = locationstorage;
            StorageDate = storagedate;
            ExpiryDate = expirydate; 
        } 
        public Guid InventoryId { get;private set; }
        public Guid DonationsId { get; private set; }
        public Guid Quantity { get; private set; }
        public string LocationStorage { get; set; }
        public DateTime StorageDate { get;private set; }
        public DateTime ExpiryDate { get;private set; }


        public void Modify(
            Guid donationsid,
            Guid quantity,
            string locationstorage,
            DateTime storagedate,
            DateTime expirydate)
        {
            DonationsId = donationsid;
            Quantity = quantity;
            LocationStorage = locationstorage;
            StorageDate = storagedate;
            ExpiryDate = expirydate;
        }

    }
}
