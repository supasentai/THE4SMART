using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Net;
using System.Xml.Linq;

namespace THE4SMART
{
    public partial class form_Home : Form
    {
        private list_Staff staffList;
        private list_Manager managerList;
        public Manager admin = new Manager("1", "123", "123", "19001010", "Quan 1");

        public form_Home()
        {
            InitializeComponent();
            staffList = new list_Staff();
            managerList = new list_Manager();
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            panel_SignIn.Visible = true;
            panel_Manager.Visible = false;
            txt_SignInUsername.Text = "";
            txt_SignInPassword.Text = "";
        }

        private void btn_Manager_Click(object sender, EventArgs e)
        {
            panel_SignIn.Visible = false;
            panel_Manager.Visible = true;
            txt_SignInUsername.Text = "";
            txt_SignInPassword.Text = "";
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
        private void form_Home_Load(object sender, EventArgs e)
        {
            back_menu.init_staff();
            back_menu.init_product();
        }

        private void btn_ManagerSignIn_Click(object sender, EventArgs e)
        {
            if (txt_ManagerPassword.Text == admin.User_Password && txt_ManagerUsername.Text == admin.User_name)
            {
                list_Manager.permission = true;

                MessageBox.Show($"Welcome, ADMIN!");
                Form currentForm = Application.OpenForms["form_Home"];
                if (currentForm != null)
                {
                    currentForm.Close();
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void llb_ReturnFromSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_SignIn.Visible = false;
            panel_Manager.Visible = false;
        }

        private void llb_ReturnFromManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_SignIn.Visible = false;
            panel_Manager.Visible = false;
        }

        private void btn_Escape_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
