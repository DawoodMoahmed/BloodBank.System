using BloodBank.Core.Domain;
using BloodBank.Core.Model.Test;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
   public class TestApp
    {
        private readonly ApplicationContext appContext;

        public TestApp(ApplicationContext appContext)
        {
            this.appContext = appContext; 
        }

        private (bool isValide ,string message) Validate(InputTestModel model)
        {
            if(string.IsNullOrEmpty(model.TestName))
            {
                return (false, "عذرا الرجاء أدخال أسم الفحص"); 
            }

            if (string.IsNullOrEmpty(model.TestDescription))
            {
                return (false, "عذرا الرجاء أدخال وصف الفصح"); 
            }
            return (true, ""); 
        }

        /////////////////////// Create ///////////////////////
        public async Task<Result> CreateAsync(InputTestModel model)
        {
            var validate = Validate(model); 
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message); 
            }


            var test = new Test(
                model.TestName, 
                model.TestDescription);

            appContext.Tests.Add(test);
            var result = await appContext.SaveChangesAsync(); 
            
            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عميلة الأضافة"); 
            }

            return new Result().Success(test, "تم عملية الأضافة بنجاح"); 
        }

        /////////////////////// Update  ///////////////////////
        public async Task<Result> UpdateAsync(Guid id, InputTestModel model)
        {
            var validate = Validate(model);
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }


            var isTsetExiesd = appContext.Tests.Any(i =>
                i.TestId != id &&
                i.TestName == model.TestName &&
                i.TestDescription == model.TestDescription);

            if (isTsetExiesd)
            {
                return new Result().Fail("عذرا هذا الفحص غير موجود مسبقا");
            }

            var test = await appContext.Tests.FindAsync(id);

            if (test == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا الفحص");

            }

            test.Modify(
                model.TestName, 
                model.TestDescription);

            appContext.Tests.Update(test);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية التعديل"); 
            }

            return new Result().Success(test, "تم عملية التعديل بنجاح"); 
        }

        /////////////////////// Find  ///////////////////////
        public async Task<Result> FindAsync(Guid id)
        {
            var test = await appContext.Tests.FindAsync(id); 

            if (test == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا الفحص");
            }

            return new Result().Success(test, "تم عملية العثور علي الفحص بنجاح"); 
        }

        /////////////////////// Delet  ///////////////////////
        public async Task<Result> DeletAsync(Guid id)
        {
            var test = await appContext.Tests.FindAsync(id);

            if (test == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هذا الفحص");
            }

            appContext.Tests.Remove(test);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية الحذف"); 
            }
            return new Result().Success(test, "لقد تم عملية الحذف بنجاح"); 
        }

        /////////////////////// Search And Display  ///////////////////////
        public async Task<Result> IndexAsync(FilterTestModel filtertestmodel)
        {
            var test = appContext.Tests.AsQueryable(); 


            if (filtertestmodel.TestName != null)
            {
                test = test.Where(i => i.TestName == filtertestmodel.TestName); 
            }


            if (filtertestmodel != null)
            {
                test = test.Where(i => i.TestDescription == filtertestmodel.TestDescription); 
            }

            var result = await test.ToListAsync();
            return new Result().Success(test, "تم العرض جميع السجلات بنجاح"); 
        } 

    }
}
