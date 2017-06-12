/*
 * Отрезок в двухмерном пространстве. Может возвращать длину.
 */

namespace Task03
{
    using System;
    using System.Text;

    public class Line : Shape
    {
        public Line(Point beginning, Point end)
        {
            Beginning = beginning;
            End = end;
        }

        public Point Beginning { get; set; }

        public Point End { get; set; }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(Math.Abs(Beginning.X - End.X), 2) + Math.Pow(Math.Abs(Beginning.Y - End.Y), 2));
            }
        }

        public override string GetShapeOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Фигура: Отрезок\n");
            sb.AppendFormat("Координаты начальной точки: {0}\n", Beginning.ToString());
            sb.AppendFormat("Координаты конечной точки: {0}\n", End.ToString());
            return sb.ToString();
        }
    }
}
