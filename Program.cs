using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Создаем и запускаем форму MainForm
            Application.Run(new global::MainForm());
        }
    }
}
