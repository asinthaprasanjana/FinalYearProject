using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.Entity.Repository;
using AutoMapper;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.AutoMapper;
using Max.MedicalLab.Data.EntityManager;
using Max.MedicalLab.Business.Core.Helper;
namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class PatientVisitManager 
    {
        private readonly PatientVisitRepository PatientVisitRepo;

        DoctorRepository DoctorRepository = new DoctorRepository();
        PatientRepository PatientRepository = new PatientRepository();
        PatientTestRepository PatientTestRepository = new PatientTestRepository();
        TestTemplateRepository TestTemplateRepository = new TestTemplateRepository();
        TestResultRepository TestResultRepository = new TestResultRepository();
        UserRepository UserRepository = new UserRepository();
        PatientVisitRepository visitRepo = new PatientVisitRepository();
        DoctorHelper DoctorHelp = new DoctorHelper();
        
        /// <summary>
        /// 
        /// </summary>
        public PatientVisitManager()
        {
            this.PatientVisitRepo = new PatientVisitRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientVisit"></param>
        /// <param name="Template"></param>

        /// <returns></returns>
        public PatientVisitDto AddNewPatientVisit(PatientVisit patientVisit,TestTemplate Template)
        {
            PatientVisitHelper visithelp = new PatientVisitHelper();

            MapperConfig.ConfigAutoMapper();

        if (this.ValidateVisit(patientVisit))
        {
          patientVisit.CreatedDate = DateTime.Now;
          patientVisit.CreatedBy = "EMP";
          patientVisit.ModifiedDate = new DateTime(2017, 12, 2);
          patientVisit.ModifiedBy = string.Empty;

           // if (DoctorRepository.GetDoctor(patientVisit.Doctor.DoctorId) == null)
           if(DoctorHelp.GetDoctorByName(patientVisit.Doctor.DoctorName) == null || 
              DoctorHelp.GetDoctorBySpeciality(patientVisit.Doctor.DoctorSpeciality) == null)
            {
                this.AddNewDoctor(patientVisit.Doctor);

                System.Diagnostics.Debug.WriteLine("Doctor Added");

                patientVisit.Doctor = DoctorHelp.GetDoctorByName(patientVisit.Doctor.DoctorName);
            }
                else
                {
                    patientVisit.DoctorID = DoctorHelp.GetDoctorByName(patientVisit.Doctor.DoctorName).DoctorId;

                    patientVisit.Doctor = DoctorHelp.GetDoctorByName(patientVisit.Doctor.DoctorName);

                    System.Diagnostics.Debug.WriteLine("Doctor Exists");
                }


            if (PatientRepository.GetPatient(patientVisit.Patient.ContactNo) == null)           
            {                 
                 this.AddNewPatient(patientVisit.Patient);

                 patientVisit.Patient = PatientRepository.GetPatient(patientVisit.Patient.ContactNo);

                 System.Diagnostics.Debug.WriteLine("Patient Added");
                }
                else
                {
                    patientVisit.PatientID = PatientRepository.GetPatient(patientVisit.Patient.ContactNo).PatientId;

                    patientVisit.Patient = PatientRepository.GetPatient(patientVisit.Patient.ContactNo);

                    System.Diagnostics.Debug.WriteLine("Patient Exists");
                }

            patientVisit.UserId = UserRepository.GetUser(patientVisit.User.Username).UserId;

            patientVisit.User.RoleId = 1;

            patientVisit.User = UserRepository.GetUser(patientVisit.User.Username);

            var NewVisit = PatientVisitRepo.Insert(Mapper.Map<PatientVisit>(patientVisit));
            Mapper.Map<PatientVisitDto>(NewVisit);       

            System.Diagnostics.Debug.WriteLine("Visit Added");

            int VisitId = NewVisit.PatientVisitId;
             
            this.AddNewPatientTest(VisitId,Template);

            System.Diagnostics.Debug.WriteLine("Patient Test Added");

            int testTemplateID = TestTemplateRepository.GetTestTemplate(Template.TemplateName).TestTemplateId;
                   
            IList<TestTemplateAttributeDto> TestAttribute = visithelp.GetTestTemplateAttributes(testTemplateID);

            TestResult results = new TestResult();
                
                   foreach (var x in TestAttribute)
                     {                      
                        results.AttrID = x.AttrID;
                        results.VisitID = VisitId;
                        results.Status = "NO STATUS YET";
                        results.Value = "NO VALUE YET";
                        this.AddNewTestResult(results);
                     }

                System.Diagnostics.Debug.WriteLine("Result Added");

            }

        else
        {
          throw new ArgumentNullException("Provided information is not valid.");
        }

     return null;
}
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public PatientDto AddNewPatient(Patient patient)
        {
           
            MapperConfig.ConfigAutoMapper();

            patient.CreatedDate = DateTime.Now;
            patient.CreatedBy = "EMP_RECIPTION";
            patient.ModifiedBy = string.Empty;
            patient.ModifiedDate = null;

            var savePatient = PatientRepository.Insert(Mapper.Map<Patient>(patient));
            return Mapper.Map<PatientDto>(savePatient);      
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public DoctorDto AddNewDoctor(Doctor doctor)
        {
            MapperConfig.ConfigAutoMapper();
                    
            doctor.CreatedDate = DateTime.Now;
            doctor.CreatedBy = "EMP_RECIPTION";
            doctor.ModifiedBy = string.Empty;
            doctor.ModifiedDate = null;
                    
            var saveDoctor = DoctorRepository.Insert(Mapper.Map<Doctor>(doctor));
            return Mapper.Map<DoctorDto>(saveDoctor); 
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitid"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public PatientTestDto AddNewPatientTest(int visitid,TestTemplate template)
        {
            MapperConfig.ConfigAutoMapper();

            PatientTest Test = new PatientTest();

            int testTemplateID = TestTemplateRepository.GetTestTemplate(template.TemplateName).TestTemplateId;
            Test.TemplateID = testTemplateID;
            Test.VisitID = visitid;

            /*This will update by MLT After he Approved the test */
            Test.ApprovedBy = 0;

            Test.CreatedBy = "EMP";
            Test.Price = TestTemplateRepository.GetTestTemplate(template.TemplateName).Price;          
            Test.CreatedDate = DateTime.Now;                    
            Test.ApprovedDate = DateTime.Now;
            Test.ModifiedBy = string.Empty;
            Test.ModifiedDate = null;
         
            var patientTest = PatientTestRepository.Insert(Mapper.Map<PatientTest>(Test));
            return Mapper.Map<PatientTestDto>(patientTest);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        public TestResultDto AddNewTestResult(TestResult Result)
        {
            
            MapperConfig.ConfigAutoMapper();

            Result.CreatedDate = DateTime.Now;
            Result.CreatedBy = "EMP";
            Result.ModifiedDate = null;
            Result.ModifiedBy = string.Empty;

            var NewResult = TestResultRepository.Insert(Mapper.Map<TestResult>(Result));
            return Mapper.Map<TestResultDto>(NewResult);
        }



            private bool ValidateVisit(PatientVisit patientvisit)
        {
            if (patientvisit == null)
            {
                throw new ArgumentNullException("patien visit Details canno't be null");
            }                      
            if (string.IsNullOrEmpty(patientvisit.ExpectedDeliveryDate.ToString()))
            {
                throw new ArgumentNullException("Insert Expected deliver date Field!");
            }
            if (string.IsNullOrEmpty(patientvisit.ArriveDate.ToString()))
            {
                throw new ArgumentNullException("Insert Arrive Date ");
            }
            if (patientvisit.Patient == null)
            {
                throw new ArgumentNullException("Patient information canno't be null.");
            }

            if (patientvisit.Patient.ContactNo.Length > 10)
            {
                System.Diagnostics.Debug.WriteLine("Invalid Contact Number");

                throw new ArgumentNullException();              
            }

            if (patientvisit.Doctor == null)
            {
                throw new ArgumentNullException("Doctor information canno't be null.");
            }
            if (patientvisit.User == null)
            {
                throw new ArgumentNullException("user information canno't be null.");
            }

            return true;
        }

        
        

    }

}

    

