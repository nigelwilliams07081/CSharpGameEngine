using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;

namespace GameLoop
{
    public partial class Form1 : Form
    {
        private TextureManager m_TextureManager = new TextureManager();
        private StateSystem m_System = new StateSystem();
        private FastLoop m_FastLoop;
        private bool m_FullScreen = false;

        public Form1()
        {
            InitializeComponent();
            m_OpenGLControl.InitializeContexts();
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
            m_TextureManager.LoadTexture("face", "face.tif");
            m_TextureManager.LoadTexture("face_alpha", "face_alpha.tif");

            if (m_FullScreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(1280, 720);
            }

            // Add all states to be used
            m_System.AddState("splash", new SplashScreenState(m_System));
            m_System.AddState("title_menu", new TitleMenuState());
            m_System.AddState("sprite_test", new DrawSpriteState(m_TextureManager));
            m_System.AddState("new_sprite_test", new TestSpriteClassState(m_TextureManager));

            // Set the start state
            m_System.ChangeState("new_sprite_test");
            
            m_FastLoop = new FastLoop(GameLoop);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(float width, float height)
        {
            float halfWidth = width / 2,
                halfHeight = height / 2;

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, -height, 0, -100.0, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void GameLoop(float deltaTime)
        {
            m_System.Update(deltaTime);
            m_System.Draw();
            m_OpenGLControl.Refresh();
        }
    }
}
