using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace GameLoop
{
    class TestSpriteClassState : IGameObject
    {
        private Renderer m_Renderer = new Renderer();
        private TextureManager m_TextureManager;
        private Sprite m_TestSprite = new Sprite();
        private Sprite m_TestSprite2 = new Sprite();

        public TestSpriteClassState(TextureManager textureManager)
        {
            m_TextureManager = textureManager;
            m_TestSprite.Texture = m_TextureManager.GetTexture("face_alpha");
            m_TestSprite.SetHeight(256 * 0.5f);
            m_TestSprite.SetPosition(360.0f, -360.0f);

            m_TestSprite2.Texture = m_TextureManager.GetTexture("face_alpha");
            m_TestSprite2.SetPosition(210.0f, -210.0f);
            m_TestSprite2.SetColor(new Color(1.0f, 0.0f, 0.0f, 1.0f));
        }

        public void Update(float deltaTime)
        {

        }

        public void Draw()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            m_Renderer.DrawSprite(m_TestSprite);
            m_Renderer.DrawSprite(m_TestSprite2);
            Gl.glFinish();
        }
    }
}
