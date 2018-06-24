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
    public class PatientVisitHelper : MedLabRepository<PatientVisit>
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="templateId"></param>
       /// <returns></returns>
       public IList<TestTemplateAttributeDto> GetTestTemplateAttributes(int templateId)
        {
            if(templateId > 0)
            {
                TestTemplateAttributeRepository attrRepo = new TestTemplateAttributeRepository();
                var attrList = attrRepo.SearchFor(p => p.TemplateID == templateId);


                return Mapper.Map<List<TestTemplateAttributeDto>>(attrList);
                
            }
            else
            {
                return new List<TestTemplateAttributeDto>();
          
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public PatientVisit GetVisitByPatientID(int patientID)
        {
            var visit = base.context.PatientVisits.FirstOrDefault(p => p.PatientID.Equals(patientID + 1));
            return visit;
        }
       







    }
}
