using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProject
{
    [TestClass]
    public class Home_FormTests
    {

        private Home_Form _homeForm;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the form
            _homeForm = new Home_Form();
        }

        [Test]
        public void Loginbtn_Click_ValidCredentials_OpenDashboardForm()
        {
            // Arrange
            _homeForm.Usernametxt.Text = "Admin";
            _homeForm.Passwordtxt.Text = "admin";

            // Act
            _homeForm.Loginbtn_Click(null, null);

            // Assert
            // Verify that the Dashboard form is opened
            Assert.IsTrue(_homeForm.OwnedForms.Length > 0);
            Assert.IsInstanceOf(typeof(DashBoard_Form), _homeForm.OwnedForms[0]);

        }

        [Test]
        public void Loginbtn_Click_InvalidCredentials_ShowErrorMessage()
        {
            // Arrange
            _homeForm.Usernametxt.Text = "InvalidUser";
            _homeForm.Passwordtxt.Text = "InvalidPassword";

            // Act
            _homeForm.Loginbtn_Click(null, null);

            // Assert
            // Verify that an error message is shown in a MessageBox
            
        }

        [Test]
        public void Loginbtn_Click_EmptyCredentials_ShowErrorMessage()
        {
            // Arrange
            _homeForm.Usernametxt.Text = "";
            _homeForm.Passwordtxt.Text = "";

            // Act
            _homeForm.Loginbtn_Click(null, null);

            // Assert
            // Verify that an error message is shown in a MessageBox

        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the form
            _homeForm.Dispose();
        }
    }
}
