using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class Inventory
    {
        public Guid BloodID { get; set; }
        public BloodType BloodType { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
