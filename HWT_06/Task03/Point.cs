/*
 * Точка в двухмерном пространстве.
 */

namespace Task03
{
    using System.Text;

    public class Point : Shape
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public new string ToString()
        {
            return string.Format("[{0};{1}]", X, Y);
        }

        public override string GetShapeOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Фигура: Точка\n{0}", ToString());
            return sb.ToString();
        }
    }
}
