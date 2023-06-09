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
    public partial class DashBoard_Form : Form
    {
        int panelWidth;
        bool Hidden;
        public DashBoard_Form()
        {
            InitializeComponent();
            panelWidth = panelLeft.Width;
            Hidden = false;
            timer2.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 55)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void slidePanel(Button btn)
        {
            panelSide.Height = btn.Height;
            panelSide.Top = btn.Top;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        { 
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString("hh:mm:ss");
        }

        private void btnContractors_Click(object sender, EventArgs e)
        {
            Hall_Form hall = new Hall_Form();
            hall.ShowDialog();
        }

        private void btnWorks_Click(object sender, EventArgs e)
        {
            Teacher_Form teacher = new Teacher_Form();
            teacher.ShowDialog();
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            Student_Form student = new Student_Form();
            student.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Lesson_Form lesson = new Lesson_Form();
            lesson.ShowDialog();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            Booking_Form booking = new Booking_Form();
            booking.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports_Form reports = new Reports_Form();
            reports.ShowDialog();
        }
    }
}
