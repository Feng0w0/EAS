using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAS
{
    
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 loginInterface = new Form1();
            Application.Run(loginInterface);
            if (loginInterface.login)
            {
                if(loginInterface.user==1)Application.Run(new Manger.Manger(loginInterface.number));
                else if (loginInterface.user == 2) { Application.Run(new Student.Student(loginInterface.number)); }
                else if (loginInterface.user == 3) { Application.Run(new teacher.Teacher(loginInterface.number)); }
            }
        }
    }
}
