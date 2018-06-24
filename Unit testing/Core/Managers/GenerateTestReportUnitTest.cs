using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Common.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class GenerateTestReportUnitTest
    {
        [TestMethod]
        public void Printreport()
        {
            TestResultDto result = new TestResultDto()
            {
                VisitID = 75
            };

            ReportGenerateManagement reportmngr = new ReportGenerateManagement();
            var Generate = reportmngr.PrintReport(result);

        }

        [TestMethod]
        public void GetPatientTest()
        {
            PatientDto patient = new PatientDto()
            {
                ContactNo = "0770881031"
            };

            ReportGenerateManagement reportmngr = new ReportGenerateManagement();
            var Generate = reportmngr.GetTest(patient);
        }

    }
}
