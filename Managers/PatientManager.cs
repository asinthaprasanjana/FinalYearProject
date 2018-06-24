using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using AutoMapper;
using Max.MedicalLab.Business.Core.AutoMapper;
using Max.MedicalLab.Business.Core.Helper;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class PatientManager:MedLabRepository<Patient>
    {
        PatientRepository patientRepo = new PatientRepository();
        PatientHelper patientHelper = new PatientHelper();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public PatientDto DeletePatient(Patient patient)
        {
            MapperConfig.ConfigAutoMapper();

            if (patient.ContactNo.Length <= 10)
            {               
                Patient DelPatietnt = context.Patients.FirstOrDefault(item => item.ContactNo == patient.ContactNo);
                context.Patients.Remove(DelPatietnt);
                context.SaveChanges();                
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Contact Number");
                throw new ArgumentNullException();
            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public PatientDto PatientUpdate(Patient patient)
        {
            MapperConfig.ConfigAutoMapper();

            if (patient.ContactNo.Length <=10) {

                patient.CreatedBy = patientRepo.GetPatient(patient.ContactNo).CreatedBy;
                patient.CreatedDate = patientRepo.GetPatient(patient.ContactNo).CreatedDate;
                patient.ModifiedBy = patientRepo.GetPatient(patient.ContactNo).ModifiedBy;
                patient.ModifiedDate = DateTime.Now;
            }
            else
            {
                 System.Diagnostics.Debug.WriteLine("Invalid Contact Number");
                 throw new ArgumentNullException();               
            }

            {
                patientRepo.Update(Mapper.Map<Patient>(patient));
            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public PatientDto searchPatient(PatientDto patient)
        {
            if (patient.ContactNo.Length<=10) {

                if ((patientRepo.GetPatient(patient.ContactNo) == null) || (patientHelper.GetPatientByName(patient.Name) == null))
                {
                    System.Diagnostics.Debug.WriteLine("Patient not found");
                    return null;
                }
                else

                    System.Diagnostics.Debug.WriteLine("Patient found");
                return null;
            }
            else
            {

                    System.Diagnostics.Debug.WriteLine("Invalid Contact Number");
                    throw new ArgumentNullException();

            }

        }
    }
}
