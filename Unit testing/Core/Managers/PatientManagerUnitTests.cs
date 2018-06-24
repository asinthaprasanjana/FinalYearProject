using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Data.EntityManager;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class PatientManagerUnitTests
    {
        
        [TestMethod]
        public void DeletePatient()
        {
            Patient patient = new Patient()
            {
   
                ContactNo = "0770810866"

            };

           PatientManager PatientManager = new PatientManager();
           var DeletePatient = PatientManager.DeletePatient(patient);

        }

        [TestMethod]
        public void PatientUpdate()
        {
            Patient patient = new Patient()
            {
                PatientId = 94,
                Name = "saman perera",
                Address = "12/B,makola",
                Age = 39,
                Gender = "M",
                ContactNo = "0770810866",
               

            };
            PatientManager PatientManager = new PatientManager();
            var UpdatePatient = PatientManager.PatientUpdate(patient);
        }

       

        [TestMethod]
        public void SearchPatient()
        {
            PatientDto patient = new PatientDto()
            {           
                ContactNo = "0770880011",
                Name = "w.p perera"

            };

            PatientManager PatientManager = new PatientManager();
            var DeletePatient = PatientManager.searchPatient(patient);

        }
    }
}
