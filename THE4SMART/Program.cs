using System;
using System.Windows.Forms;

namespace THE4SMART
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form_Home loginForm = new form_Home();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new form_homepage());
            }
        }
    }
}
