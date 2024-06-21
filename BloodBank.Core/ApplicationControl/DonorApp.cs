using BloodBank.Core.Domain;
using BloodBank.Core.Model.Donors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Application
{
    public class DonorApp
    {
        private readonly ApplictionContext appContext;

        public DonorApp(ApplictionContext appContext)
        {
            this.appContext = appContext;
        }
        private (bool isValide,string message) Validate(InputModel model)
        {
            
            if (string.IsNullOrEmpty(model.FirstName))
            {
                return (false, "يرجى ادخال الاسم");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                return (false, "يرجى ادخال الاسم");
            }
            return (true, "");
           
        }
        public async Task<Result> CreateAsync(InputModel model)
        {
            var validate = Validate(model);
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }

            var isNameExiesd = appContext.Donors.Any(i => 
            i.FirstName == model.FirstName && 
            i.LastName == model.LastName &&
            i.PhoneNumber == model.PhoneNumber);

            if (isNameExiesd)
            {
                return new Result().Fail("عذرا هذا المتبرع موجود مسبقا");

            }

            var donor = new Donor(
                model.FirstName,
                model.LastName,
                model.BloodType,
                model.DateOfBirth,
                model.Age,
                model.Address,
                model.Gender,
                model.LastDonationDate,
                model.PhoneNumber);

            appContext.Donors.Add(donor);
           var reslut =  await appContext.SaveChangesAsync();

            if (reslut ==0 )
            {
                return new Result().Fail( "عذرا لم يتم اضافة ");

            }
            return new Result().Success(donor, "تم أضافه بنجاح ");
            

        }

        public async Task<Result> UpdateAsync(Guid id, InputModel model)
        {
            var validate = Validate(model);
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }


            var isNameExiesd = appContext.Donors.Any(i =>
                                i.Id != id &&
                                i.FirstName == model.FirstName &&
                                i.LastName == model.LastName &&
                                i.PhoneNumber == model.PhoneNumber);

            if (isNameExiesd)
            {
                return new Result().Fail("عذرا هذا المتبرع موجود مسبقا");

            }
            var donor = await appContext.Donors.FindAsync(id);

            if (donor == null)
            {
                return new Result().Fail( "عذرا لم يتم العثور على المتبرع ");

            }

            donor.Modify(
                  model.FirstName,
                model.LastName,
                model.BloodType,
                model.DateOfBirth,
                model.Age,
                model.Address,
                model.Gender,
                model.LastDonationDate,
                model.PhoneNumber
                );

            appContext.Donors.Update(donor);
            var reslut = await appContext.SaveChangesAsync();

            if (reslut == 0)
            {
                return new Result().Fail( "عذرا لم يتم اضافة ");

            }
            return new Result().Success(donor, "تم أضافه بنجاح ");
        }

        public async Task<Result> FindAsync(Guid id)
        {
            var donor = await appContext.Donors.FindAsync(id);

            if (donor == null)
            {
                return new Result().Success(true, "عذرا لم يتم العثور على المتبرع ");

            }

            return new Result().Success(donor, "تم الحذف بنجاح  ");


        }

        public async Task<Result> DeleteAsync(Guid id)
        {
      
            var donor = await appContext.Donors.FindAsync(id);

            if (donor == null)
            {
                return new Result().Success(true, "عذرا لم يتم العثور على المتبرع ");

            }

            appContext.Donors.Remove(donor);
            var reslut = await appContext.SaveChangesAsync();

            if (reslut == 0)
            {
                return new Result().Success(true, "عذرا لم يتم العثور علي المتبرع  ");

            }
            return new Result().Success(null, "تم الحذف بنجاح  ");


        }

        public async Task<Result> IndexAsync(FilterModel filterModel)
        {
            var donor =  appContext.Donors.AsQueryable();

            if (filterModel.FirstName != null)
            {
                donor = donor.Where(i => i.FirstName == filterModel.FirstName );

            }


            if (filterModel.LastName != null)
            {
                donor = donor.Where(i => i.LastName == filterModel.LastName);

            }

            if (filterModel.PhoneNumber != null)
            {
                donor = donor.Where(i => i.PhoneNumber == filterModel.PhoneNumber);

            }

            var reslut = await donor.ToListAsync();
            return new Result().Success(donor, "تم الحذف بنجاح  ");


        }
    }
}
