using CSharpProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpProject.Forms
{
    public partial class Booking_Form : Form
    {
        Droos _context;
        public Booking_Form()
        {
            InitializeComponent();
            _context = new Droos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Booking_Form_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            var teachers = _context.Teachers.ToList();
            foreach (var teacher in teachers)
            {
                comboBox2.Items.Add(teacher.Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox1.Enabled = true;

            var teacher = _context.Teachers.FirstOrDefault(t=>t.Name == comboBox2.Text);
            var students = _context.Students.Where(s=>s.Education_Stage == teacher.Education_Stage).Where(s=>s.Level == teacher.Level).ToList();
            foreach (var student in students)
            {
                comboBox1.Items.Add(student.Name);
            }
            textBox4.Text = teacher.Subject;
            var lesson = _context.Lessons.Include(l=>l.Hall).Include(l=>l.Teacher).FirstOrDefault(l => l.TeacherId == teacher.TeacherId);
            textBox3.Text = lesson.Hall.HallNo.ToString();
            textBox1.Text = lesson.Day;
            textBox2.Text = lesson.Start_Time;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                var student = _context.Students.FirstOrDefault(s => s.Name == comboBox1.Text);
                var teacher = _context.Teachers.FirstOrDefault(t => t.Name == comboBox2.Text);
                var lesson = _context.Lessons.Where(l => l.Day == textBox1.Text).Where(l => l.Start_Time == textBox2.Text).FirstOrDefault();

                int num = int.Parse(textBox3.Text);
                var hall = _context.Halls.FirstOrDefault(h => h.HallNo == num);
                try
                {
                    if (lesson.Capacity > 0)
                    {
                        lesson.Capacity--;
                        Booking booking = new Booking()
                        {
                            StudentId = student.StudentID,
                            TeacherId = teacher.TeacherId,
                            HallId = hall.HallId,
                            Day = textBox1.Text,
                            Time = textBox2.Text
                        };
                        bool exist = false;
                        var bookings = _context.Bookings.ToList();
                        foreach (var book in bookings)
                        {
                            if(student.StudentID == book.StudentId)
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (!exist)
                        {
                            _context.Bookings.Add(booking);
                            _context.SaveChanges();
                            MessageBox.Show("Booking Done Successfully", "done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Student is already Signed", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Data is NOT correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Data is NOT correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
