/*
 * Определяет, принадлежит ли точка фигуре
 */

namespace Task01
{
    using System;

    public static class BelongingDeterminator
    {
        /// <summary>
        /// Определяет принадлежит ли точка фигуре
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="plot">Номер (буква) графика</param>
        /// <returns></returns>
        public static bool BelongsTo(double x, double y, char plot)
        {
            switch (plot)
            {
                case 'а':
                    {
                        double radius = 1;

                        if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(radius, 2))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'б':
                    {
                        double innerRadius = 0.5;
                        double outerRadius = 1;

                        if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(outerRadius, 2) &&
                            Math.Pow(x, 2) + Math.Pow(y, 2) > Math.Pow(innerRadius, 2))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'в':
                    {
                        if ((x >= -1) && (x <= 1) &&
                            (y >= -1) && (y <= 1))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'г':
                    {
                        if ((y + x <= 1) && (x - y <= 1) &&
                            (y - x >= -1) && (y + x >= -1))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'д':
                    {
                        if ((y + (2 * x) <= 1) && (y - (2 * x) <= 1) &&
                            (y - (2 * x) >= -1) && (y + (2 * x) >= -1))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'е':
                    {
                        double radius = 1;

                        if (((x >= -2) && (x <= 0) && (y - (0.5 * x) <= 1) && (y + (0.5 * x) >= -1))
                           || ((x > 0) && (x <= 1) && (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(radius, 2))))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'ж':
                    {
                        if ((y >= -1) && (y - (2 * x) <= 2) && (y + (2 * x) <= 2))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'з':
                    {
                        if ((y >= -2) && (x >= -1) && (x <= 1) && (y - Math.Abs(x) <= 0))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'и':
                    {
                        if (((3 * y) + x <= -1) &&
                            (((x >= 0) && (x < 0) && (y <= 0)) ||
                            ((x >= -2) && (x < 0) && (y - (2 * x) <= 3) && (y - x <= 0))))
                        {
                            return true;
                        }

                        return false;
                    }

                case 'к':
                    {
                        if ((((x <= -1) || (x >= 1)) && (y >= 1)) ||
                            ((x > -1) && (x < 1) && (y - Math.Abs(x) >= 0)))
                        {
                            return true;
                        }

                        return false;
                    }

                default:
                    {
                        return false;
                    }
            }
        }
    }
}
