using BloodBank.Core.Domain;
using BloodBank.Core.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
   public class PatientApp
    {
        private readonly ApplicationContext appContext; 

        public PatientApp(ApplicationContext appContext)
        {
            this.appContext = appContext; 
        }

        private (bool isValide, string message) Validate(InputPatientModel model)
        {

            if (string.IsNullOrEmpty(model.FirstName))
            {
                return (false, "يرجى أدخال الاسم الأول ");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                return (false, "يرجى أدخال الاسم الأخير");
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return (false, "يرجى أدخال رقم الهاتف");
            }
            return (true, "");

        }

        /////////////////////// Create  /////////////////////// 
        public async Task<Result> CreateAsync(InputPatientModel model)
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

            var patient  = new Patient(
                model.FirstName,
                model.LastName,
                model.Gender,
                model.DateOfBirth,
                model.BloodType, 
                model.Quantity, 
                model.Address,
                model.PhoneNumber);

            appContext.Patients.Add(patient);
            var reslut = await appContext.SaveChangesAsync();

            if (reslut == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية أضافة ");

            }
            return new Result().Success(patient, "تم عملية أضافه بنجاح ");

        }

        /////////////////////// Update /////////////////////// 
        public async Task<Result> UpdateAsync(Guid id, InputPatientModel model) 
        {
            var validate = Validate(model); 
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message); 
            }

            var isNameExiesd = appContext.Patients.Any(i =>
            i.Patientid != id &&
            i.FirstName == model.FirstName &&
            i.LastName == model.LastName &&
            i.PhoneNumber == model.PhoneNumber); 
             

            if(isNameExiesd)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا المريض");

            }

            var patient = await appContext.Patients.FindAsync(id); 

            if (patient == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا المريض");
            }

            patient.Modify(
                model.FirstName,
                model.LastName,
                model.Gender,
                model.DateOfBirth,
                model.BloodType,
                model.Quantity,
                model.Address,
                model.PhoneNumber);

            appContext.Patients.Update(patient);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية التعديل ");
            }
            return new Result().Success(patient, "تمت عملية التعديل بنجاح"); 

        }

        /////////////////////// Search /////////////////////// 
        public async Task<Result> FindAsync(Guid id)
        {
            var patient = await appContext.Patients.FindAsync(id); 

            if (patient == null)
            {
                return new Result().Fail("عذرا لتم يتم العثور علي هذا المريض"); 
            }

            return new Result().Success(patient, " تم العثور علي هذا المريض بنجاح"); 
        }

        /////////////////////// Delet ///////////////////////
        public async Task<Result> DeletAsync(Guid id)
        {
            var patient = await appContext.Patients.FindAsync(id); 
            
            if (patient == null)
            {
                return new Result().Fail("عذرا لتم يتم العثور علي هذا المريض"); 
            }

            appContext.Patients.Remove(patient);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0 )
            {
                return new Result().Fail(" عذرا لم يتم عملية الحذف");
            }

            return new Result().Success(true, "تمت عملية الحذف بنجاح"); 
        }

        /////////////////////// Search And Dispaly /////////////////////// 
        public async Task<Result> IndexAsync(FilterPatientModel filtermodel)
        {
            var patient = appContext.Patients.AsQueryable(); 

            if (filtermodel.FirstName != null)
            {
                patient = patient.Where(i => i.FirstName == filtermodel.FirstName); 
            }

            if (filtermodel.LastName != null)
            {
                patient = patient.Where(i => i.LastName == filtermodel.LastName);
            }

            if (filtermodel.PhoneNumber != null)
            {
                patient = patient.Where(i => i.PhoneNumber == filtermodel.PhoneNumber); 
            }

            var result = await patient.ToListAsync();
            return new Result().Success(patient, "تم العرض جميع السجلات بنجاح"); 
        }

    }
}
