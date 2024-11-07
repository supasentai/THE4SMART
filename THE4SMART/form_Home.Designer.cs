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
            this.btn_Manager = new System.Windows.Forms.Button();
            this.btn_SignIn = new System.Windows.Forms.Button();
            this.panel_SignIn = new System.Windows.Forms.Panel();
            this.llb_ReturnFromSignIn = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SignInUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SignInPassword = new System.Windows.Forms.TextBox();
            this.btn_SignIn2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel_Manager = new System.Windows.Forms.Panel();
            this.llb_ReturnFromManager = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ManagerUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ManagerPassword = new System.Windows.Forms.TextBox();
            this.btn_ManagerSignIn = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_Escape = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_SignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Manager.SuspendLayout();
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
            // btn_Manager
            // 
            this.btn_Manager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Manager.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.btn_Manager.FlatAppearance.BorderSize = 0;
            this.btn_Manager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Manager.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Manager.Font = new System.Drawing.Font("Yu Gothic UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Manager.ForeColor = System.Drawing.Color.White;
            this.btn_Manager.Location = new System.Drawing.Point(285, 270);
            this.btn_Manager.Name = "btn_Manager";
            this.btn_Manager.Size = new System.Drawing.Size(150, 50);
            this.btn_Manager.TabIndex = 23;
            this.btn_Manager.Text = "MANAGER";
            this.btn_Manager.UseVisualStyleBackColor = false;
            this.btn_Manager.Click += new System.EventHandler(this.btn_Manager_Click);
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
            this.panel_SignIn.Controls.Add(this.llb_ReturnFromSignIn);
            this.panel_SignIn.Controls.Add(this.label2);
            this.panel_SignIn.Controls.Add(this.label4);
            this.panel_SignIn.Controls.Add(this.txt_SignInUsername);
            this.panel_SignIn.Controls.Add(this.label5);
            this.panel_SignIn.Controls.Add(this.txt_SignInPassword);
            this.panel_SignIn.Controls.Add(this.btn_SignIn2);
            this.panel_SignIn.Controls.Add(this.pictureBox1);
            this.panel_SignIn.Location = new System.Drawing.Point(0, 0);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Staff - Sign In";
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
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel_Manager
            // 
            this.panel_Manager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Manager.BackgroundImage")));
            this.panel_Manager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_Manager.Controls.Add(this.llb_ReturnFromManager);
            this.panel_Manager.Controls.Add(this.label1);
            this.panel_Manager.Controls.Add(this.label3);
            this.panel_Manager.Controls.Add(this.txt_ManagerUsername);
            this.panel_Manager.Controls.Add(this.label6);
            this.panel_Manager.Controls.Add(this.txt_ManagerPassword);
            this.panel_Manager.Controls.Add(this.btn_ManagerSignIn);
            this.panel_Manager.Controls.Add(this.pictureBox3);
            this.panel_Manager.Location = new System.Drawing.Point(0, 0);
            this.panel_Manager.Name = "panel_Manager";
            this.panel_Manager.Size = new System.Drawing.Size(720, 480);
            this.panel_Manager.TabIndex = 35;
            this.panel_Manager.Visible = false;
            // 
            // llb_ReturnFromManager
            // 
            this.llb_ReturnFromManager.AutoSize = true;
            this.llb_ReturnFromManager.BackColor = System.Drawing.Color.Transparent;
            this.llb_ReturnFromManager.LinkColor = System.Drawing.Color.Black;
            this.llb_ReturnFromManager.Location = new System.Drawing.Point(20, 20);
            this.llb_ReturnFromManager.Name = "llb_ReturnFromManager";
            this.llb_ReturnFromManager.Size = new System.Drawing.Size(46, 16);
            this.llb_ReturnFromManager.TabIndex = 34;
            this.llb_ReturnFromManager.TabStop = true;
            this.llb_ReturnFromManager.Text = "Return";
            this.llb_ReturnFromManager.VisitedLinkColor = System.Drawing.Color.Red;
            this.llb_ReturnFromManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_ReturnFromManager_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Manager - Sign In";
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
            // txt_ManagerUsername
            // 
            this.txt_ManagerUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ManagerUsername.Location = new System.Drawing.Point(277, 168);
            this.txt_ManagerUsername.MaxLength = 32;
            this.txt_ManagerUsername.Name = "txt_ManagerUsername";
            this.txt_ManagerUsername.Size = new System.Drawing.Size(304, 34);
            this.txt_ManagerUsername.TabIndex = 27;
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
            // txt_ManagerPassword
            // 
            this.txt_ManagerPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ManagerPassword.Location = new System.Drawing.Point(277, 229);
            this.txt_ManagerPassword.MaxLength = 32;
            this.txt_ManagerPassword.Name = "txt_ManagerPassword";
            this.txt_ManagerPassword.Size = new System.Drawing.Size(304, 34);
            this.txt_ManagerPassword.TabIndex = 28;
            this.txt_ManagerPassword.UseSystemPasswordChar = true;
            // 
            // btn_ManagerSignIn
            // 
            this.btn_ManagerSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(104)))), ((int)(((byte)(74)))));
            this.btn_ManagerSignIn.FlatAppearance.BorderSize = 0;
            this.btn_ManagerSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ManagerSignIn.Font = new System.Drawing.Font("Yu Gothic UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ManagerSignIn.ForeColor = System.Drawing.Color.White;
            this.btn_ManagerSignIn.Location = new System.Drawing.Point(285, 291);
            this.btn_ManagerSignIn.Name = "btn_ManagerSignIn";
            this.btn_ManagerSignIn.Size = new System.Drawing.Size(150, 50);
            this.btn_ManagerSignIn.TabIndex = 23;
            this.btn_ManagerSignIn.Text = "SIGN IN";
            this.btn_ManagerSignIn.UseVisualStyleBackColor = false;
            this.btn_ManagerSignIn.Click += new System.EventHandler(this.btn_ManagerSignIn_Click);
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
            // btn_Escape
            // 
            this.btn_Escape.AutoSize = true;
            this.btn_Escape.BackColor = System.Drawing.Color.Transparent;
            this.btn_Escape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Escape.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Escape.Location = new System.Drawing.Point(649, 14);
            this.btn_Escape.Name = "btn_Escape";
            this.btn_Escape.Size = new System.Drawing.Size(32, 31);
            this.btn_Escape.TabIndex = 36;
            this.btn_Escape.Text = "X";
            this.btn_Escape.Click += new System.EventHandler(this.btn_Escape_Click);
            // 
            // form_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(702, 433);
            this.Controls.Add(this.btn_Escape);
            this.Controls.Add(this.panel_Manager);
            this.Controls.Add(this.panel_SignIn);
            this.Controls.Add(this.btn_Manager);
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
            this.panel_Manager.ResumeLayout(false);
            this.panel_Manager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_Manager;
        private System.Windows.Forms.Button btn_SignIn;
        private System.Windows.Forms.Panel panel_SignIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SignInUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SignInPassword;
        private System.Windows.Forms.Button btn_SignIn2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llb_ReturnFromSignIn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel_Manager;
        private System.Windows.Forms.LinkLabel llb_ReturnFromManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ManagerUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ManagerPassword;
        private System.Windows.Forms.Button btn_ManagerSignIn;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label btn_Escape;
    }
}

