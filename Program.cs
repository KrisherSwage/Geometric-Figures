using System;

namespace Dots
{
    class Program
    {
        public class Point //класс точки
        {
            public int x, y;
            public int InX() //метод получения координаты x 
            {
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Введите целое число (Координату x)");
                    if (int.TryParse(Console.ReadLine(), out int a))
                    {
                        x = a;
                        break;
                    }
                }
                return (x);
            }

            public int InY() //метод получения координаты y
            {
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Введите целое число (Координату y)");
                    if (int.TryParse(Console.ReadLine(), out int a))
                    {
                        y = a;
                        break;
                    }
                }
                return (y);
            }
        }
        class Triangle
        {
            double[] MasA = new double[2]; //массив координат точки A
            
            double[] MasB = new double[2]; //массив координат точки B

            double[] MasC = new double[2]; //массив координат точки C


            public void FirstLit(double x, double y) //метод получения координат точки A
            {
                MasA[0] =  x ;
                MasA[1] = y;
            }
            public void SecondLit(double x, double y) //метод получения координат точки B
            {
                MasB[0] = x;
                MasB[1] = y;
            }
            public void ThirdLit(double x, double y) //метод получения координат точки C
            {
                MasC[0] = x;
                MasC[1] = y;
            }

            double side1, side2, side3, per, area, per05; //переменные для геометрии
            
            public void Ex()
            {
                Console.WriteLine($"Координаты точки A ({MasA[0]}; {MasA[1]})");
                Console.WriteLine($"Координаты точки B ({MasB[0]}, {MasB[1]})");
                Console.WriteLine($"Координаты точки C ({MasC[0]}, {MasC[1]})");

                side1 = Math.Sqrt(Math.Pow(MasA[0] - MasB[0], 2) + Math.Pow(MasA[1] - MasB[1], 2)); //расчет длин сторон
                side2 = Math.Sqrt(Math.Pow(MasB[0] - MasC[0], 2) + Math.Pow(MasB[1] - MasC[1], 2));
                side3 = Math.Sqrt(Math.Pow(MasC[0] - MasA[0], 2) + Math.Pow(MasC[1] - MasA[1], 2));

                per = side1 + side2 + side3; //периметр
                Console.WriteLine($"Периметр треугольника равен {per}");

                per05 = per / 2;
                area = Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)); //формула Герона

                double round = Convert.ToDouble(area.ToString($"N{3}")); //округление площади

                Console.WriteLine($"Площадь треугольника равна {round}");
            }
        }

        static void Main(string[] args)
        {
            var point = new Point(); //экземпляр класса точки

            var triangle = new Triangle(); //экземпляр класса треугольник

            Console.WriteLine("Введите координаты первой точки треугольника");
            triangle.FirstLit(point.InX(), point.InY()); //вызов метода получения координат точки A
            Console.WriteLine("Введите координаты второй точки треугольника");
            triangle.SecondLit(point.InX(), point.InY()); //вызов метода получения координат точки B
            Console.WriteLine("Введите координаты третьей точки треугольника");
            triangle.ThirdLit(point.InX(), point.InY()); //вызов метода получения координат точки C

            triangle.Ex(); //метод, высчитывающий геометрию треугольника

            Console.ReadLine();
        }
    }
}
