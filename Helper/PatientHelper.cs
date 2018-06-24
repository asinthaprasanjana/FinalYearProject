using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Business.Core.Helper
{   /// <summary>
    /// 
    /// </summary>
    public class PatientHelper : MedLabRepository<Patient>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Patient GetPatientByName(string name)
        {
            var patient = base.context.Patients.AsNoTracking().FirstOrDefault(p => p.Name.Equals(name));

            return patient;

        }
    }
}
