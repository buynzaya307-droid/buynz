using System.Drawing;

namespace zurag_zurah
{
    public class LineDraw : Shape
    {
        public LineDraw(Color color, float width, Point start)
            : base(color, width, start)
        {
        }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, Width))
            {
                g.DrawLine(pen, Start, End);
            }
        }
    }
}