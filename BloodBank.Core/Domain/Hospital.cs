using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class Hospital
    {
        public Hospital()
        {

        }


        public Hospital(
            string hospitalname, 
            string address, 
            string phonenumber)
        {
            HospitalName = hospitalname; 
            Address = address;
            PhoneNumber = phonenumber;
        }

        public Guid HospitalId { get;private set; }
        public string HospitalName{ get;private set; }
        public string Address { get;private set; }
        public string PhoneNumber { get;private set; }

         
         
        public void Modify(
            string hosptalname,
            string address,
            string phonenumber)
        {
            HospitalName = hosptalname;
            Address = address;
            PhoneNumber = phonenumber;
        }

    }
}
    
