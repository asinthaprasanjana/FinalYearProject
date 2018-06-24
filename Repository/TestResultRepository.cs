using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
namespace Max.MedicalLab.Data.Entity.Repository
{
    public class TestResultRepository:MedLabRepository<TestResult>
    {
        public TestResult GetResult(int AttrId)
        {
            var result = base.context.TestResults.AsNoTracking().FirstOrDefault(p => p.AttrID.Equals(AttrId));
            return result;
        }
    }
}
