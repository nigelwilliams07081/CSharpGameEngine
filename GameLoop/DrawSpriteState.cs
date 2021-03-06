﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class DrawSpriteState : IGameObject
    {
        TextureManager m_TextureManager;

        private const float SIZE_CONSTANT = 100.0f;

        private float m_Height = 2.0f * SIZE_CONSTANT;
        private float m_Width = 2.0f * SIZE_CONSTANT;
        private float m_HalfHeight;
        private float m_HalfWidth;

        private float m_X = 20.0f;
        private float m_Y = 0.0f;
        private float m_Z = 0.0f;

        public DrawSpriteState()
        {
            m_HalfHeight = m_Height / 2.0f;
            m_HalfWidth = m_Width / 2.0f;
        }

        public DrawSpriteState(TextureManager textureManager)
        {
            m_TextureManager = textureManager;
            m_HalfHeight = m_Height / 2.0f;
            m_HalfWidth = m_Width / 2.0f;
        }

        public void Update(float elapsedTime)
        {
            
        }

        public void Draw()
        {
            Texture texture = m_TextureManager.GetTexture("face_alpha");
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture.Id);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            //Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            float topUV = 0,
                bottomUV = 1,
                leftUV = 0,
                rightUV = 1,
                red = 1,
                green = 0,
                blue = 0,
                alpha = 1;

            Gl.glBegin(Gl.GL_TRIANGLES);

            Gl.glColor4f(red, green, blue, alpha);
            Gl.glTexCoord2f(leftUV, topUV);
            Gl.glVertex3f(m_X - m_HalfWidth, m_Y + m_HalfHeight, m_Z);
            Gl.glTexCoord2f(rightUV, topUV);
            Gl.glVertex3f(m_X + m_HalfWidth, m_Y + m_HalfHeight, m_Z);
            Gl.glTexCoord2f(leftUV, bottomUV);
            Gl.glVertex3f(m_X - m_HalfWidth, m_Y - m_HalfHeight, m_Z);

            Gl.glTexCoord2f(rightUV, topUV);
            Gl.glVertex3f(m_X + m_HalfWidth, m_Y + m_HalfHeight, m_Z);
            Gl.glTexCoord2f(rightUV, bottomUV);
            Gl.glVertex3f(m_X + m_HalfWidth, m_Y - m_HalfHeight, m_Z);
            Gl.glTexCoord2f(leftUV, bottomUV);
            Gl.glVertex3f(m_X - m_HalfWidth, m_Y - m_HalfHeight, m_Z);

            Gl.glEnd();
        }
    }
}
