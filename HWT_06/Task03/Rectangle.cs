/*
 * Прямоугольник в двухмерном пространстве, описываемый диагональю. Может возвращать площадь.
 */

namespace Task03
{
    using System;
    using System.Text;

    public class Rectangle : Shape
    {
        public Rectangle(Line diagonal)
        {
            Diagonal = diagonal;
        }

        public Line Diagonal { get; set; }

        public double Area
        {
            get
            {
                return Math.Abs(Diagonal.Beginning.X - Diagonal.End.X) * Math.Abs(Diagonal.Beginning.Y - Diagonal.End.Y);
            }
        }

        public override string GetShapeOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Фигура: Прямоугольник\n");
            sb.AppendFormat("Координаты начальной точки диагонали: {0}\n", Diagonal.Beginning.ToString());
            sb.AppendFormat("Координаты конечной точки: {0}\n", Diagonal.End.ToString());
            sb.AppendFormat("Площадь: {0}\n", Area);
            return sb.ToString();
        }
    }
}
