using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class SplashScreenState : IGameObject
    {
        private StateSystem m_System;
        private float m_DelayInSeconds = 3.0f;

        public SplashScreenState(StateSystem system)
        {
            m_System = system;
        }

        public void Update(float deltaTime)
        {
            m_DelayInSeconds -= deltaTime;
            if (m_DelayInSeconds <= 0.0f)
            {
                m_DelayInSeconds = 3.0f;
                m_System.ChangeState("title_menu");
            }
        }

        public void Draw()
        {
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glFinish();
        }
    }
}
