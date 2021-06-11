using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSMB_Randomiser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Console.WriteLine("Loading...");
            Application.Run(new EditorForm());
            //Console.WriteLine("Randomizer window closed. You can view debug output here if necessary.");
        }
    }
}
