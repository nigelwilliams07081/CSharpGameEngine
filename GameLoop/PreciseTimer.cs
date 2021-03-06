﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GameLoop
{
    public class PreciseTimer
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long PerformanceCount);

        private long m_TicksPerSecond = 0;
        private long m_PreviousElapsedTime = 0;

        public PreciseTimer()
        {
            QueryPerformanceFrequency(ref m_TicksPerSecond);
            GetElapsedTime(); // Get rid of first rubbish result
        }
        
        public float GetElapsedTime()
        {
            long time = 0;
            QueryPerformanceCounter(ref time);
            float deltaTime = (float) (time - m_PreviousElapsedTime) / (float) m_TicksPerSecond;
            m_PreviousElapsedTime = time;
            return deltaTime;
        }
    }
}
