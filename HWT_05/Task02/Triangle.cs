/*
 * Треугольник со сторонами a, b и с, периметром и площадью.
 */

namespace Task02
{
    using System;

    public class Triangle
    {
        private double a = 0;
        private double b = 0;
        private double c = 0;

        public Triangle(double a, double b, double c)
        {
            if (a < b + c && b < a + c && c < a + b &&
                a > Math.Abs(b - c) && b > Math.Abs(a - c) && c > Math.Abs(a - b))
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
        }

        public double SideA
        {
            get
            {
                return a;
            }
        }

        public double SideB
        {
            get
            {
                return b;
            }
        }

        public double SideC
        {
            get
            {
                return c;
            }
        }

        /// <summary>
        /// Если длины сторон на входе корректны, то задает стороны треугольника и возвращает true;
        /// иначе обнуляет стороны и возвращает false.
        /// </summary>
        /// <param name="a">Длина стороны a</param>
        /// <param name="b">Длина стороны b</param>
        /// <param name="c">Длина стороны c</param>
        /// <returns>Признак существования треугольника</returns>
        public bool SetSides(double a, double b, double c)
        {
            if (a < b + c && b < a + c && c < a + b &&
                a > Math.Abs(b - c) && b > Math.Abs(a - c) && c > Math.Abs(a - b))
            {
                this.a = a;
                this.b = b;
                this.c = c;
                return true;
            }
            else
            {
                this.a = 0;
                this.b = 0;
                this.c = 0;
                return false;
            }
        }

        /// <summary>
        /// Рассчитывает периметр данного треугольника.
        /// </summary>
        /// <returns>Периметр.</returns>
        public double CalculatePerimeter()
        {
            return a + b + c;
        }

        /// <summary>
        /// Рассчитывает площадь данного треугольника.
        /// </summary>
        /// <returns>Площадь.</returns>
        public double CalculateArea()
        {
            var p = (a + b + c) / 2;
            var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
    }
}
