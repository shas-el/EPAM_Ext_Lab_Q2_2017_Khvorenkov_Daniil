/*
 * Заготовка векторного графического редактора. Опрашивает пользователя, добавляет нужные фигуры и выводит их в консоли.
 */

namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Editor
    {
        public Editor()
        {
            Shapes = new List<Shape>();
        }

        public List<Shape> Shapes { get; private set; }

        public void ShowDialog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Добавить линию");
            sb.AppendLine("2. Добавить прямоугольник");
            sb.AppendLine("3. Добавить окружность");
            sb.AppendLine("4. Добавить круг");
            sb.AppendLine("5. Добавить кольцо");
            sb.AppendLine("6. Отобразить добавленные фигуры");
            sb.AppendLine("Введите одну из приведенных цифр:");
            Console.Write(sb);
            string inputString = Console.ReadLine();
            int input;

            while (!(int.TryParse(inputString, out input) || input < 1 || input > 6))
            {
                Console.WriteLine("Некорректный ввод");
                Console.WriteLine("Введите одну из приведенных цифр:");
                inputString = Console.ReadLine();
            }

            HandleInput(input);
        }

        private void HandleInput(int input)
        {
            switch (input)
            {
                case 1:
                    AddLine();
                    break;
                case 2:
                    AddRectangle();
                    break;
                case 3:
                    AddCircle();
                    break;
                case 4:
                    AddDisc();
                    break;
                case 5:
                    AddRing();
                    break;
                case 6:
                    PrintOutput();
                    break;                    
            }
        }

        private void AddLine()
        {
            double x1, y1, x2, y2;
            x1 = AskForDouble("X начальной точки");
            y1 = AskForDouble("Y начальной точки");
            x2 = AskForDouble("X конечной точки");
            y2 = AskForDouble("Y конечной точки");
            Line line = new Line(new Point(x1, y1), new Point(x2, y2));
            Shapes.Add(line);
        }

        private void AddRectangle()
        {
            double x1, y1, x2, y2;
            x1 = AskForDouble("X начальной точки диагонали");
            y1 = AskForDouble("Y начальной точки диагонали");
            x2 = AskForDouble("X конечной точки диагонали");
            y2 = AskForDouble("Y конечной точки диагонали");
            Line diagonal = new Line(new Point(x1, y1), new Point(x2, y2));
            Rectangle rectangle = new Rectangle(diagonal);
            Shapes.Add(rectangle);
        }

        private void AddCircle()
        {
            double x, y;
            double radius;
            x = AskForDouble("X центра");
            y = AskForDouble("Y центра");
            radius = AskForDouble("радиус");
            Circle circle = new Circle(new Point(x, y), radius);
            Shapes.Add(circle);
        }

        private void AddDisc()
        {
            double x, y;
            double radius;
            x = AskForDouble("X центра");
            y = AskForDouble("Y центра");
            radius = AskForDouble("радиус");
            Disc disc = new Disc(new Point(x, y), radius);
            Shapes.Add(disc);
        }

        private void AddRing()
        {
            double x, y;
            double radius;
            double innerRadius;
            x = AskForDouble("X центра");
            y = AskForDouble("Y центра");
            radius = AskForDouble("радиус внешней окружности");
            innerRadius = AskForDouble("радиус внутренней окружности");
            Ring ring = new Ring(new Point(x, y), radius, innerRadius);
            Shapes.Add(ring);
        }

        private void PrintOutput()
        {
            Console.WriteLine("***************\n\n");

            foreach (Shape shape in Shapes)
            {
                Console.WriteLine(shape.GetShapeOutput() + "\n");
            }

            Console.WriteLine("***************\n\n");
        }

        private double AskForDouble(string name)
        {
            double value;
            Console.Write("Введите {0}: ", name);

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Некорректный {0}", name);
                Console.Write("Введите {0}: ", name);
            }

            return value;
        }
    }
}
