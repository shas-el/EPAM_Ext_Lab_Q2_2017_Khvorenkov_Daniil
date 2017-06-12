/*
 * Круг в двухмерном пространстве. Может возвращать площадь.
 */

namespace Task03
{
    using System;
    using System.Text;

    public class Disc : Circle
    {
        public Disc(Point center, double radius) : base(center, radius)
        {
        }

        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public override string GetShapeOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Фигура: Круг\n");
            sb.AppendFormat("Координаты центра: {0}\n", Center.ToString());
            sb.AppendFormat("Радиус: {0}\n", Radius);
            sb.AppendFormat("Длина описывающей окружности: {0}\n", Length);
            sb.AppendFormat("Площадь: {0}\n", Area);
            return sb.ToString();
        }
    }
}
