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
    public partial class Student_Form : Form
    {
        public Droos _context;
        public Student_Form()
        {
            InitializeComponent();
            _context = new Droos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.SelectedIndex = -1;
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2) 
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("2");
                comboBox2.Items.Add("3");
            }
            else
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("1");
                comboBox2.Items.Add("2");
                comboBox2.Items.Add("3");
                comboBox2.Items.Add("4");
                comboBox2.Items.Add("5");
                comboBox2.Items.Add("6");
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text!=""&&comboBox1.Text != "" &&comboBox2.Text !="")
                try
                {
                    var students = _context.Students.ToList();
                    Student student = new Student()
                    {
                        Name = textBox1.Text,
                        Phone = textBox2.Text,
                        Education_Stage = comboBox1.Text,
                        Level = int.Parse(comboBox2.Text)
                    };
                    bool exist = false;
                    foreach (var item in students)
                    {
                        if (item.Phone == student.Phone)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        _context.Students.Add(student);
                        _context.SaveChanges();
                        MessageBox.Show("Student added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student is already signed", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Data is NOT correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {
                MessageBox.Show("Data is NOT correct", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
