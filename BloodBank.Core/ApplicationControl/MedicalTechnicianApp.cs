using BloodBank.Core.Domain;
using BloodBank.Core.Model.MedicalTechnician;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
    public class MedicalTechnicianApp
    {
        private readonly ApplicationContext appContext;

        public MedicalTechnicianApp(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        private (bool isValide, string message) Validate(InputMedicalTechnicianModel model)
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
        public async Task<Result> CreateAsync(InputMedicalTechnicianModel model)
        {
            var validate = Validate(model);
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }

            var isNameExiesd = appContext.MedicalTechnicians.Any(i =>
            i.FirstName == model.FirstName &&
            i.LastName == model.LastName  );

            if (isNameExiesd)
            {
                return new Result().Fail("عذرا هذا الفني موجود مسبقا");

            }

            var medicaltechnician = new MedicalTechnician(
                model.FirstName, 
                model.LastName, 
                model.DateOfBirth, 
                model.Gender, 
                model.Qualification, 
                model.YearsOfExperience,
                model.Address,
                model.PhoneNumber);

            appContext.MedicalTechnicians.Add(medicaltechnician);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0 )
            {
                return new Result().Fail("عذرا لم يتم عملية الأضافة"); 
            }
            return new Result().Success(medicaltechnician, "تم عملية الأضافة بنجاح"); 

        }

        /////////////////////// Update  ///////////////////////   
        public async Task<Result> UpdateAsync(Guid id, InputMedicalTechnicianModel model)
        {
            var validate = Validate(model);
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }

            var isNameExised = appContext.MedicalTechnicians.Any(i =>
            
              i.MedicalTechniciansId != id && 
              i.FirstName == model.FirstName &&
              i.LastName == model.LastName && 
              i.PhoneNumber == model.PhoneNumber); 


            if (isNameExised)
            {
                return new Result().Fail("عذرا هدا الفني موجود مسبقا"); 
            }

            var medicaltechnician = await appContext.MedicalTechnicians.FindAsync(id); 
            
            if (medicaltechnician == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا الفني");
            }


            medicaltechnician.Modify(
                model.FirstName,
                model.LastName,
                model.DateOfBirth,
                model.Gender,
                model.Qualification,
                model.YearsOfExperience,
                model.Address,
                model.PhoneNumber);

            appContext.MedicalTechnicians.Update(medicaltechnician);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية التعديل"); 
            }
            return new Result().Success(medicaltechnician, "تم عملية التعدل بنجاح");

        }


        /////////////////////// Find  ///////////////////////  
        public async Task<Result> FindAsync(Guid id)
        {

            var medicaltechnician = await appContext.MedicalTechnicians.FindAsync(id); 

            if (medicaltechnician == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا الفني"); 
            }

            return new Result().Success(medicaltechnician, "تم العثور علي هذا الفني بنجاح"); 

        }


        /////////////////////// Delet  ///////////////////////  
        public async Task<Result> DeletAsync(Guid id)
        {
            var medicaltechnician = await appContext.MedicalTechnicians.FindAsync(id);

            if (medicaltechnician == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا الفني");
            }


            appContext.MedicalTechnicians.Remove(medicaltechnician);
            var result = await appContext.SaveChangesAsync();

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية الحذف");
            }

            return new Result().Success(true, "تم عملية الحذف بنجاح"); 
        }



        ////////////////////// Search And Display  /////////////////////// 
        public async Task<Result> IndexAsync(FilterMedicalTechnicianModel filterModel)
        {
            var medicaltechnician = appContext.MedicalTechnicians.AsQueryable(); 

            if (filterModel.FirstName != null)
            {
                medicaltechnician = medicaltechnician.Where(i => i.FirstName == filterModel.FirstName); 
            }
           
            if (filterModel.LastName != null)
            {
                medicaltechnician = medicaltechnician.Where(i => i.LastName == filterModel.LastName); 
            }

            if (filterModel.PhoneNumber != null)
            {
                medicaltechnician = medicaltechnician.Where(i => i.PhoneNumber == filterModel.PhoneNumber); 
            }


            var result = await medicaltechnician.ToListAsync();
            return new Result().Success(medicaltechnician, "تم العرض جميع السجلات بنجاح"); 
        }

    }
}
