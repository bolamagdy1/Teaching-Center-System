using System;
using CSharpProject.Forms;
using CSharpProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CSharpProject
{
    [TestClass]
    public class Teacher_FormTest1
    {
        

    public Teacher_Form _teacherForm;
    public Droos _context;
        public Teacher_FormTest1()
        {
            _teacherForm = new Teacher_Form();
            _context = new Droos();
        }

        [SetUp]
    public void Setup()
    {
        // Create an instance of the form
        _teacherForm = new Teacher_Form();
        _context = new Droos();
    }
 [TestMethod]
    public void button2_Click_ValidData_AddTeacherAndShowSuccessMessage()
    {
        // Arrange
        // Set valid data on the form
        _teacherForm.textBox1.Text = "ali mohamed";
        _teacherForm.textBox2.Text = "12345678901";
        _teacherForm.comboBox1.SelectedIndex = 0; // Set the first item as selected
        _teacherForm.comboBox2.SelectedIndex = 0; // Set the first item as selected
        _teacherForm.comboBox3.SelectedIndex = 0; // Set the first item as selected
        _teacherForm.comboBox4.SelectedIndex = 1; // Set the second item as selected
        _teacherForm.comboBox6.SelectedIndex = 0; // Set the first item as selected
        _teacherForm.comboBox5.SelectedIndex = 0; // Set the first item as selected

        // Act
        _teacherForm.button2_Click(null, null);

        // Assert
        // Verify that the teacher is added to the context and a success message is shown in a MessageBox
        var addedTeacher = _context.Teachers.FirstOrDefault(t => t.Name == "ali mohamed");
        Assert.IsNotNull(addedTeacher);
        Assert.AreEqual("ali mohamed", addedTeacher.Name);
        Assert.AreEqual("12345678901", addedTeacher.Phone);
        Assert.AreEqual("English", addedTeacher.AvailableDay);
        Assert.AreEqual("English", addedTeacher.Subject);
        Assert.AreEqual("Primary", addedTeacher.Education_Stage);
        Assert.AreEqual(1, addedTeacher.Level);
        //Assert.AreEqual("Teacher added Successfully", GetMessageBoxText());

        // Remember to dispose of the context and form after the test
    }

     [TestMethod]
    public void button2_Click_InvalidData_ShowErrorMessage()
    {
        // Arrange
        // Set invalid data on the form (e.g., empty text boxes)
        _teacherForm.textBox1.Text = "";
        _teacherForm.textBox2.Text = "";
        _teacherForm.comboBox1.SelectedIndex = -1;
        _teacherForm.comboBox2.SelectedIndex = -1;
        _teacherForm.comboBox3.SelectedIndex = -1;
        _teacherForm.comboBox4.SelectedIndex = -1;
        _teacherForm.comboBox6.SelectedIndex = -1;
        _teacherForm.comboBox5.SelectedIndex = -1;

        // Act
        _teacherForm.button2_Click(null, null);

        // Assert
        // Verify that an error message is shown in a MessageBox
        //Assert.AreEqual("Data is Not correct", GetMessageBoxText());

        // Remember to dispose of the form after the test
    }

    [TearDown]
    public void TearDown()
    {
        // Dispose of the form
        _teacherForm.Dispose();
    }
       
     
    }
}
