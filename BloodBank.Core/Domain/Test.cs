using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{


   public class Test
    {
         
        public Test()
        {

        }

        public Test (
            string testname, 
            string testdescription)
        {
            TestName = testname;
            TestDescription = testdescription; 
        }



        public Guid TestId { get;private set; }
        public string TestName { get; private set; }
        public string TestDescription { get;private set; }


       public void Modify(
            string testdescription,
            string testname)
        {
            TestName = testname;
            TestDescription = testdescription;
        }

    }
}
