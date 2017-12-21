﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using System.Runtime.InteropServices;

namespace GameLoop
{
    public class Renderer
    {
        public Renderer()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        }

        public void DrawImmediateModeVertex(Vector position, Color color, Point uvs)
        {
            Gl.glColor4f(color.Red, color.Green, color.Blue, color.Alpha);
            Gl.glTexCoord2f(uvs.X, uvs.Y);
            Gl.glVertex3f(position.X, position.Y, position.Z);
        }

        public void DrawSprite(Sprite sprite)
        {
            Gl.glBegin(Gl.GL_TRIANGLES);

            for (int i = 0; i < Sprite.VertexAmount; i++)
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, sprite.Texture.Id);
                DrawImmediateModeVertex(sprite.VertexPositions[i], sprite.VertexColors[i], sprite.VertexUVs[i]);
            }

            Gl.glEnd();
        }
    }
}
