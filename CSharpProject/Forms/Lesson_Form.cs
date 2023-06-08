using CSharpProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpProject.Forms
{
    public partial class Lesson_Form : Form
    {
        Droos _context;
        public Lesson_Form()
        {
            InitializeComponent();
            _context = new Droos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lesson_Form_Load(object sender, EventArgs e)
        {
            var teachers = _context.Teachers.ToList();
            var halls = _context.Halls.ToList();
            foreach (var teacher in teachers)
            {
                comboBox1.Items.Add(teacher.Name);
            }
            foreach (var hall in halls)
            {
                comboBox2.Items.Add(hall.HallNo);
            }
            comboBox4.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Name == comboBox1.Text);
            textBox1.Text = teacher.AvailableDay;
            var temp = comboBox4;
            comboBox4.Enabled = true;
            for(int i =0;teacher.AvailableTime_Start!=comboBox4.Items[i].ToString();i++)
            {
                temp.Items.Remove(comboBox4.Items[i]);
            }
            for(int i = comboBox4.Items.Count-1; teacher.AvailableTime_End != comboBox4.Items[i].ToString(); i--)
            {
                temp.Items.Remove(comboBox4.Items[i]);
            }
            comboBox4.Items.RemoveAt(comboBox4.Items.Count - 1);
            comboBox4.Items.RemoveAt(comboBox4.Items.Count - 1);

            comboBox4.Text = comboBox4.Items[0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var teacher = _context.Teachers.FirstOrDefault(t => t.Name == comboBox1.Text);
                int no = int.Parse(comboBox2.Text);
                var hall = _context.Halls.FirstOrDefault(h=>h.HallNo == no);
                Lesson lesson = new Lesson()
                {
                    TeacherId = teacher.TeacherId,
                    HallId = hall.HallId,
                    Day = textBox1.Text,
                    Start_Time = comboBox4.Text,
                    Capacity = hall.Capacity,
                };
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                MessageBox.Show("Lesson added Successfully","Done",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Data is NOT correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
