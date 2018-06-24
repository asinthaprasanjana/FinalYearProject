using AutoMapper;
using Max.MedicalLab.Business.Core.AutoMapper;
using Max.MedicalLab.Business.Core.Helper;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Max.MedicalLab.Business.Core.Managers
{

 
    /// <summary>
    /// 
    /// </summary>
    public class DoctorManager:MedLabRepository<Doctor>
    {
        DoctorHelper DoctorHelp = new DoctorHelper();
        DoctorRepository DocRepo = new DoctorRepository();

        /// <summary>
        /// 
        /// </summary>
        public DoctorManager()
        {
            DoctorRepository doctorRepo = new DoctorRepository();

        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DoctorDto GetDocByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {

                return null;
            }
            else
            {
                throw new NullReferenceException("Provided doctor cannot be null or empty.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public object DeleteDoctor(Doctor doctor)
        {
            MapperConfig.ConfigAutoMapper();

            {
                Doctor DelDoctor = context.Doctors.SingleOrDefault(item => item.DoctorId == doctor.DoctorId);
                context.Doctors.Remove(DelDoctor);
                context.SaveChanges();

                //patientRepo.Delete(Mapper.Map<Patient>(DelPatietnt));

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public DoctorDto DoctorUpdate(Doctor doctor)
        {
            MapperConfig.ConfigAutoMapper();

            if (DocRepo.GetDoctor(doctor.DoctorId)!=null )
            {
                doctor.CreatedDate = DocRepo.GetDoctor(doctor.DoctorId).CreatedDate;

                doctor.ModifiedBy = DocRepo.GetDoctor(doctor.DoctorId).ModifiedBy;

                doctor.CreatedBy = DocRepo.GetDoctor(doctor.DoctorId).CreatedBy;

                doctor.ModifiedDate = DateTime.Now;

                {
                    DocRepo.Update(Mapper.Map<Doctor>(doctor));
                }
            }
            else
            {
                throw new ArgumentNullException("Doctor not found!");
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chk"></param>
        /// <returns></returns>
        public DoctorDto GetDoctor(Doctor chk)
        {
            MapperConfig.ConfigAutoMapper();
 
         if (DoctorHelp.GetDoctorByName(chk.DoctorName) == null || DoctorHelp.GetDoctorBySpeciality(chk.DoctorSpeciality) == null)
           {
                System.Diagnostics.Debug.WriteLine("Doctor not found");
                return null;
           }
           else
           {
                System.Diagnostics.Debug.WriteLine("Doctor Found!");
                return null;
           }

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public DoctorDto AddNewDoctor(Doctor doctor)
        {
            
            MapperConfig.ConfigAutoMapper();

            if (this.IsValidDoctor(doctor))
            {

                if ((DoctorHelp.GetDoctorByName(doctor.DoctorName) == null)|| (DoctorHelp.GetDoctorBySpeciality(doctor.DoctorSpeciality) == null) )// Check is Doctor Exisits
                {
                    doctor.CreatedDate = DateTime.Now;
                    doctor.CreatedBy = "Reciptionist";
                    doctor.ModifiedBy = string.Empty;
                    doctor.ModifiedDate = null;

                    var saveDoctor = DocRepo.Insert(Mapper.Map<Doctor>(doctor));

                    return Mapper.Map<DoctorDto>(saveDoctor);

                }
                else

                {
                    throw new InvalidOperationException("Doctor is not acceptable to insert.Already exists");
                }
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }
        }

        private bool IsValidDoctor(Doctor Doctor)
        {

            if (Doctor == null)
            {
                throw new ArgumentNullException("Doctor Does not exists");
            }

            if (string.IsNullOrEmpty(Doctor.DoctorName))
            {
                throw new ArgumentNullException("Insert Name Field!");
            }

            if (string.IsNullOrEmpty(Doctor.DoctorSpeciality))
            {
                throw new ArgumentNullException("Insert Speciality Field!");
            }

            return true;
        }
    }
}
