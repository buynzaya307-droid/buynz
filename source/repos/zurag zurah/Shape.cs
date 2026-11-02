using System.Drawing;

namespace zurag_zurah
{
    public abstract class Shape
    {
        public Color Color { get; set; }
        public float Width { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public Shape(Color color, float width, Point start)
        {
            Color = color;
            Width = width;
            Start = start;
            End = start;
        }

        public abstract void Draw(Graphics g);
    }
}