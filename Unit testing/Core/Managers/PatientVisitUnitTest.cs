using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Data.EntityManager;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class PatientVisitUnitTest
    {
        [TestMethod]
        public void PatientVisitAdd()
        {
            PatientVisit visit = new PatientVisit();
            {
                visit.ExpectedDeliveryDate = new DateTime(2017, 02, 23);
                visit.ArriveDate = DateTime.Now;
                
            };

            visit.Patient = new Patient();
            {
                visit.Patient.ContactNo = "0771013425";
                visit.Patient.Address = "12/B,colombo09";
                visit.Patient.Name = "navod perera";
                visit.Patient.Age = 30;
                visit.Patient.Gender = "M";

            };

            visit.Doctor = new Doctor();
            {
               
                visit.Doctor.DoctorName = "Thilan perera";
                visit.Doctor.DoctorSpeciality = "ENT";

            };

            visit.User = new User();
            {
                visit.User.Username = "MLT";
                visit.User.ModifiedBy = null;
            };

            TestTemplate template = new TestTemplate()
            {
                TemplateName = "Blood Report Template",                
            };

            PatientVisitManager patientvisit = new PatientVisitManager();
            var Visit = patientvisit.AddNewPatientVisit(visit,template);


           
        }
       

      }       
    }


