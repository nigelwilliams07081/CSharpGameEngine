using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoop
{
    static class Program
    {
        static FastLoop m_FastLoop = new FastLoop(GameLoop);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void GameLoop(double elapsedTime)
        {
            // GameCode goes here
            // GetInput
            // Process
            // Render
            Console.WriteLine("loop");
        }
    }
}
