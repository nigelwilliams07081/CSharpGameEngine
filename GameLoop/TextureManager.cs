using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Tao.OpenGl;

namespace GameLoop
{
    class TextureManager : IDisposable
    {
        Dictionary<string, Texture> m_TextureDatabase = new Dictionary<string, Texture>();
        
        public Texture GetTexture(string textureID)
        {
            return m_TextureDatabase[textureID];
        }

        public void LoadTexture(string textureID, string path)
        {
            Bitmap bitmap = new Bitmap(path);
            
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glGenTextures(1, out int tex);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, tex);
            Console.WriteLine("TextureID: " + tex);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, data.Width, data.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data.Scan0);

            bitmap.UnlockBits(data);

            Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

            m_TextureDatabase.Add(textureID, new Texture(tex, data.Width, data.Height));
        }

        public void Dispose()
        {
            foreach (Texture texture in m_TextureDatabase.Values)
            {
                Gl.glDeleteTextures(1, new int[] { texture.Id });
            }
        }
    }
}
