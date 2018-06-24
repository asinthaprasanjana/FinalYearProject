using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;

namespace Max.MedicalLab.Data.Entity.Repository
{
    public class DoctorRepository:MedLabRepository<Doctor>
    {

        public Doctor GetDoctor(int id)
        {
            var doctor = base.context.Doctors.AsNoTracking().FirstOrDefault(p => p.DoctorId.Equals(id));
            return doctor;

        }

    }
}
