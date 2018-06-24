using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.AutoMapper;
using AutoMapper;
using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Business.Core.Helper;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestResultManager : MedLabRepository<TestResult>
    {
        PatientVisitHelper visitHelper = new PatientVisitHelper();
        PatientTestRepository TestRepo = new PatientTestRepository();
        TestResultRepository ResultRepo = new TestResultRepository();
        PatientRepository patient = new PatientRepository();
        PatientVisitRepository visit = new PatientVisitRepository();
        PatientTestResultHelper helper = new PatientTestResultHelper();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientTest"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// 

        public PatientTestDto ApproveTest(PatientTest patientTest, User user)
        {
            MapperConfig.ConfigAutoMapper();

            patientTest.TemplateID = TestRepo.GetTest(patientTest.VisitID).TemplateID;
            patientTest.PatientTestID = TestRepo.GetTest(patientTest.VisitID).PatientTestID;
            patientTest.CreatedBy = TestRepo.GetTest(patientTest.VisitID).CreatedBy;

            patientTest.ModifiedBy = user.Username;
            patientTest.ApprovedBy = user.UserId;

            patientTest.CreatedDate = new DateTime(2016, 5, 5);
            patientTest.ModifiedDate = DateTime.Now;
            patientTest.ApprovedDate = DateTime.Now;

            System.Diagnostics.Debug.WriteLine("Test Approved by : "+user.Username+" ");
            TestRepo.Update(Mapper.Map<PatientTest>(patientTest));

            return null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateAttribute"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public TestTemplateAttributeDto UpdateAttribute(TestResultDto updateAttribute, UserDto user)
        {
            MapperConfig.ConfigAutoMapper();

            if ((updateAttribute != null) && (user!=null)) {

                PatientTestResultHelper Resulthelp = new PatientTestResultHelper();

                // Attribute set according to the visit ID
                IList<TestResultDto> ResultAttributes = Resulthelp.GetTestResults(updateAttribute.VisitID);              

                //updateAttribute.AttrID = Resulthelp.GetResultByVisitID(updateAttribute.VisitID).AttrID;

                updateAttribute.ModifiedDate = DateTime.Now;

                updateAttribute.VisitID = Resulthelp.GetResultByID(updateAttribute.ID).VisitID;

                updateAttribute.AttrID = Resulthelp.GetResultByID(updateAttribute.ID).AttrID;

                updateAttribute.CreatedBy = Resulthelp.GetResultByVisitID(updateAttribute.VisitID).CreatedBy;

                updateAttribute.CreatedDate = Resulthelp.GetResultByVisitID(updateAttribute.VisitID).CreatedDate;

                updateAttribute.ModifiedBy = user.Username;

                ResultRepo.Update(Mapper.Map<TestResult>(updateAttribute));
              
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Null Attribute ! /  Null User ");
            }

            return null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        /// 
        public Patient Getresults(PatientDto Patient)
        {
            MapperConfig.ConfigAutoMapper();

            if (patient.GetPatient(Patient.ContactNo) != null)
            {
                int PatientID = patient.GetPatient(Patient.ContactNo).PatientId;

                int visitID = visitHelper.GetVisitByPatientID(PatientID).PatientVisitId;

                IList<TestResultDto> TestAttribute = helper.GetTestResults(visitID);

                System.Diagnostics.Debug.WriteLine("Result set Found !");

                System.Diagnostics.Debug.WriteLine(TestAttribute);

            }
            else
            {

                System.Diagnostics.Debug.WriteLine("Patient Not Found !");
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        /// 
        public TestResultDto DeleteAttribute(TestResultDto attribute)
        {
            PatientTestResultHelper visitHelper = new PatientTestResultHelper();
            MapperConfig.ConfigAutoMapper();

            if (attribute!=null)
            {
                attribute.ModifiedDate = DateTime.Now;
                attribute.CreatedDate = new DateTime(2017, 7, 6);
                attribute.CreatedBy = "EMP01";
                attribute.ModifiedBy = null;

                IList<TestResultDto> TestRes = visitHelper.GetTestResults(attribute.VisitID);

                TestResult Del = context.TestResults.SingleOrDefault(item => item.ID == attribute.ID);
                context.TestResults.Remove(Mapper.Map<TestResult>(Del));
                context.SaveChanges();

         
                return null;
            }
            else
            {
                throw new NullReferenceException("null attrib");
            }
           
        }
    }
}
