using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeLouisvilleUTProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserLogin_CheckValidCredential_ReturnTrue()
        {
            //Arrange
            IUserInfo user = new CodeLouisvilleUser();
            string username = "John";
            string password = "Pa$$w0rd";
            //Act
            bool isValidUser= user.CheckCredential( username,  password);
            //Assert
            Assert.IsTrue(isValidUser, "It is a valid User");
        }

        [TestMethod]
        public void UserLogin_CheckValidCredential_ReturnFalse()
        {
            //Arrange
            IUserInfo user = new CodeLouisvilleUser();
            string username = "";
            string password = "Pa$$w0rd";
            //Act
            bool isNotaValidUser = user.CheckCredential(username, password);
            //Assert
            Assert.IsFalse(isNotaValidUser, "");
        }

        [TestMethod]
        public void UserLogin_CheckLoginAttempt_LockUserOn3Try()
        {
            //Arrange
            IUserInfo user = new CodeLouisvilleUser();
            user.NoOfAttempt = 3;
            //Act
            bool isLocked = user.IsUserLocked();

            //Assert
            Assert.IsTrue(isLocked, "Is Locked");
        }


    }
}
