using CSharpProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpProject
{
    public partial class Home_Form : Form
    {
        public Home_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if(Usernametxt.Text != "" &&  Usernametxt.Text != "")
            {
                if(Usernametxt.Text == "Admin" && Passwordtxt.Text == "admin")
                {
                    DashBoard_Form dashBoard = new DashBoard_Form();
                    dashBoard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User Name or Password is NOT correct!try again", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User Name or Password is NOT correct! try again","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
