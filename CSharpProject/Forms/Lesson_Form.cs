using CSharpProject.Models;
using RestSharp;
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

        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var teacher = _context.Teachers.FirstOrDefault(t => t.Name == comboBox1.Text);
                int no = int.Parse(comboBox2.Text);
                var hall = _context.Halls.FirstOrDefault(h => h.HallNo == no);
                Lesson lesson = new Lesson()
                {
                    TeacherId = teacher.TeacherId,
                    HallId = hall.HallId,
                    Day = textBox1.Text,
                    Start_Time = comboBox4.Text,
                    Capacity = hall.Capacity,
                };
                bool exist = false;
                var lessons = _context.Lessons.Include(h => h.Hall).ToList();
                foreach (var item in lessons)
                {
                    if (item.HallId == lesson.HallId && item.Day == lesson.Day && item.Start_Time == lesson.Start_Time)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    _context.Lessons.Add(lesson);
                    _context.SaveChanges();
                    MessageBox.Show("Lesson added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Whatsapp_Send(teacher.Phone, teacher.Name, lesson.Day, lesson.Start_Time, hall.HallNo);
                }
                else
                {
                    MessageBox.Show("hall or day or time is conflict", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Data is NOT correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void Whatsapp_Send(string phone, string name, string day, string time, int hall)
        {
            phone = "+2" + phone;
            var url = "https://api.ultramsg.com/instance50173/messages/chat";
            var client = new RestClient(url);

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", "gqq0e45l04jsuyxj");
            request.AddParameter("to", phone);
            request.AddParameter("body", $"Hello Dear {name}.\nWe Successfully Create a Lesson in Drooos System on {day} at {time} in Hall number {hall}.\nWish You All the Best :)");


            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            Console.WriteLine(output);
        }
    }
}
