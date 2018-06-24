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
    public class RoleManagerUnitTest
    {
        [TestMethod]
        public void CreatRole()
        {
            Role role = new Role()
            {
                RoleName ="System Administrator",
                Remarks = "Remarks of Role"
                
            };

            RoleManager roleManager = new RoleManager();
            var approve = roleManager.createRole(role);
        }

        [TestMethod]
        public void deleteRole()
        {
            Role role = new Role()
            {
                RoleID = 4
            };

            RoleManager roleManager = new RoleManager();
            var delete = roleManager.DeleteRole(role);
        }

        [TestMethod]
        public void UpdateRole()
        {
            Role role = new Role()
            {
                RoleID = 1,
                RoleName = "User Management",
                Remarks = "New Remarks"
                
            };
            RoleManager roleManager = new RoleManager();
            var update = roleManager.UpdateRole(role);
        }
     }
}
