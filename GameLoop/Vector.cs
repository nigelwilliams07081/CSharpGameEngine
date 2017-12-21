﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace GameLoop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float x, float y, float z) : this()
        {
            X = x;
            Y = y;
            Z = y;
        }
    }
}
