using BloodBank.Core.Domain;
using BloodBank.Core.Model.Donors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Application
{
    public class DonorApp
    {
        public Task<Result> CreateAsync(Donor model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return Task.FromResult(new Result().Fail("يرجى ادخال الاسم"));
            }




            return Task.FromResult(new Result().Success(true,"يرجى ادخال الاسم"));
        }

        public Task<Donor> UpdateAsync(Donor model)
        {
            throw new ArgumentNullException();
        }

        public Task<Donor> FindAsync(Guid id)
        {
            throw new ArgumentNullException();

        }

        public Task<Donor> DeleteAsync(Guid id)
        {
            throw new ArgumentNullException();

        }

        public Task<List< Donor>> IndexAsync(FilterModel filterModel)
        {
            throw new ArgumentNullException();

        }
    }
}
