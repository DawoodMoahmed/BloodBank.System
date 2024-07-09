using BloodBank.Core.Domain;
using BloodBank.Core.Model.Donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
    public class DonationsApp
    {
        private readonly ApplicationContext appContext; 

        public DonationsApp(ApplicationContext appContext)
        {
            this.appContext = appContext; 
        }


        private (bool isValide, string message) Validate(InputDonationsModel model)
        {

            if (model.Quantity <= 0)
            {
                return (false, "يرجى أدخال الاسم الأول ");
            }
          
            return (true, "");

        }
        /////////////////////// Create /////////////////////// 
        public async Task<Result> CreateAsync(InputDonationsModel model)
        {

            var donor = await appContext.Donors.FindAsync(model.DonorId);

            if (donor is null)
            {
                return new Result().Fail("عذرا بم يتم عملية الأضافة");
            }

            var donations = new Donations(
                model.DonorId, 
                model.BloodType, 
                model.DonationDate, 
                model.Quantity, 
                model.MedicalTechniciansId);

            appContext.Donations.Add(donations);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا بم يتم عملية الأضافة");
            }

            return new Result().Success(donations, "تم الأضافة بنجاج"); 
        }

        /////////////////////// Update  /////////////////////// 

    }
}
