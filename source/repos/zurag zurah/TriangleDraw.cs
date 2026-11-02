using System.Drawing;
using System;

namespace zurag_zurah
{
    public class TriangleDraw : Shape
    {
        public TriangleDraw(Color color, float width, Point start)
            : base(color, width, start)
        {
        }

        public override void Draw(Graphics g)
        {
            int x = Math.Min(Start.X, End.X);
            int y = Math.Min(Start.Y, End.Y);
            int w = Math.Abs(End.X - Start.X);
            int h = Math.Abs(End.Y - Start.Y);

            // Гурвалжны 3 оройн цэгүүдийг тооцоолох
            Point p1 = new Point(x + w / 2, y);     // Дээд орой
            Point p2 = new Point(x, y + h);         // Зүүн доод орой
            Point p3 = new Point(x + w, y + h);     // Баруун доод орой

            using (Pen pen = new Pen(Color, Width))
            {
                g.DrawPolygon(pen, new Point[] { p1, p2, p3 });
            }
        }
    }
}