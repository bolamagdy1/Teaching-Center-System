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
    public partial class Teacher_Form : Form
    {
        Droos _context;

        public enum subjects { English, Arabic };
        public Teacher_Form()
        {
            InitializeComponent();
            _context = new Droos();
            foreach (var item in Enum.GetValues(typeof(subjects)))
            {
                comboBox2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox6.Text = comboBox6.Items[0].ToString();
            comboBox4.Enabled = false;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            var teachers = _context.Teachers.ToList();
            if (!(textBox1.Text.Length < 5 || textBox2.Text.Length != 11 || comboBox4.Text == ""))
            {
                var teacher = new Teacher()
                {
                    Name = textBox1.Text,
                    Phone = textBox2.Text,
                    AvailableDay = comboBox1.Text,
                    AvailableTime_Start = comboBox3.Text,
                    AvailableTime_End = comboBox4.Text,
                    Subject = comboBox2.Text,
                    Education_Stage = comboBox6.Text,
                    Level = int.Parse(comboBox5.Text),
                };
                bool exist = false;
                foreach (var item in teachers)
                {
                    if (item.Phone == teacher.Phone)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    _context.Teachers.Add(teacher);
                    _context.SaveChanges();
                    MessageBox.Show("Teacher added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Teacher is already signed", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Data is Not correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Enabled = true;
            for(int i =comboBox3.SelectedIndex+1;i<comboBox3.Items.Count; i++)
            {
                comboBox4.Items.Add(comboBox3.Items[i]);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            if (comboBox6.Text == "Primary")
            {
                for (int i = 0; i < arr.Length; i++)
                    comboBox5.Items.Add(arr[i]);
            }
            else
                for (int i = 0; i < 3; i++)
                    comboBox5.Items.Add(arr[i]);
            comboBox5.Text = comboBox5.Items[0].ToString();
        }
    }
}
