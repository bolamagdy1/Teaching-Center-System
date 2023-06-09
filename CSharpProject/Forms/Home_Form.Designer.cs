namespace CSharpProject
{
    partial class Home_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Form));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Passwordtxt = new System.Windows.Forms.TextBox();
            this.Usernametxt = new System.Windows.Forms.TextBox();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.Passwordlbl = new System.Windows.Forms.Label();
            this.Usernamelbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1423, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(73, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(774, 510);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Passwordtxt);
            this.groupBox1.Controls.Add(this.Usernametxt);
            this.groupBox1.Controls.Add(this.Loginbtn);
            this.groupBox1.Controls.Add(this.Passwordlbl);
            this.groupBox1.Controls.Add(this.Usernamelbl);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(961, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 370);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please Login";
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.Location = new System.Drawing.Point(40, 227);
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.Size = new System.Drawing.Size(253, 36);
            this.Passwordtxt.TabIndex = 1;
            this.Passwordtxt.UseSystemPasswordChar = true;
            this.Passwordtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Usernametxt
            // 
            this.Usernametxt.Location = new System.Drawing.Point(40, 112);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.Size = new System.Drawing.Size(253, 36);
            this.Usernametxt.TabIndex = 0;
            // 
            // Loginbtn
            // 
            this.Loginbtn.BackColor = System.Drawing.Color.DarkBlue;
            this.Loginbtn.ForeColor = System.Drawing.Color.White;
            this.Loginbtn.Location = new System.Drawing.Point(40, 291);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(253, 52);
            this.Loginbtn.TabIndex = 2;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = false;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // Passwordlbl
            // 
            this.Passwordlbl.AutoSize = true;
            this.Passwordlbl.Location = new System.Drawing.Point(35, 180);
            this.Passwordlbl.Name = "Passwordlbl";
            this.Passwordlbl.Size = new System.Drawing.Size(124, 29);
            this.Passwordlbl.TabIndex = 1;
            this.Passwordlbl.Text = "Password";
            // 
            // Usernamelbl
            // 
            this.Usernamelbl.AutoSize = true;
            this.Usernamelbl.Location = new System.Drawing.Point(35, 68);
            this.Usernamelbl.Name = "Usernamelbl";
            this.Usernamelbl.Size = new System.Drawing.Size(141, 29);
            this.Usernamelbl.TabIndex = 0;
            this.Usernamelbl.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(600, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(472, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Center Management System";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(733, 811);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Designed by C# Teaam";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1500, 850);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Center";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox Passwordtxt;
        public System.Windows.Forms.TextBox Usernametxt;
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.Label Passwordlbl;
        private System.Windows.Forms.Label Usernamelbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

