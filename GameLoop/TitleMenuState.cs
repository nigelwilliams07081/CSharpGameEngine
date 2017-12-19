using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class TitleMenuState : IGameObject
    {
        float m_CurrentRotation = 0.0f;

        public void Update(float deltaTime)
        {
            m_CurrentRotation = 10.0f * deltaTime;
        }

        public void Draw()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPointSize(5.0f);

            Gl.glRotatef(m_CurrentRotation, 0.0f, 1.0f, 0.0f);
            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);

            Gl.glColor4f(1.0f, 0.0f, 0.0f, 0.5f);
            Gl.glVertex3f(-0.5f, 0.0f, 0.0f);

            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.5f, 0.0f, 0.0f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0.0f, 0.5f, 0.0f);

            Gl.glEnd();
            Gl.glFinish();
        }
    }
}
