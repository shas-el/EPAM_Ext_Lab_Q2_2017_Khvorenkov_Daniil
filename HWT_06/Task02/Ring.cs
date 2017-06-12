/*
 * Кольцо с координатами центра, внешним и внутренним радиусом и свойствами,
 * позволяющими вычислить площадь кольца и суммарную длину внешней и внутренней окружностей.
 */

namespace Task02
{
    using System;

    public class Ring : Disc
    {
        private double innerRadius = 0;

        public Ring(double x, double y, double radius, double innerRadius) : base(x, y, radius)
        {
            if (innerRadius > 0 && innerRadius < radius)
            {
                this.innerRadius = innerRadius;
            }
            else
            {
                this.innerRadius = 0;
            }
        }

        public double InnerRadius
        {
            get
            {
                return innerRadius;
            }

            set
            {
                if (value > 0)
                {
                    innerRadius = value;
                }
                else
                {
                    innerRadius = 0;
                }
            }
        }

        public new double Area
        {
            get { return Math.PI * (Math.Pow(Radius, 2) - Math.Pow(InnerRadius, 2)); }
        }

        public new double Circumference
        {
            get { return Math.PI * 2 * (Radius + InnerRadius); }
        }
    }
}
