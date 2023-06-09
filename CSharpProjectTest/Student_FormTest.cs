using System;
using CSharpProject.Forms;
using CSharpProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CSharpProject
{
    [TestClass]
    public class Student_FormTest
    {
        private Student_Form _studentForm;
        private Droos _context;
        public Student_FormTest()
        {
            _studentForm = new Student_Form();
            _context = new Droos();
        }

        [TestMethod]
        public void button2_Click_ValidData_AddStudentAndShowSuccessMessage()
        {
            // Arrange
            // Set valid data on the form
            _studentForm.textBox1.Text = "ali mohamed";
            _studentForm.textBox2.Text = "1234567890";
            _studentForm.comboBox1.SelectedIndex = 0; // Set the first item as selected
            _studentForm.comboBox2.SelectedIndex = 1; // Set the second item as selected

            // Act
            _studentForm.button2_Click(null, null);

            // Assert
            // Verify that the student is added to the context and a success message is shown in a MessageBox
            var addedStudent = _context.Students.FirstOrDefault(s => s.Name == "ali mohamed");
            Assert.IsNotNull(addedStudent);
            Assert.AreEqual("ali mohamed", addedStudent.Name);
            Assert.AreEqual("1234567890", addedStudent.Phone);
            Assert.AreEqual("English", addedStudent.Education_Stage);
            Assert.AreEqual(2, addedStudent.Level);
            Assert.AreEqual("Student added Successfully", GetMessageBoxText());

            // Remember to dispose of the context and form after the test
        }

        [Test]
        public void button2_Click_InvalidData_ShowErrorMessage()
        {
            // Arrange
            // Set invalid data on the form (empty text boxes and no selected items)
            _studentForm.textBox1.Text = "";
            _studentForm.textBox2.Text = "";
            _studentForm.comboBox1.SelectedIndex = -1;
            _studentForm.comboBox2.SelectedIndex = -1;

            // Act
            _studentForm.button2_Click(null, null);

            // Assert
            // Verify that an error message is shown in a MessageBox
            Assert.AreEqual("Data is NOT correct", GetMessageBoxText());

        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the form
            _studentForm.Dispose();
        }
    }
}
