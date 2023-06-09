using System;
using CSharpProject.Forms;
using CSharpProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CSharpProject
{
    [TestClass]
    public class Booking_Formtest
    {
        public Booking_Form _bookingForm;
        public Droos _context;

        public Booking_Formtest()
        {
            _bookingForm = new Booking_Form();
            _context = new Droos();
        }

        [Test]
        public void ComboBox2_SelectedIndexChanged_ShouldPopulateComboBox1WithStudents()
        {
            // Arrange
            string teacherName = "mohamed yahyia";
            string educationStage = "Primary";
            int level = 1;
            _bookingForm.comboBox2.Items.Add(teacherName);

            // Create and add a teacher with matching information
            var teacher = new Teacher
            {
                Name = teacherName,
                Education_Stage = educationStage,
                Level = level
            };
            _context.Teachers.Add(teacher);

            // Create and add a student with matching information
            var student = new Student
            {
                Name = "ali ahmed",
                Education_Stage = educationStage,
                Level = level
            };
            _context.Students.Add(student);

            // Act
            _bookingForm.comboBox2.SelectedIndex = 0;
            _bookingForm.comboBox2_SelectedIndexChanged(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(_bookingForm.comboBox1.Items, Contains.Item(student.Name));
        }

        [Test]
        public void Button3_Click_ShouldDecreaseLessonCapacityAndAddBooking()
        {
            // Arrange
            string teacherName = "mohamed yahyia";
            string educationStage = "Primary";
            int level = 1;
            _bookingForm.comboBox2.Items.Add(teacherName);

            // Create and add a teacher with matching information
            var teacher = new Teacher
            {
                Name = teacherName,
                Education_Stage = educationStage,
                Level = level
            };
            _context.Teachers.Add(teacher);

            // Create and add a student
            var student = new Student
            {
                Name = "ali ahmed",
                Education_Stage = educationStage,
                Level = level
            };
            _context.Students.Add(student);

            // Create and add a lesson with matching information
            var lesson = new Lesson
            {
                TeacherId = teacher.TeacherId,
                Day = "Monday",
                Start_Time = "09:00",
                Capacity = 1,
                Hall = new Hall { HallNo = 1 }
            };
            _context.Lessons.Add(lesson);

            // Set up UI controls
            _bookingForm.comboBox2.SelectedIndex = 0;
            _bookingForm.comboBox1.SelectedIndex = 0;
            _bookingForm.textBox1.Text = lesson.Day;
            _bookingForm.textBox2.Text = lesson.Start_Time;
            _bookingForm.textBox3.Text = lesson.Hall.HallNo.ToString();

            // Act
            _bookingForm.button3_Click(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(0, lesson.Capacity);
            Assert.AreEqual(_context.Bookings, Has.Exactly(1).Items);
            Assert.AreEqual(_context.Bookings, Has.Exactly(1).Property("StudentId").EqualTo(student.StudentID));
        }

    }
}
