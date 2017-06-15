namespace Task02
{
    using System;

	/// <summary>
	/// Круг с коориданатами центра, радиусом, площадью и длиной описывающей окружности.
	/// </summary>
	public class Disc//todo pn если хочешь подписывать классы, делай это через summary
    {
        private double x = 0;
        private double y = 0;
        private double radius = 0;

        public Disc(double x, double y, double radius)
        {
            if (radius >= 0)
            {
                this.x = x;
                this.y = y;
                this.radius = radius;
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
                }
                else
                {
                    radius = 0;
                }
            }
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(Radius, 2); }
        }

        public double Circumference
        {
            get { return Math.PI * 2 * Radius; }
        }
    }
}
