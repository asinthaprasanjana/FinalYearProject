using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.EntityManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class DoctorManagerUnitTest
    {

        [TestMethod]
        public void DeleteDoctor()
        {
            Doctor Doctor = new Doctor()
            {
                DoctorId = 124,             
            };

            DoctorManager DoctManager = new DoctorManager();
            var DeleteDoctor = DoctManager.DeleteDoctor(Doctor);
 
        }

        [TestMethod]
        public void DoctorUpdate()
        {
            Doctor Doctor = new Doctor()
            {
                DoctorId=95,
                DoctorName = "kamal Perera",
                DoctorSpeciality = "Nuro",
                
            };
            DoctorManager DoctManager = new DoctorManager();
            var UpdateDoctor = DoctManager.DoctorUpdate(Doctor);


        }
       
        [TestMethod]
        public void SearchDoctor()
        {
            Doctor chk = new Doctor()
            {
                DoctorName = "Dr.Malaki perera",
                DoctorSpeciality = "ENT"
            };
            DoctorManager DoctManager = new DoctorManager();
            var AddDoctor = DoctManager.GetDoctor(chk);

        }
       
    }
}
