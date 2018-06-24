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
    public class PaymentUnitTest
    {
        [TestMethod]
        public void PrintSlip()
        {
            TestResultDto res = new TestResultDto()
            {
                VisitID = 76,
            };

            decimal payment = 5000;
            bool discount = true;
            double discountAmount = 0.2;

            PaymentManagement paymentmanager = new PaymentManagement();
            var pay = paymentmanager.CreateSlip(res,payment,discount,discountAmount);
        }
    }
}
