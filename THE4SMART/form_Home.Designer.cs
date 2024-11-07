namespace THE4SMART
{
    partial class form_Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Home));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_SignUp = new System.Windows.Forms.Button();
            this.btn_SignIn = new System.Windows.Forms.Button();
            this.panel_SignIn = new System.Windows.Forms.Panel();
            this.llb_ReturnFromSignIn = new System.Windows.Forms.LinkLabel();
            this.llb_SignUp = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SignInUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SignInPassword = new System.Windows.Forms.TextBox();
            this.btn_SignIn2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_SignUp = new System.Windows.Forms.Panel();
            this.btn_Escape3 = new System.Windows.Forms.PictureBox();
            this.llb_ReturnFromSignUp = new System.Windows.Forms.LinkLabel();
            this.llbSignIn = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SignUpUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_SignUpPassword = new System.Windows.Forms.TextBox();
            this.btn_SignUpNext = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_SignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_SignUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Escape3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(180, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(360, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_SignUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.btn_SignUp.FlatAppearance.BorderSize = 0;
            this.btn_SignUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SignUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SignUp.Font = new System.Drawing.Font("Yu Gothic UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignUp.ForeColor = System.Drawing.Color.White;
            this.btn_SignUp.Location = new System.Drawing.Point(285, 270);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(150, 50);
            this.btn_SignUp.TabIndex = 23;
            this.btn_SignUp.Text = "MANAGER";
            this.btn_SignUp.UseVisualStyleBackColor = false;
            this.btn_SignUp.Click += new System.EventHandler(this.btn_SignUp_Click);
            // 
            // btn_SignIn
            // 
            this.btn_SignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.btn_SignIn.FlatAppearance.BorderSize = 0;
            this.btn_SignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SignIn.Font = new System.Drawing.Font("Yu Gothic UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignIn.ForeColor = System.Drawing.Color.White;
            this.btn_SignIn.Location = new System.Drawing.Point(285, 200);
            this.btn_SignIn.Name = "btn_SignIn";
            this.btn_SignIn.Size = new System.Drawing.Size(150, 50);
            this.btn_SignIn.TabIndex = 22;
            this.btn_SignIn.Text = "SIGN IN";
            this.btn_SignIn.UseVisualStyleBackColor = false;
            this.btn_SignIn.Click += new System.EventHandler(this.btn_SignIn_Click);
            // 
            // panel_SignIn
            // 
            this.panel_SignIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_SignIn.BackgroundImage")));
            this.panel_SignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_SignIn.Controls.Add(this.panel_SignUp);
            this.panel_SignIn.Controls.Add(this.llb_ReturnFromSignIn);
            this.panel_SignIn.Controls.Add(this.llb_SignUp);
            this.panel_SignIn.Controls.Add(this.label2);
            this.panel_SignIn.Controls.Add(this.label4);
            this.panel_SignIn.Controls.Add(this.txt_SignInUsername);
            this.panel_SignIn.Controls.Add(this.label5);
            this.panel_SignIn.Controls.Add(this.txt_SignInPassword);
            this.panel_SignIn.Controls.Add(this.btn_SignIn2);
            this.panel_SignIn.Controls.Add(this.pictureBox1);
            this.panel_SignIn.Location = new System.Drawing.Point(12, 12);
            this.panel_SignIn.Name = "panel_SignIn";
            this.panel_SignIn.Size = new System.Drawing.Size(720, 480);
            this.panel_SignIn.TabIndex = 24;
            this.panel_SignIn.Visible = false;
            // 
            // llb_ReturnFromSignIn
            // 
            this.llb_ReturnFromSignIn.AutoSize = true;
            this.llb_ReturnFromSignIn.BackColor = System.Drawing.Color.Transparent;
            this.llb_ReturnFromSignIn.LinkColor = System.Drawing.Color.Black;
            this.llb_ReturnFromSignIn.Location = new System.Drawing.Point(20, 20);
            this.llb_ReturnFromSignIn.Name = "llb_ReturnFromSignIn";
            this.llb_ReturnFromSignIn.Size = new System.Drawing.Size(46, 16);
            this.llb_ReturnFromSignIn.TabIndex = 34;
            this.llb_ReturnFromSignIn.TabStop = true;
            this.llb_ReturnFromSignIn.Text = "Return";
            this.llb_ReturnFromSignIn.VisitedLinkColor = System.Drawing.Color.Red;
            this.llb_ReturnFromSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_ReturnFromSignIn_LinkClicked);
            // 
            // llb_SignUp
            // 
            this.llb_SignUp.ActiveLinkColor = System.Drawing.Color.White;
            this.llb_SignUp.AutoSize = true;
            this.llb_SignUp.BackColor = System.Drawing.Color.Transparent;
            this.llb_SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llb_SignUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.llb_SignUp.Location = new System.Drawing.Point(327, 386);
            this.llb_SignUp.Name = "llb_SignUp";
            this.llb_SignUp.Size = new System.Drawing.Size(75, 20);
            this.llb_SignUp.TabIndex = 32;
            this.llb_SignUp.TabStop = true;
            this.llb_SignUp.Text = "Sign Up";
            this.llb_SignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_SignUp_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Create an account?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 29);
            this.label4.TabIndex = 30;
            this.label4.Text = "Password:";
            // 
            // txt_SignInUsername
            // 
            this.txt_SignInUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SignInUsername.Location = new System.Drawing.Point(277, 168);
            this.txt_SignInUsername.MaxLength = 32;
            this.txt_SignInUsername.Name = "txt_SignInUsername";
            this.txt_SignInUsername.Size = new System.Drawing.Size(304, 34);
            this.txt_SignInUsername.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(140, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Username:";
            // 
            // txt_SignInPassword
            // 
            this.txt_SignInPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SignInPassword.Location = new System.Drawing.Point(277, 229);
            this.txt_SignInPassword.MaxLength = 32;
            this.txt_SignInPassword.Name = "txt_SignInPassword";
            this.txt_SignInPassword.Size = new System.Drawing.Size(304, 34);
            this.txt_SignInPassword.TabIndex = 28;
            this.txt_SignInPassword.UseSystemPasswordChar = true;
            // 
            // btn_SignIn2
            // 
            this.btn_SignIn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.btn_SignIn2.FlatAppearance.BorderSize = 0;
            this.btn_SignIn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SignIn2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignIn2.ForeColor = System.Drawing.Color.White;
            this.btn_SignIn2.Location = new System.Drawing.Point(285, 291);
            this.btn_SignIn2.Name = "btn_SignIn2";
            this.btn_SignIn2.Size = new System.Drawing.Size(150, 50);
            this.btn_SignIn2.TabIndex = 23;
            this.btn_SignIn2.Text = "SIGN IN";
            this.btn_SignIn2.UseVisualStyleBackColor = false;
            this.btn_SignIn2.Click += new System.EventHandler(this.btn_SignIn2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(180, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // panel_SignUp
            // 
            this.panel_SignUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_SignUp.BackgroundImage")));
            this.panel_SignUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_SignUp.Controls.Add(this.btn_Escape3);
            this.panel_SignUp.Controls.Add(this.llb_ReturnFromSignUp);
            this.panel_SignUp.Controls.Add(this.llbSignIn);
            this.panel_SignUp.Controls.Add(this.label1);
            this.panel_SignUp.Controls.Add(this.label3);
            this.panel_SignUp.Controls.Add(this.txt_SignUpUsername);
            this.panel_SignUp.Controls.Add(this.label6);
            this.panel_SignUp.Controls.Add(this.txt_SignUpPassword);
            this.panel_SignUp.Controls.Add(this.btn_SignUpNext);
            this.panel_SignUp.Controls.Add(this.pictureBox3);
            this.panel_SignUp.Location = new System.Drawing.Point(23, 20);
            this.panel_SignUp.Name = "panel_SignUp";
            this.panel_SignUp.Size = new System.Drawing.Size(720, 480);
            this.panel_SignUp.TabIndex = 33;
            this.panel_SignUp.Visible = false;
            // 
            // btn_Escape3
            // 
            this.btn_Escape3.BackColor = System.Drawing.Color.Transparent;
            this.btn_Escape3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Escape3.BackgroundImage")));
            this.btn_Escape3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Escape3.Location = new System.Drawing.Point(661, 0);
            this.btn_Escape3.Name = "btn_Escape3";
            this.btn_Escape3.Size = new System.Drawing.Size(40, 40);
            this.btn_Escape3.TabIndex = 36;
            this.btn_Escape3.TabStop = false;
            this.btn_Escape3.Click += new System.EventHandler(this.btn_Escape3_Click);
            // 
            // llb_ReturnFromSignUp
            // 
            this.llb_ReturnFromSignUp.AutoSize = true;
            this.llb_ReturnFromSignUp.BackColor = System.Drawing.Color.Transparent;
            this.llb_ReturnFromSignUp.LinkColor = System.Drawing.Color.Black;
            this.llb_ReturnFromSignUp.Location = new System.Drawing.Point(20, 20);
            this.llb_ReturnFromSignUp.Name = "llb_ReturnFromSignUp";
            this.llb_ReturnFromSignUp.Size = new System.Drawing.Size(46, 16);
            this.llb_ReturnFromSignUp.TabIndex = 35;
            this.llb_ReturnFromSignUp.TabStop = true;
            this.llb_ReturnFromSignUp.Text = "Return";
            this.llb_ReturnFromSignUp.VisitedLinkColor = System.Drawing.Color.Red;
            this.llb_ReturnFromSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_ReturnFromSignUp_LinkClicked);
            // 
            // llbSignIn
            // 
            this.llbSignIn.ActiveLinkColor = System.Drawing.Color.White;
            this.llbSignIn.AutoSize = true;
            this.llbSignIn.BackColor = System.Drawing.Color.Transparent;
            this.llbSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSignIn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.llbSignIn.Location = new System.Drawing.Point(327, 374);
            this.llbSignIn.Name = "llbSignIn";
            this.llbSignIn.Size = new System.Drawing.Size(67, 20);
            this.llbSignIn.TabIndex = 32;
            this.llbSignIn.TabStop = true;
            this.llbSignIn.Text = "Sign In";
            this.llbSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSignIn_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Already have an account?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "Password:";
            // 
            // txt_SignUpUsername
            // 
            this.txt_SignUpUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SignUpUsername.Location = new System.Drawing.Point(277, 168);
            this.txt_SignUpUsername.MaxLength = 32;
            this.txt_SignUpUsername.Name = "txt_SignUpUsername";
            this.txt_SignUpUsername.Size = new System.Drawing.Size(304, 34);
            this.txt_SignUpUsername.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(140, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 29);
            this.label6.TabIndex = 29;
            this.label6.Text = "Username:";
            // 
            // txt_SignUpPassword
            // 
            this.txt_SignUpPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SignUpPassword.Location = new System.Drawing.Point(277, 229);
            this.txt_SignUpPassword.MaxLength = 32;
            this.txt_SignUpPassword.Name = "txt_SignUpPassword";
            this.txt_SignUpPassword.Size = new System.Drawing.Size(304, 34);
            this.txt_SignUpPassword.TabIndex = 28;
            this.txt_SignUpPassword.UseSystemPasswordChar = true;
            // 
            // btn_SignUpNext
            // 
            this.btn_SignUpNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.btn_SignUpNext.FlatAppearance.BorderSize = 0;
            this.btn_SignUpNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SignUpNext.Font = new System.Drawing.Font("Yu Gothic UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignUpNext.ForeColor = System.Drawing.Color.White;
            this.btn_SignUpNext.Location = new System.Drawing.Point(285, 291);
            this.btn_SignUpNext.Name = "btn_SignUpNext";
            this.btn_SignUpNext.Size = new System.Drawing.Size(150, 50);
            this.btn_SignUpNext.TabIndex = 23;
            this.btn_SignUpNext.Text = "NEXT";
            this.btn_SignUpNext.UseVisualStyleBackColor = false;
            this.btn_SignUpNext.Click += new System.EventHandler(this.btn_SignUpNext_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(180, 50);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(360, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // form_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(702, 433);
            this.Controls.Add(this.panel_SignIn);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.btn_SignIn);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form_Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.form_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_SignIn.ResumeLayout(false);
            this.panel_SignIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_SignUp.ResumeLayout(false);
            this.panel_SignUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Escape3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_SignUp;
        private System.Windows.Forms.Button btn_SignIn;
        private System.Windows.Forms.Panel panel_SignIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SignInUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SignInPassword;
        private System.Windows.Forms.Button btn_SignIn2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llb_SignUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_SignUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SignUpUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SignUpPassword;
        private System.Windows.Forms.Button btn_SignUpNext;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel llbSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llb_ReturnFromSignIn;
        private System.Windows.Forms.LinkLabel llb_ReturnFromSignUp;
        private System.Windows.Forms.PictureBox btn_Escape3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}

