using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Domain
{
   public class TestResults
    {

        public TestResults()
        {

        }

        public TestResults(
            Guid testid,
            Guid donationsid, 
            string results, 
            DateTime examinationdate)
        {
            TestId = testid;
            DonationsId = donationsid; 
            Results = results;
            ExaminationDate = examinationdate;
        }



        public Guid TestResultsId { get;private set; }
        public Guid TestId { get; private set; }
        public Guid DonationsId { get; private set; }
        public string Results { get;private set; }
        public DateTime ExaminationDate { get;private set; } 


        public void Modify(
          Guid testid,
          Guid donationsid,
          string results,
          DateTime examinationdate)
        {
            TestId = testid;
            DonationsId = donationsid;
            Results = results;
            ExaminationDate = examinationdate; 
        }

    }
 
}
