using BloodBank.Core.Domain; 
using BloodBank.Core.Model.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
    public class UserApp
    {

        private readonly ApplicationContext appContext;

        public UserApp(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        private (bool isValide, string message) Validate(InputUserModel model)
        {
            if (string.IsNullOrEmpty(model.UserName))
            {
                return (false, "الرجاء أدخال أسم المستخدم");
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                return (false, "الرجاء أدخال رقم الهاتف"); 
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                return (false,"الرجاء أدخال  العنوان السكن الخاص بك");
            }
            return (true, "");
        }

        ///////////////////  Create  /////////////////////
        public async Task<Result> CreateAsync(InputUserModel model)
        {

            var validate = Validate(model);
            if (!validate.isValide)
            {
                return new Result().Fail(validate.message);
            }

            var isNameExiesd = appContext.Users.Any(i =>
               i.UserName == model.UserName &&
               i.PhoneNumber == model.PhoneNumber);

            if (isNameExiesd)
            {
                return new Result().Fail("عذرا هذا المستخدم موجود مسبقا");
            }


            var user = new User(
                model.UserName,
                model.PhoneNumber,
                model.DateOfBirt,
                model.Age,
                model.Gender,
                model.Address,
                model.PhoneNumber,
                model.Image
                );

            appContext.Users.Add(user);
            var result = await appContext.SaveChangesAsync();

            if (result == 0)
            {
                return new Result().Fail("عذرا لم يتم عملية الأضافة");
            }
            return new Result().Success(user, "تمت عميلة الأضافة بنجاح");
        }


        ///////////////////  UpDate  /////////////////////
        public async Task<Result> UpdateAsync(Guid id, InputUserModel model)
        {

            var validate = Validate(model);

            if (!validate.isValide)
            {
                return new Result().Fail(validate.message); 
            } 


            var isNameExised = appContext.Users.Any(i =>
            i.UserId != id &&
            i.UserName == model.UserName &&
            i.PhoneNumber == model.PhoneNumber);

            if (isNameExised)
            {
                return new Result().Fail("عذرا هذا المستخدم موجود مسبقا");

            }

            var user = await appContext.Users.FindAsync(id);

            if (user == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هدا المستخدم");
            }

            user.Modify(
                model.UserName,
                model.PassWord,
                model.DateOfBirt,
                model.Age,
                model.Gender,
                model.Address,
                model.PhoneNumber,
                model.Image
                );


            appContext.Users.Update(user);
            var result = await appContext.SaveChangesAsync();
            if (result == 0)
            {
                return new Result().Fail("لم تتم عملية التعديل");
            }

            return new Result().Success(true, "تمت عملية النعديل بنجاح");

        }


        ///////////////////  Find  /////////////////////
        public async Task<Result> FindAsync(Guid id)
        {
            var user = await appContext.Users.FindAsync(id);

            if (user == null)
            {
                return new Result().Fail("لم يتم العثور علي هذا المستخدم");
            }

            return new Result().Success(true, "تم العثور علي هذا المستخدم بنجاح");
        }


        ///////////////////  Delet  /////////////////////
        public async Task<Result> DeleteAsync(Guid id)
        {

            var user = await appContext.Users.FindAsync(id);

            if (user == null)
            {
                return new Result().Fail("عذرا لم يتم العثور علي هدا المستخدم");
            }

            appContext.Users.Remove(user);
            var result = await appContext.SaveChangesAsync(); 

            if (result == 0)
            {
                return new Result().Fail("عذرا لم تتم عملية الحذف"); 
            }
            return new Result().Success(true, "لقد تمت عملية الحذف بنجاح"); 

        }


        ///////////////////  Search And Dispaly /////////////////////
        public async Task<Result> IndexAsync(FilterUserModel filteruserModel)
        {

            var user = appContext.Users.AsQueryable(); 
         

            if (filteruserModel.UserName != null)
            {
                user = user.Where(i => i.UserName == filteruserModel.UserName); 
            }
             
            if (filteruserModel.PhoneNumber != null)
            {
                user = user.Where(i => i.PhoneNumber == filteruserModel.PhoneNumber); 
            }


            var reslut = await user.ToListAsync();
            return new Result().Success(user, "تم العرض جميع السجلات بنجاح  ");

        }
    }
}