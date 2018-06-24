using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.EntityManager;

namespace Max.MedicalLab.Data.Entity.Repository
{
    public class PatientVisitRepository : MedLabRepository<PatientVisit>
    {
        public PatientVisit GetVisit(int visitID)
        {
            var visit = base.context.PatientVisits.FirstOrDefault(p => p.PatientVisitId.Equals(visitID));
            return visit;
        }

    }
}
