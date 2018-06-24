using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.EntityManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class TestResultManagerUnitTest 
    {
        [TestMethod]
        public void ApproveTestByMLT()
        {
            PatientTest patientTest = new PatientTest()
            {
                VisitID = 69,
            };


            User user = new User()
            {
                UserId = 76,
                Username = "MLT"

            };
       
            TestResultManager testManager = new TestResultManager();
            var approve = testManager.ApproveTest(patientTest,user);

            
        }

        [TestMethod]
        public void UpdateAttribute()
        {
            TestResultDto updateResult = new TestResultDto()
            {
               //Result ID 
                ID = 358, 
                
                Value = "1.5%",
                Status = " Normal",

            };

            UserDto user = new UserDto()
            {
                UserId = 42,
                Username = "MLT01"

            };

            TestResultManager Attrib = new TestResultManager();

            var res = Attrib.UpdateAttribute(updateResult, user);

            
        }

        [TestMethod]
        public void DeleteResultRow()
        {
            TestResultDto Attribute = new TestResultDto()
            {
                ID = 334,
                VisitID = 73,

            };

            TestResultManager Attrib = new TestResultManager();

            var res = Attrib.DeleteAttribute(Attribute);
        }

        [TestMethod]
        public void GetResults()
        {
            PatientDto patient = new PatientDto()
            {
                ContactNo = "0770881084"
            };

            TestResultManager resu = new TestResultManager();

            var res = resu.Getresults(patient);
        }

    }
}
