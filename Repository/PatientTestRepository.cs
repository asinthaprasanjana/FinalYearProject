using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
namespace Max.MedicalLab.Data.Entity.Repository
{
    public class PatientTestRepository:MedLabRepository<PatientTest>
    {
        public PatientTest GetTest(int visitID)
        {
            var test = base.context.PatientTests.AsNoTracking().FirstOrDefault(p => p.VisitID.Equals(visitID));
            return test;
        }

       
    }
}
