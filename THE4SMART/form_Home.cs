using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace THE4SMART
{
    public partial class form_Home : Form
    {
        private list_Staff staffList;
        public form_Home()
        {
            InitializeComponent();
            staffList = new list_Staff();
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            panel_SignIn.Visible = true;
            panel_SignUp.Visible = false;
            txt_SignInUsername.Text = "";
            txt_SignInPassword.Text = "";
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            panel_SignUp.Visible = true;
            panel_SignIn.Visible = false;
            txt_SignUpUsername.Text = "";
            txt_SignUpPassword.Text = "";
        }

        private void llb_ReturnFromSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_SignIn.Visible = false;
            panel_SignUp.Visible = false;
        }

        private void btn_SignIn2_Click(object sender, EventArgs e)
        {
            staffList.check_user(txt_SignInUsername.Text, txt_SignInPassword.Text);
            if (list_Staff.isSignIN)
            {
                // Đăng nhập thành công, đóng form với DialogResult.OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void llb_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txt_SignUpUsername.Text = "";
            txt_SignUpPassword.Text = "";
            panel_SignUp.Visible = true;
            panel_SignIn.Visible = false;
        }

        private void llb_ReturnFromSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_SignIn.Visible = false;
            panel_SignUp.Visible = false;
        }

        private void llbSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txt_SignInUsername.Text = "";
            txt_SignInPassword.Text = "";
            panel_SignIn.Visible = true;
            panel_SignUp.Visible = false;
        }

        private void btn_SignUpNext_Click(object sender, EventArgs e)
        {

        }

        private void form_Home_Load(object sender, EventArgs e)
        {
            back_menu.init_staff();
            back_menu.init_product();
        }


        private void btn_Escape3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
