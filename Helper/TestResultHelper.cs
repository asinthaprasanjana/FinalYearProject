using AutoMapper;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Business.Core.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class PatientTestResultHelper : MedLabRepository<TestResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public IList<TestResultDto> GetTestResults(int visitID)
        {
            if (visitID > 0)
            {
                TestResultRepository results = new TestResultRepository();
           
                var attrList = results.SearchFor(p => p.VisitID == visitID);
            
                return Mapper.Map<List<TestResultDto>>(attrList);
                
            }
            else
            {
                return new List<TestResultDto>();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public TestResult GetResultByVisitID(int visitID)
        {
            var res = base.context.TestResults.AsNoTracking().FirstOrDefault(p => p.VisitID.Equals(visitID));
            if (res==null)
            {
                System.Diagnostics.Debug.WriteLine("Results Not Found");
            }

               return res;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TestResult GetResultByID(int Id)
        {
            var res = base.context.TestResults.AsNoTracking().FirstOrDefault(p => p.ID.Equals(Id));

            if (res == null)
            {
                System.Diagnostics.Debug.WriteLine("Results Not Found");
            }

            return res;

        }


    }
}
