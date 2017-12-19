using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameLoop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr hWnd;
        public Int32 message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }

    public class FastLoop
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(
            out Message message,
            IntPtr hWnd,
            uint messageFilterMin,
            uint messageFilterMax,
            uint flags);

        private PreciseTimer m_Timer = new PreciseTimer();
        public delegate void LoopCallback(float deltaTime);
        private LoopCallback m_Callback;

        public FastLoop(LoopCallback callback)
        {
            m_Callback = callback;
            Application.Idle += new EventHandler(OnApplicationEnterIdle);
        }

        private void OnApplicationEnterIdle(object sender, EventArgs e)
        {
            while (IsAppStillIdle())
            {
                m_Callback(m_Timer.GetElapsedTime());
            }
        }

        private bool IsAppStillIdle()
        {
            return !PeekMessage(out Message message, IntPtr.Zero, 0, 0, 0);
        }
    }
}
