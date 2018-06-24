using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Data.EntityManager;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class UserManagerUnitTests
    {
        [TestMethod]
        public void AddNewUserSaltTest()
        {
            UserDto user = new UserDto
            {
                Username = "MLT",
                Password = "MLT123",
                ConfirmPassword = "MLT123",
                RoleId = 1
            };

            UserManager userManager = new UserManager();
            var createdUser = userManager.AddNewUser(user);

            Assert.IsNotNull(createdUser);
        }

        [TestMethod]
        public void AddNewUserPasswordMismatch()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void LoginTest()
        {

            UserDto user = new UserDto();          
            {
                user.Username = "MLT";
                user.Password = "MLT123";               
            };

            UserManager userManager = new UserManager();
            var LoggedUser = userManager.Login(user.Username, user.Password);

            Assert.IsNotNull(LoggedUser);
            Assert.IsTrue(LoggedUser.Username.Equals("MLT"));
        }

        [TestMethod]
        public void DeleteUser()
        {
            UserDto user = new UserDto()
            {
                UserId = 75
            };

           UserManager userManager = new UserManager();
           var DelUser = userManager.DeleteUser(user);

            
        }

        [TestMethod]
        public void UpdateUser()
        {
            UserDto user = new UserDto()
            {
                UserId = 76,
                Username  =  "Reciption",
                Password  =  "password",                
                RoleId = 1,
                             
            };

            UserManager userManager = new UserManager();
            var UpdateUser = userManager.UpdateUser(user);
        }

        [TestMethod]
        public void UnlockUser()
        {
            UserDto user = new UserDto()
            {
                UserId = 76,

            };

            UserManager userManager = new UserManager();
            var UpdateUser = userManager.UnlockUser(user);
        }
    }
}
