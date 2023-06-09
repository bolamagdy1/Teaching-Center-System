using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProject
{
    [TestClass]
    public class Lesson_FormTest
    {
        private Lesson_Form _lessonForm;
        private Droos _context;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the form
            _lessonForm = new Lesson_Form();
            _context = new Droos();
        }

        [Test]
        public void button2_Click_ValidData_AddLessonAndShowSuccessMessage()
        {
            // Arrange
            // Add test data to the context (Teachers and Halls)
            var teacher = new Teacher { Name = "mohamed", AvailableDay = "Monday", AvailableTime_Start = "08:00", AvailableTime_End = "12:00" };
            _context.Teachers.Add(teacher);

            var hall = new Hall { HallNo = 1, Capacity = 50 };
            _context.Halls.Add(hall);

            _context.SaveChanges();

            _lessonForm.comboBox1.Text = teacher.Name;
            _lessonForm.comboBox2.Text = hall.HallNo.ToString();
            _lessonForm.textBox1.Text = teacher.AvailableDay;
            _lessonForm.comboBox4.Text = teacher.AvailableTime_Start;

            // Act
            _lessonForm.button2_Click(null, null);

            // Assert
            // Verify that a lesson is added to the context and the success message is shown in a MessageBox
            Assert.AreEqual(1, _context.Lessons.Count());
            Assert.AreEqual("Lesson added Successfully", GetMessageBoxText());

        }

        [Test]
        public void button2_Click_InvalidData_ShowErrorMessage()
        {
            // Arrange
            // Set invalid data on the form
            _lessonForm.comboBox1.Text = "InvalidTeacher";
            _lessonForm.comboBox2.Text = "InvalidHall";
            _lessonForm.textBox1.Text = "InvalidDay";
            _lessonForm.comboBox4.Text = "InvalidTime";

            // Act
            _lessonForm.button2_Click(null, null);

            // Assert
            // Verify that an error message is shown in a MessageBox
            Assert.AreEqual("Data is NOT correct", GetMessageBoxText());

        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the form
            _lessonForm.Dispose();
        }
    }
}
