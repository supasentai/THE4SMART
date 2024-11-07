using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;


namespace THE4SMART
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form_Home loginForm = new form_Home();

            // Hiển thị form_Home dưới dạng dialog và kiểm tra kết quả
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Nếu đăng nhập thành công, mở form_HomePage
                Application.Run(new form_homepage());
            }
            else
            {
                // Thoát ứng dụng nếu đăng nhập thất bại
                Application.Exit();
            }


        }

    }


    
}
