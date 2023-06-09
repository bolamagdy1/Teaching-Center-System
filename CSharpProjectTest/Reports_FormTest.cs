using System;
using CSharpProject.Forms;
using CSharpProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CSharpProject
{
    [TestClass]
    public class Reports_FormTest
    {
        public Reports_Form _reportsForm;
        public Droos _context;

        public Reports_FormTest()
        {
            _reportsForm = new Reports_Form();
            _context = new Droos();
        }
        [SetUp]
        public void Setup()
        {
            // Create an instance of the form
            _reportsForm = new Reports_Form();
            _context = new Droos();
        }

        [Test]
        public void comboBox2_SelectedIndexChanged_ValidData_PopulateFieldsAndDataGridView()
        {
            // Arrange
            // Add test data to the context (Teachers, Lessons, Bookings, Halls, and Students)
            var subject = Reports_Form.subjects.English.ToString();
            var teacher = new Teacher { Name = "mohamed", Subject = subject, Level = 1 };
            _context.Teachers.Add(teacher);

            var hall = new Hall { HallId = 1, Capacity = 50 };
            _context.Halls.Add(hall);

            var lesson = new Lesson { TeacherId = teacher.TeacherId, HallId = hall.HallId, Day = "Monday", Start_Time = "08:00" };
            _context.Lessons.Add(lesson);

            var student1 = new Student { Name = "omar" };
            var student2 = new Student { Name = "bola" };
            _context.Students.Add(student1);
            _context.Students.Add(student2);

            var booking1 = new Booking { TeacherId = teacher.TeacherId, StudentId = student1.StudentID };
            var booking2 = new Booking { TeacherId = teacher.TeacherId, StudentId = student2.StudentID };
            _context.Bookings.Add(booking1);
            _context.Bookings.Add(booking2);

            _context.SaveChanges();

            _reportsForm.comboBox1.Text = subject;
            _reportsForm.comboBox2.Text = teacher.Name;

            // Act
            _reportsForm.comboBox2_SelectedIndexChanged(null, null);

            // Assert
            // Verify that the fields and DataGridView are populated correctly based on the test data
            Assert.AreEqual(teacher.Level.ToString(), _reportsForm.textBox5.Text);
            Assert.AreEqual(lesson.Day, _reportsForm.textBox1.Text);
            Assert.AreEqual(lesson.Start_Time, _reportsForm.textBox2.Text);
            Assert.AreEqual("2", _reportsForm.textBox4.Text);
            Assert.AreEqual((hall.Capacity - 2).ToString(), _reportsForm.textBox3.Text);
            Assert.AreEqual(2, _reportsForm.dataGridView1.Rows.Count);

        }

        [Test]
        public void comboBox2_SelectedIndexChanged_NoLessonsForSubject_ShowErrorMessage()
        {
            // Arrange
            // Set invalid data on the form
            _reportsForm.comboBox1.Text = "InvalidSubject";

            // Act
            _reportsForm.comboBox2_SelectedIndexChanged(null, null);

            // Assert
            // Verify that an error message is shown in a MessageBox
            Assert.AreEqual("No Lessons for this Subject", GetMessageBoxText());

        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the form
            _reportsForm.Dispose();
        }
    }
}
