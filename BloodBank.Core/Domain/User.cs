using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    class User
    {
        public Guid UserID { get; set; }
        public string Fname  { get; set; }
        public string Lname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
      
    }
}
