using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmetaCreator.Utils;

namespace SmetaCreator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Class1.Method1();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
