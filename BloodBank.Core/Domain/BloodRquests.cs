using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class BloodRquests
    {
        public BloodRquests()
        {

        }

        public BloodRquests(
            Guid patientsid,
            DateTime applicationDate,
            BloodType bloodType,
            Guid quantity,
            Guid hospitalid
            )
        {
            PatientsId = patientsid;
            ApplicationDate = applicationDate;
            BloodType = bloodType;
            Quantity = quantity;
            HospitalId = hospitalid;
            
        }

        public Guid BloodRquestsId { get;private set; }
        public Guid PatientsId { get;private set; }
        public Patient Patients { get; set; }
        public DateTime ApplicationDate { get;private set; }
        public BloodType BloodType { get;private set; }
        public Guid Quantity { get;private set; }
        public Guid HospitalId { get;private set; }
        public Hospital Hospital { get; set; }
        public bool IsReleased { get;private set; }

        public void ReleasedBload()
        {
            IsReleased = true;
        }


        public void Modify(
            Guid patientsid,
            DateTime theDateOfApplication,
            BloodType bloodType,
            Guid quantity,
            Guid hospitalid,
            bool isReleased)
        {
            PatientsId = patientsid;
            ApplicationDate = theDateOfApplication;
            BloodType = bloodType;
            Quantity = quantity;
            HospitalId = hospitalid;
            IsReleased = isReleased;
        }
    }
}
