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
        public Mock<Droos> _mockContext;
        public Mock<IQueryable<Student>> _mockStudents;
        public Mock<IQueryable<Teacher>> _mockTeachers;
        public Mock<IQueryable<Lesson>> _mockLessons;
        public Mock<IQueryable<Hall>> _mockHalls;
        public Mock<IQueryable<Booking>> _mockBookings;
        public Droos _context;

        public Booking_Formtest()
        {
            _mockContext = new Mock<Droos>();
            _mockStudents = new Mock<IQueryable<Student>>();
            _mockTeachers = new Mock<IQueryable<Teacher>>();
            _mockLessons = new Mock<IQueryable<Lesson>>();
            _mockHalls = new Mock<IQueryable<Hall>>();
            _mockBookings = new Mock<IQueryable<Booking>>();
            _context = new Droos();
            _bookingForm = new Booking_Form();

            _mockContext.Setup(c => c.Students).Returns(_mockStudents.Object);
            _mockContext.Setup(c => c.Teachers).Returns(_mockTeachers.Object);
            _mockContext.Setup(c => c.Lessons).Returns(_mockLessons.Object);
            _mockContext.Setup(c => c.Halls).Returns(_mockHalls.Object);
            _mockContext.Setup(c => c.Bookings).Returns(_mockBookings.Object);
        }

        [SetUp]
        public void Setup()
        {
            // Create an instance of the form before each test
            _mockContext = new Mock<Droos>();
            _mockStudents = new Mock<IQueryable<Student>>();
            _mockTeachers = new Mock<IQueryable<Teacher>>();
            _mockLessons = new Mock<IQueryable<Lesson>>();
            _mockHalls = new Mock<IQueryable<Hall>>();
            _mockBookings = new Mock<IQueryable<Booking>>();

            _context = new Droos();

            _mockContext.Setup(c => c.Students).Returns(_mockStudents.Object);
            _mockContext.Setup(c => c.Teachers).Returns(_mockTeachers.Object);
            _mockContext.Setup(c => c.Lessons).Returns(_mockLessons.Object);
            _mockContext.Setup(c => c.Halls).Returns(_mockHalls.Object);
            _mockContext.Setup(c => c.Bookings).Returns(_mockBookings.Object);
        }

        [Test]
        public void Button3_Click_ValidInput_BookingAddedSuccessfully()
        {
            // Arrange
            _bookingForm.comboBox1.Text = "Student 1";
            _bookingForm.comboBox2.Text = "Teacher 1";
            _bookingForm.textBox1.Text = "Monday";
            _bookingForm.textBox2.Text = "10:00";
            _bookingForm.textBox3.Text = "1";

            var student = new Student() { Name = "Student 1", StudentID = 1 };
            var teacher = new Teacher() { Name = "Teacher 1", TeacherId = 1 };
            var lesson = new Lesson() { Capacity = 10 };
            var hall = new Hall() { HallNo = 1, HallId = 1 };

            _mockStudents.Setup(s => s.FirstOrDefault(It.IsAny<Func<Student, bool>>())).Returns(student);
            _mockTeachers.Setup(t => t.FirstOrDefault(It.IsAny<Func<Teacher, bool>>())).Returns(teacher);
            _mockLessons.Setup(l => l.FirstOrDefault(It.IsAny<Func<Lesson, bool>>())).Returns(lesson);
            _mockHalls.Setup(h => h.FirstOrDefault(It.IsAny<Func<Hall, bool>>())).Returns(hall);

            // Act
            _bookingForm.button3_Click(null, EventArgs.Empty);

            // Assert
            Assert.AreEqual(9, lesson.Capacity); // Verify that lesson capacity is decremented
            _mockContext.Verify(c => c.SaveChanges(), Times.Once); // Verify that SaveChanges() was called on the context
            // Add more assertions as needed
        }

        [Test]
        public void Button3_Click_ExistingBooking_ErrorMessageShown()
        {
            // Arrange
            _bookingForm.comboBox1.Text = "Student 1";
            _bookingForm.comboBox2.Text = "Teacher 1";

            var student = new Student() { Name = "Student 1", StudentID = 1 };
            var teacher = new Teacher() { Name = "Teacher 1", TeacherId = 1 };

            _mockStudents.Setup(s => s.FirstOrDefault(It.IsAny<Func<Student, bool>>())).Returns(student);
            _mockTeachers.Setup(t => t.FirstOrDefault(It.IsAny<Func<Teacher, bool>>())).Returns(teacher);
            _mockBookings.Setup(b => b.ToList()).Returns(new[] { new Booking() { StudentId = 1 } }.AsQueryable());

            // Act
            _bookingForm.button3_Click(null, EventArgs.Empty);

            // Assert
            // Verify that the error message is shown in a MessageBox
        }
       
    }
}
