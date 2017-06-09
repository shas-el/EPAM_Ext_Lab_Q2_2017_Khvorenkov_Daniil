/*
 * Круг с коориданатами центра, радиусом, площадью и длиной описывающей окружности.
 */

namespace Task01
{
    using System;

    public class Round
    {
        private double x = 0;
        private double y = 0;
        private double radius = 0;
        private double area = 0;
        private double circumference = 0;

        public Round(double x, double y, double radius)
        {
            if (radius >= 0)
            {
                this.x = x;
                this.y = y;
                this.radius = radius;
                circumference = Math.PI * radius * 2;
                area = Math.PI * Math.Pow(radius, 2);
            }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

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
                    circumference = Math.PI * radius * 2;
                    area = Math.PI * Math.Pow(radius, 2);
                }
                else
                {
                    radius = 0;
                    circumference = 0;
                    area = 0;
                }
            }
        }

        public double Area
        {
            get { return area; }
        }

        public double Circumference
        {
            get { return circumference; }
        }
    }
}
