using BloodBank.Core.Domain;
using BloodBank.Core.Model.Donors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.ApplicationControl
{
    class UserApp
    {
        public Task<Result> CreateAsync(User model)
        {
            if (string.IsNullOrEmpty(model.Fname))
            {
                return Task.FromResult(new Result().Fail("يرجى ادخال الاسم"));
            }
            else if (string.IsNullOrEmpty(model.Lname))
            {
                return Task.FromResult(new Result().Fail("يرجى ادخال الاسم"));
            }
            else
            {
                return Task.FromResult(new Result().Success(true, "تم أضافه بنجاح "));
            }
        }
        public Task<Donor> UpdateAsync(User model)
        {
            throw new ArgumentNullException();
        }
        public Task<User> FindAsync(Guid id)
        {
            throw new ArgumentNullException();

        }
        public Task<List<User>> IndexAsync(FilterModel filterModel)
        {
            throw new ArgumentNullException();

        }
    }
}