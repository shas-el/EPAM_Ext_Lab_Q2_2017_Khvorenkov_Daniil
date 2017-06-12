/*
 * Окружность в двухмерном пространстве. Может возвращать длину окружности.
 */

namespace Task03
{
    using System;
    using System.Text;

    public class Circle : Shape
    {
        private double radius = 0;

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Point Center { get; set; }

        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value > 0)
                {
                    radius = value;
                }
            }
        }

        public double Length
        {
            get { return Math.PI * 2 * Radius; }
        }

        public override string GetShapeOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Фигура: Окружность\n");
            sb.AppendFormat("Координаты центра: {0}\n", Center.ToString());
            sb.AppendFormat("Радиус: {0}\n", Radius);
            sb.AppendFormat("Длина окружности: {0}\n", Length);
            return sb.ToString();
        }
    }
}
