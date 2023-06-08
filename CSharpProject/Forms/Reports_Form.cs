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
    public partial class Reports_Form : Form
    {
        Droos _context;
        public enum subjects { English, Arabic };
        public int[] arr = { 1, 2, 3, 4, 5, 6 };
        public Reports_Form()
        {
            InitializeComponent();
            _context = new Droos();
        }

        private void Reports_Form_Load(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            foreach (var item in Enum.GetValues(typeof(subjects)))
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.Enabled = true;
            var teachers = _context.Teachers.Where(t => t.Subject == comboBox1.Text).ToList();
            foreach (var teacher in teachers)
            {
                comboBox2.Items.Add(teacher.Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                var teacher = _context.Teachers.Where(t => t.Name == comboBox2.Text).FirstOrDefault();
                textBox5.Text = teacher.Level.ToString();
                var lesson = _context.Lessons.Where(t => t.TeacherId == teacher.TeacherId).FirstOrDefault();
                textBox1.Text = lesson.Day;
                textBox2.Text = lesson.Start_Time;
                var students = _context.Bookings.Include(s => s.Student).Where(t => t.TeacherId == teacher.TeacherId).ToList();
                textBox4.Text = students.Count.ToString();
                var hall = _context.Halls.Where(h => h.HallId == lesson.HallId).FirstOrDefault();
                textBox3.Text = (hall.Capacity - students.Count).ToString();
                foreach (var student in students)
                {
                    dataGridView1.Rows.Add(student.Student.Name);
                }
            }
            catch
            {
                MessageBox.Show("No Lessons for this Subject","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
