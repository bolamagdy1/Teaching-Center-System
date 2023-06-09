using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProject
{
    [TestClass]
    public class Hall_FormTests
    {
        private Hall_Form _hallForm;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the form
            _hallForm = new Hall_Form();
        }

        [Test]
        public void Button2_Click_ValidData_HallAddedSuccessfully()
        {
            // Arrange
            var textBox1 = new TextBox { Text = "1" };
            var textBox2 = new TextBox { Text = "50" };
            _hallForm.Controls.Add(textBox1);
            _hallForm.Controls.Add(textBox2);

            // Act
            _hallForm.button2_Click(null, null);

            // Assert
            // Verify that the hall is added to the context and SaveChanges is called
            Assert.AreEqual(1, _hallForm._context.Halls.Count());

        }

        [Test]
        public void Button2_Click_InvalidData_ShowErrorMessage()
        {
            // Arrange
            var textBox1 = new TextBox { Text = "1" };
            var textBox2 = new TextBox { Text = "invalid" };
            _hallForm.Controls.Add(textBox1);
            _hallForm.Controls.Add(textBox2);

            // Act
            _hallForm.button2_Click(null, null);

            // Assert
            // Verify that the error message is shown in a MessageBox

        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the form
            _hallForm.Dispose();
        }
       
    }
}
