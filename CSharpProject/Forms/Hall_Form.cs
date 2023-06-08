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
    public partial class Hall_Form : Form
    {
        Droos _context;
        public Hall_Form()
        {
            InitializeComponent();
            _context = new Droos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var hall = new Hall() { HallNo = int.Parse(textBox1.Text), Capacity = int.Parse(textBox2.Text) };
                _context.Halls.Add(hall);
                _context.SaveChanges();
                MessageBox.Show("Hall added Successfully", "done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Data is NOT correct", "sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
