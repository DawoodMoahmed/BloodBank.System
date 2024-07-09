using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class User
    {
        public User()
        {

        }
     
        public User(
            string username, 
            string password, 
            DateTime dateofbirt,
            int age, 
            Gender gender, 
            string address, 
            string  phonenumber, 
            string image)
        {
            UserName = username; 
            PassWord = password; 
            DateOfBirt = dateofbirt;
            Age = age;
            Gender = gender;
            Address = address; 
            PhoneNumber = phonenumber;
            Image = image; 
        }
        

        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string  PassWord { get;private set; }
        public DateTime DateOfBirt { get;private set; }
        public int Age { get;private set; }
        public Gender Gender { get;private set; }
        public string Address { get;private set; }
        public string  PhoneNumber { get;private set; }
        public string Image { get;private set; }


        public void Modify(
            string useranme, 
            string password,  
            DateTime dateofbirt,
            int age, 
            Gender gender, 
            string adderss, 
            string phonenumber, 
            string image)
        {
            UserName = useranme; 
            PassWord = password;
            DateOfBirt = dateofbirt;
            Age = age;
            Gender = gender;
            Address = adderss;
            PhoneNumber = phonenumber;
            Image = image; 
        }

    }

}
