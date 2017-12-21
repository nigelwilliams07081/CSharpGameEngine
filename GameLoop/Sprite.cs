using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop
{
    public class Sprite
    {
        internal const int VertexAmount = 6;
        Vector[] m_VertexPositions = new Vector[VertexAmount];
        Color[] m_VertexColors = new Color[VertexAmount];
        Point[] m_VertexUVs = new Point[VertexAmount];
        Texture m_Texture = new Texture();

        public Sprite()
        {
            InitVertexPositions(new Vector(0.0f, 0.0f, 0.0f), 1.0f, 1.0f);
            SetColor(new Color(1.0f, 1.0f, 1.0f, 1.0f));
            SetUVs(new Point(0.0f, 0.0f), new Point(1.0f, 1.0f));
        }

        public Texture Texture
        {
            get { return m_Texture; }
            set
            {
                m_Texture = value;
                // By default, the width and height is set to that of the texture
                InitVertexPositions(GetCenter(), m_Texture.Width, m_Texture.Height);
            }
        }

        public Vector[] VertexPositions { get { return m_VertexPositions; } }
        public Color[] VertexColors { get { return m_VertexColors; } }
        public Point[] VertexUVs { get { return m_VertexUVs; } }

        private Vector GetCenter()
        {
            float halfWidth = GetWidth() / 2.0f,
                halfHeight = GetHeight() / 2.0f;

            return new Vector(m_VertexPositions[0].X + halfWidth, m_VertexPositions[0].Y - halfHeight, m_VertexPositions[0].Z);
        }

        private void InitVertexPositions(Vector position, float width, float height)
        {
            float halfWidth = width / 2.0f,
                halfHeight = height / 2.0f;

            // Clockwise creation of two triangles to make a quad

            // TopLeft, TopRight, BottomLeft
            m_VertexPositions[0] = new Vector(position.X - halfWidth, position.Y + halfHeight, position.Z);
            m_VertexPositions[1] = new Vector(position.X + halfWidth, position.Y + halfHeight, position.Z);
            m_VertexPositions[2] = new Vector(position.X - halfWidth, position.Y - halfHeight, position.Z);

            //TopRight, BottomRight, BottomLeft
            m_VertexPositions[3] = new Vector(position.X + halfWidth, position.Y + halfHeight, position.Z);
            m_VertexPositions[4] = new Vector(position.X + halfWidth, position.Y - halfHeight, position.Z);
            m_VertexPositions[5] = new Vector(position.X - halfWidth, position.Y - halfHeight, position.Z);
        }

        public float GetWidth()
        {
            // topright = topleft
            return m_VertexPositions[1].X - m_VertexPositions[0].X;
        }

        public float GetHeight()
        {
            // topleft - bottomleft
            return m_VertexPositions[0].Y - m_VertexPositions[2].Y;
        }

        public void SetWidth(float width)
        {
            InitVertexPositions(GetCenter(), width, GetHeight());
        }

        public void SetHeight(float height)
        {
            InitVertexPositions(GetCenter(), GetWidth(), height);
        }

        public void SetPosition(float x, float y)
        {
            SetPosition(new Vector(x, y, 0));
        }

        public void SetPosition(Vector position)
        {
            InitVertexPositions(position, GetWidth(), GetHeight());
        }

        public void SetColor(Color color)
        {
            for (int i = 0; i < Sprite.VertexAmount; i++)
            {
                m_VertexColors[i] = color;
            }
        }

        public void SetUVs(Point topLeft, Point bottomRight)
        {
            // TopLeft, TopRight, BottomLeft
            m_VertexUVs[0] = topLeft;
            m_VertexUVs[1] = new Point(bottomRight.X, topLeft.Y);
            m_VertexUVs[2] = new Point(topLeft.X, bottomRight.Y);

            // TopRight, BottomRight, BottomLeft
            m_VertexUVs[3] = new Point(bottomRight.X, topLeft.Y);
            m_VertexUVs[4] = bottomRight;
            m_VertexUVs[5] = new Point(topLeft.X, bottomRight.Y);
        }
    }
}
