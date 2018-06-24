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
    public class DoctorHelper: MedLabRepository<Doctor>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public Doctor GetDoctorByName(string doctor)
        {
            var Doctor = base.context.Doctors.AsNoTracking().FirstOrDefault(p => p.DoctorName.Equals(doctor));
            return Doctor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public Doctor GetDoctorBySpeciality(string doctor)
        {
            var Doctor = base.context.Doctors.AsNoTracking().FirstOrDefault(p => p.DoctorSpeciality.Equals(doctor));
            return Doctor;
        }
    }
}
