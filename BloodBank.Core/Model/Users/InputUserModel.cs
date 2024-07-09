using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Users
{
   public class InputUserModel
    {
        public Guid UserId { get; set; }
        public string UserName  { get; set; } 
        public string PassWord { get; set; }
        public DateTime DateOfBirt { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
    }
}
