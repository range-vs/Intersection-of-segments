using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace task_5_dop
{
    class Segment // класс - отрезок
    {
        public List<PointF> XY { get; set; }
        public List<PointF> Segm { get; private set; }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double MaxX { get; set; }
        public double MinX { get; set; }
        public double MaxY { get; set; }
        public double MinY { get; set; }

        public Segment(double x1, double y1, double x2, double y2)
        {
            XY = new List<PointF> { new PointF((float)x1, (float)y1), new PointF((float)x2, (float)y2) };
            Segm = new List<PointF>(XY);
            MinX = x1; MaxX = x2;
            if(MinX > MaxX)
            {
                double tmp = MinX;
                MinX = MaxX;
                MaxX = tmp;
            }
            MinY = y1; MaxY = y2;
            if (MinY > MaxY)
            {
                double tmp = MinY;
                MinY = MaxY;
                MaxY = tmp;
            }
            CalculateInequalityGeneralView(x1, y1, x2, y2);
        }

        private void CalculateInequalityGeneralView(double x1, double y1, double x2, double y2)
        {
            A = y1 - y2;
            B = x2 - x1;
            C = x1 * y2 - x2 * y1;
        }

        public void AddPoint(double x, double y)
        {
            XY.Add(new PointF((float)x, (float)y));
        }

        public PointF? GetPointIntersectionInequality(Segment s)
        {
            PointF p = new PointF();
            double det = A * s.B - s.A * B;
            if (det == 0)
                return null;
            p.X = (float)((B * s.C - s.B * C) / det);
            p.Y = (float)((s.A * C - A * s.C) / det);
            if(((Segm[0].X <= p.X && p.X <= Segm[1].X) || (Segm[0].X >= p.X && p.X >= Segm[1].X)) && ((Segm[0].Y <= p.Y && p.Y <= Segm[1].Y) || (Segm[0].Y >= p.Y && p.Y >= Segm[1].Y)) 
                &&
                ((s.Segm[0].X <= p.X && p.X <= s.Segm[1].X) || (s.Segm[0].X >= p.X && p.X >= s.Segm[1].X)) && ((s.Segm[0].Y <= p.Y && p.Y <= s.Segm[1].Y) || (s.Segm[0].Y >= p.Y && p.Y >= s.Segm[1].Y)))
                return p;
            return null;
        }
    }
}
