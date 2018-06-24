using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Data.Entity.Repository
{
    public class PatientRepository : MedLabRepository<Patient>
    {

        public Patient GetPatient(string number)
        {
            var patient = base.context.Patients.AsNoTracking().FirstOrDefault(p => p.ContactNo.Equals(number));

            return patient;


        }


    }
}
