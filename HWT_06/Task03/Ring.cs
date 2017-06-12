/*
 * Кольцо в двухмерном простанстве. Может возвращать площадь и длину внутренней окружности.
 */

namespace Task03
{
    using System;
    using System.Text;

    public class Ring : Disc
    {
        private double innerRadius = 0;

        public Ring(Point center, double radius, double innerRadius) : base(center, radius)
        {
            InnerRadius = innerRadius;
        }

        public double InnerRadius
        {
            get
            {
                return innerRadius;
            }

            set
            {
                if (value > 0 && value < Radius)
                {
                    innerRadius = value;
                }
            }
        }

        public double InnerLength
        {
            get { return Math.PI * 2 * InnerRadius; }
        }

        public new double Area
        {
            get { return base.Area - (Math.PI * InnerRadius * InnerRadius); }
        }

        public override string GetShapeOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Фигура: Кольцо\n");
            sb.AppendFormat("Координаты центра: {0}\n", Center.ToString());
            sb.AppendFormat("Внешний радиус: {0}\n", Radius);
            sb.AppendFormat("Внутренний радиус: {0}\n", InnerRadius);
            sb.AppendFormat("Длина описывающей окружности: {0}\n", Length);
            sb.AppendFormat("Длина внутренней окружности: {0}\n", InnerLength);
            sb.AppendFormat("Площадь: {0}\n", Area);
            return sb.ToString();
        }
    }
}
