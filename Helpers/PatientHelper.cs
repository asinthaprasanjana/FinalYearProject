using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.Entity.Repository;
namespace Max.MedicalLab.Business.Core.Helpers
{
    class PatientHelper
    {
        private readonly PatientRepository patientRepo;
        public PatientHelper()
        {
            patientRepo = new PatientRepository();
        }
    }
}
