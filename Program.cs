using System;

namespace Points
{
    class Program
    {
        public class Point //класс точки
        {
            public double x, y, R;
            // R- что такое?
            public void InX() //метод получения координаты x 
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
                
            }

            public void InY() //метод получения координаты y
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
               
            }
            public void InPoint() // метод ввода точки
            {
                InX();
                InY();
            }
            public void SetPoint(double x, double y) // метод заполнения точки
            {
                this.x=x;
                this.y=y;
            }
           public void print() // метод печати точки
            {
                 Console.WriteLine($"Координаты точки ({x}; {y})");
            }
            public double dist(Point B) //рассчет расстояния
            {
                return (Math.Sqrt(Math.Pow(x - B.x, 2) + Math.Pow(this.y - B.y, 2)));
            }
                
            
        }

        class Triangle //класс треугольника
        {
            /*double[] MasA = new double[2]; //массив координат точки A
            double[] MasB = new double[2]; //массив координат точки B
            double[] MasC = new double[2]; //массив координат точки C
            */
            public Point A,B,C; // точки треугольника

            public void FirstLit(double x, double y) //метод получения координат точки A
            {
                A.x = x;
                A.y = y;
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
                A.print();
                Console.WriteLine($"Координаты точки B ({MasB[0]}, {MasB[1]})");
                Console.WriteLine($"Координаты точки C ({MasC[0]}, {MasC[1]})");

                side1 = A.dist(B); //расчет длин сторон
                side2 = Math.Sqrt(Math.Pow(MasB[0] - MasC[0], 2) + Math.Pow(MasB[1] - MasC[1], 2));
                side3 = Math.Sqrt(Math.Pow(MasC[0] - MasA[0], 2) + Math.Pow(MasC[1] - MasA[1], 2));

                per = side1 + side2 + side3; //периметр
                Console.WriteLine($"Периметр треугольника равен {per}");

                per05 = per / 2;
                area = Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)); //формула Герона

                double round = Convert.ToDouble(area.ToString($"N{3}")); //округление площади

                Console.WriteLine($"Площадь треугольника равна {round}");
            }
             public void In()
             {
                  Console.WriteLine("Введите координаты первой точки треугольника");
                  triangle.A.InPoint(); //вызов метода получения координат точки A
                  Console.WriteLine("Введите координаты второй точки треугольника");
                  //      triangle.SecondLit(point.InX(), point.InY()); //вызов метода получения координат точки B
                   Console.WriteLine("Введите координаты третьей точки треугольника");
                   //     triangle.ThirdLit(point.InX(), point.InY()); //вызов метода получения координат точки C
                 triangle.Ex(); //метод, высчитывающий геометрию треугольника
             }
            
        }

        class Tetragon //класс четырехугольника
        {
            double[] MasA = new double[2]; //массив координат точки A
            double[] MasB = new double[2]; //массив координат точки B
            double[] MasC = new double[2]; //массив координат точки C
            double[] MasD = new double[2]; //массив координат точки D

            public void FirstLit(double x, double y) //метод получения координат точки A
            {
                MasA[0] = x;
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
            public void FourthLit(double x, double y) //метод получения координат точки C
            {
                MasD[0] = x;
                MasD[1] = y;
            }

            double side1, side2, side3, side4, perimetr, area, diagonal; //переменные для геометрии

            public void ExTetr()
            {
                Console.WriteLine($"Координаты точки A ({MasA[0]}; {MasA[1]})");
                Console.WriteLine($"Координаты точки B ({MasB[0]}, {MasB[1]})");
                Console.WriteLine($"Координаты точки C ({MasC[0]}, {MasC[1]})");
                Console.WriteLine($"Координаты точки D ({MasD[0]}, {MasD[1]})");

                side1 = Math.Sqrt(Math.Pow(MasA[0] - MasB[0], 2) + Math.Pow(MasA[1] - MasB[1], 2)); //расчет длин сторон
                side2 = Math.Sqrt(Math.Pow(MasB[0] - MasC[0], 2) + Math.Pow(MasB[1] - MasC[1], 2));
                side3 = Math.Sqrt(Math.Pow(MasC[0] - MasD[0], 2) + Math.Pow(MasC[1] - MasD[1], 2));
                side4 = Math.Sqrt(Math.Pow(MasD[0] - MasA[0], 2) + Math.Pow(MasD[1] - MasA[1], 2));
                diagonal = Math.Sqrt(Math.Pow(MasC[0] - MasA[0], 2) + Math.Pow(MasC[1] - MasA[1], 2)); //диагональ

                perimetr = side1 + side2 + side3 + side4; //периметр

                double HalfperTri1, HalfperTri2; //полупериметры для формулы Герона
                HalfperTri1 = (side1 + side2 + diagonal)/2;
                HalfperTri2 = (side3 + side4 + diagonal) / 2;
                

                double tri1 = Math.Sqrt(HalfperTri1 * (HalfperTri1 - side1) * (HalfperTri1 - side2) * (HalfperTri1 - diagonal)); //составной треугольник 1 четырехугольника

                double tri2 = Math.Sqrt(HalfperTri2 * (HalfperTri2 - diagonal) * (HalfperTri2 - side3) * (HalfperTri2 - side4)); //составной треугольник 2 четырехугольника

                area = tri1 + tri2; //площадь из суммы треугольников
                double round = Convert.ToDouble(area.ToString($"N{2}")); //округление площади

                Console.WriteLine($"Площадь четырехугольника равна {round}");
            }
        }

        class Circle //класс круга
        {
            double[] MasA = new double[2]; //массив координат центра

            public void FirstLit(double x, double y) //метод получения координат центра
            {
                MasA[0] = x;
                MasA[1] = y;
            }

            double radius, perimetr, area; //переменные для геометрии

            public void ExCirc()
            {

                    while (true) //цикл проверки на ввод
                    {
                        Console.WriteLine("Введите целое число (Радиус)");
                        if (int.TryParse(Console.ReadLine(), out int a))
                        {
                            radius = a;
                            break;
                        }
                    }

                Console.WriteLine($"Координаты центра круга ({MasA[0]}; {MasA[1]})");
                
                perimetr = Math.PI * 2 * radius; //периметр
                Console.WriteLine($"Периметр круга равен {perimetr}");

                area = radius*radius*Math.PI; //площадь 
                double round = Convert.ToDouble(area.ToString($"N{2}")); //округление площади

                Console.WriteLine($"Площадь круга равна {round}");
            }
        }

        static void Main(string[] args)
        {
            var point = new Point(); //экземпляр класса точки
            var triangle = new Triangle(); //экземпляр класса треугольник
            var tetragon = new Tetragon();
            var circle = new Circle();

            bool flag = true;

            int getInput;

            while (flag)
            {
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Для треугольника введите <<1>>; для четырехугольника <<2>>; для круга <<3>>. Для выхода введите <<0>>.");
                    if (int.TryParse(Console.ReadLine(), out int a) && ((a==1) || (a==2)|| (a==3)||(a==0)))
                    {
                        getInput = a;
                        break;
                    }
                }

                switch (getInput)
                {
                    case 1:
                       triangle.In();
                        break;

                    case 2:
                        Console.WriteLine("Введите координаты первой точки четырехугольника");
                        tetragon.FirstLit(point.InX(), point.InY()); //вызов метода получения координат точки A
                        Console.WriteLine("Введите координаты второй точки четырехугольника");
                        tetragon.SecondLit(point.InX(), point.InY()); //вызов метода получения координат точки B
                        Console.WriteLine("Введите координаты третьей точки четырехугольника");
                        tetragon.ThirdLit(point.InX(), point.InY()); //вызов метода получения координат точки C
                        Console.WriteLine("Введите координаты четвертой точки четырехугольника");
                        tetragon.FourthLit(point.InX(), point.InY()); //вызов метода получения координат точки D

                        tetragon.ExTetr(); //метод, высчитывающий геометрию четырехугольника
                        break;

                    case 3:
                        Console.WriteLine("Введите координаты центра круга");
                        circle.FirstLit(point.InX(), point.InY()); //вызов метода получения координат центра круга
                        circle.ExCirc(); //метод, высчитывающий геометрию круга
                        break;

                    case 0:
                        flag = false;
                        Console.WriteLine("Вы вышли из программы");
                        break;
                }
            }
             Console.ReadLine();
        }
    }
}
