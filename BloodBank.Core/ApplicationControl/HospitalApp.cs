using BloodBank.Core.Domain;
using BloodBank.Core.Model.Hospital;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
     public class HospitalApp
     {
        private readonly ApplicationContext appContext; 
            
        public HospitalApp(ApplicationContext appContext)
        {
            this.appContext = appContext; 
        }

        private (bool isValide ,string message) Validate(InputHospitalModel model)
        {
            if (string.IsNullOrEmpty(model.HospitalName))
            {
                return (false, "الرجاء أدخال أسم المستشفي"); 
            }

            if (string.IsNullOrEmpty(model.Address))
            {
                return (false, "الرجاء أدخال العنوان المستشفي"); 
            }

            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return (false, "الرجاء أدخال رقم الهاتف المستشفي");
            }

            return (true, ""); 
        }

        /////////////////////// Create ///////////////////////
        public async Task<Result> CreateAsync (InputHospitalModel model)
        {
            var validate = Validate(model); 

            if (!validate.isValide)
            {
                return new Result().Fail(validate.message); 
            }

            var isNameExiesd = appContext.Hospitals.Any(i =>
              i.HospitalName == model.HospitalName );

            if (isNameExiesd)
            {
                return new Result().Fail("عذرا هذه المستشفي موجودة مسبقا"); 
            }

            var hospital = new Hospital(
              model.HospitalName,
              model.Address,
              model.PhoneNumber);


            appContext.Hospitals.Add(hospital);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية الأضافة"); 
            }
            return new Result().Success(hospital, "تم عملية الأضافة بنجاح"); 
        }


        /////////////////////// Update ///////////////////////
        public async Task<Result> UpdateAsync(Guid id ,InputHospitalModel model)
        {
            var validate = Validate(model);

            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }

            var isNameExiesd = appContext.Hospitals.Any(i => 
            i.HospitalId != id && 
            i.HospitalName == model.HospitalName && 
            i.Address == model.Address && 
            i.PhoneNumber == model.PhoneNumber);

            if (isNameExiesd)
            {
                return new Result().Fail("عذرا هذه المستشفي موجودة مسبقا");
            }

            var hospital = await appContext.Hospitals.FindAsync(id);
            
            if (hospital == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذه المستشفي"); 
            }


            hospital.Modify(
              model.HospitalName,
              model.Address,
              model.PhoneNumber);

            appContext.Hospitals.Update(hospital);

            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية التعديل"); 
            }

            return new Result().Success(hospital, "تم عملية التعديل بنجاح"); 
        }


        /////////////////////// Find ///////////////////////
        public async Task<Result> FindAsync(Guid id)
        {
            var hospital = await appContext.Hospitals.FindAsync(id); 
            
            if (hospital == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذه المستشفي"); 
            }

            return new Result().Success(hospital, "تم العثور علي هذه المستشفي بنجاح"); 
        }

        /////////////////////// Delet ///////////////////////
        public async Task<Result> DeletAsync(Guid id)
        {
            var hospital = await appContext.Hospitals.FindAsync(id); 

            if (hospital == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذه المستشفي");
            }

            appContext.Hospitals.Remove(hospital);
            var result = await appContext.SaveChangesAsync();  

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم علمية الحذف"); 
            }
            return new Result().Success(true, "تم عملية الحذف بنجاح "); 
        }

        /////////////////////// Search And Display ///////////////////////
        public async Task<Result> IndexAsync(FilterHospitalMoldel filterhospitalmolel)
        {
            var hospital = appContext.Hospitals.AsQueryable(); 

            if (filterhospitalmolel.HospitalName != null)
            {
                hospital = hospital.Where(i => i.HospitalName == filterhospitalmolel.HospitalName); 
            }


            if (filterhospitalmolel.Address != null)
            {
                hospital = hospital.Where(i => i.Address == filterhospitalmolel.Address); 
            }

            if (filterhospitalmolel.PhoneNumber != null)
            {
                hospital = hospital.Where(i => i.PhoneNumber == filterhospitalmolel.PhoneNumber);
            }

            var result = await appContext.Hospitals.ToListAsync();
            return new Result().Success(hospital, "لقد تم العرض جميع سجلات المستشفيات"); 
        }
    }
}
