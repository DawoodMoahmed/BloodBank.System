using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
    public class Donations
    {

        public Donations()
        {

        }

        public Donations(
            Guid donorid,
            BloodType bloodtype,
            DateTime donationDate,
            int quantity,
            Guid medicalTechniciansid)
        {
            DonorId = donorid;
            BloodType = bloodtype;
            DonationDate = donationDate;
            Quantity = quantity;
            MedicalTechniciansId = medicalTechniciansid;
        }

        public Guid DonationsId { get; private set; }
        public Guid DonorId { get; private set; }
        public BloodType BloodType { get; private set; } 
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }
        public Guid MedicalTechniciansId { get; private set; }

        public void Modify(
            Guid donorid,
            BloodType bloodtype,
            DateTime donationDate,
            Guid quantity,
            Guid medicalTechniciansid)
        {
            DonorId = donorid;
            BloodType = bloodtype;
            DonationDate = donationDate;
            Quantity = quantity;
            MedicalTechniciansId = medicalTechniciansid;
        }
    }
}