using System;
using System.Collections.Generic;

namespace Geom
{
    class Program
    {
        public class Point //класс точка
        {
            public int x;
            public double fi;
            public int InX() //метод получения координаты
            {
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Введите целое число");
                    if (int.TryParse(Console.ReadLine(), out int a))
                    {
                        x = a;
                        break;
                    }
                }
                return (x);
            }

            public double InFi()
            {
                while (true) //цикл проверки на ввод угла в полярных координатах
                {
                    Console.WriteLine("Введите число");
                    if (int.TryParse(Console.ReadLine(), out int b))
                    {
                        fi = b;
                        break;
                    }
                }
                return (fi);
            }

            public static int raspr; //переменная ответственная за определение размерности пространства
            public void Dimension()
            {
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Введите N. 1 для полярной, >1 для N-го пространства");
                    if (int.TryParse(Console.ReadLine(), out int a))
                    {
                        raspr = a;
                        break;
                    }
                }   
            }
            
        }

        public class Figure : Point
        {
            public static List<string> nameFigrs = new List<string>(); //для сортировки 1
            public static List<double> ars = new List<double>(); //для сортировки 2
            public static List<string> coordes = new List<string>(); //для сортировки 3
            public static int cout = 0; //счетчик для сортировки
        }

        public class Triangle : Figure //класс треугольника
        {
            public static double side1, side2, side3, per, area, per05; //переменные для геометрии
            string nCoords = ""; //запись для вывода координат

            List<int> A = new List<int>(); //список координат точки А
            List<int> B = new List<int>();
            List<int> C = new List<int>();

            List<double> Apol = new List<double>(); //список координат точки А в полярной системе
            List<double> Bpol = new List<double>();
            List<double> Cpol = new List<double>();

            public void Geometry() //метод вычисления геометрии треугольника 
            {
                if (raspr == 1) //если полярная выбрана
                {
                    for (int i = 0; i < 2; i++)
                    {
                        A.Add(0);
                        B.Add(0);
                        C.Add(0);

                        Apol.Add(0);
                        Bpol.Add(0);
                        Cpol.Add(0);
                    }
                    Console.WriteLine("Введите радиус первой точки треугольника");
                    A[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) первой точки треугольника");
                    A[1] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите радиус второй точки треугольника");
                    B[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) второй точки треугольника");
                    B[1] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите радиус третьей точки треугольника");
                    C[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) третьей точки треугольника");
                    C[1] = Convert.ToInt32(Console.ReadLine());

                    coordes.Add($"Координаты в полярной. A({A[0]};{A[1]}), B({B[0]};{B[1]}), C({C[0]};{C[1]})");
                    
                    Apol[0] = A[0] * Math.Cos((A[1] / 180D) * Math.PI); //пересчет координаты x из полярной
                    Apol[1] = A[0] * Math.Sin((A[1] / 180D) * Math.PI); //y
                                                                     
                    Bpol[0] = B[0] * Math.Cos((B[1] / 180D) * Math.PI);
                    Bpol[1] = B[0] * Math.Sin((B[1] / 180D) * Math.PI);
                                                                   
                    Cpol[0] = C[0] * Math.Cos((C[1] / 180D) * Math.PI);
                    Cpol[1] = C[0] * Math.Sin((C[1] / 180D) * Math.PI);

                    for (int i = 0; i < 2; i++) //2 т.к. две координаты в полярной
                    {
                        side1 += Math.Pow(Apol[i] - Bpol[i], 2);
                        side2 += Math.Pow(Bpol[i] - Cpol[i], 2);
                        side3 += Math.Pow(Cpol[i] - Apol[i], 2);
                    }
                }
                else
                {
                    for (int i = 0; i < raspr; i++)
                    {
                        A.Add(0);
                        B.Add(0);
                        C.Add(0);
                    }
                    
                    Console.WriteLine("Введите координаты первой точки треугольника");
                    nCoords += "A(";
                    for (int i = 0; i < raspr; i++) //координаты первой точки
                    {
                        A[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{A[i]} ";
                    }
                    nCoords += "), ";

                    Console.WriteLine("Введите координаты второй точки треугольника");
                    nCoords += "B(";
                    for (int i = 0; i < raspr; i++)
                    {
                        B[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{B[i]} ";
                    }
                    nCoords += "), ";

                    Console.WriteLine("Введите координаты третьей точки треугольника");
                    nCoords += "C(";
                    for (int i = 0; i < raspr; i++)
                    {
                        C[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{C[i]} ";
                    }
                    nCoords += ")";

                    coordes.Add($"Координаты в декартовой. {nCoords}");

                    for (int i = 0; i < raspr; i++) //расчет длин сторон независимо от N-мерности
                    {
                        side1 += Math.Pow(A[i] - B[i], 2);
                        side2 += Math.Pow(B[i] - C[i], 2);
                        side3 += Math.Pow(C[i] - A[i], 2);
                    }
                }

                side1 = (Math.Round(Math.Sqrt(side1), 2));
                side2 = (Math.Round(Math.Sqrt(side2), 2));
                side3 = (Math.Round(Math.Sqrt(side3), 2));

                per = Math.Round(side1 + side2 + side3, 2); //периметр
                per05 = Math.Round(per / 2, 2); //полупериметр
          
                area = Math.Round(Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)), 2); //формула Герона

                nameFigrs.Add($"Треугольник. Периметр равен {per}.");
                ars.Add(area);
                cout++;
            }
        }

        public class Tetragon : Figure
        {
            public static double side1, side2, side3, side4, per, area, diagonal; //переменные для геометрии
            string nCoords = "";
            List<int> A = new List<int>();
            List<int> B = new List<int>();
            List<int> C = new List<int>();
            List<int> D = new List<int>();

            List<double> Apol = new List<double>();
            List<double> Bpol = new List<double>();
            List<double> Cpol = new List<double>();
            List<double> Dpol = new List<double>();

            public void Geometry() //метод вычисления геометрии четырехугольника 
            {
                if (raspr == 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        A.Add(0);
                        B.Add(0);
                        C.Add(0);
                        D.Add(0);

                        Apol.Add(0);
                        Bpol.Add(0);
                        Cpol.Add(0);
                        Dpol.Add(0);
                    }

                    Console.WriteLine("Введите радиус первой точки четырехугольника");
                    A[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) первой точки четырехугольника");
                    A[1] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите радиус второй точки четырехугольника");
                    B[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) второй точки четырехугольника");
                    B[1] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите радиус третьей точки четырехугольника");
                    C[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) третьей точки четырехугольника");
                    C[1] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите радиус четвертой точки четырехугольника");
                    D[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) четвертой точки четырехугольника");
                    D[1] = Convert.ToInt32(Console.ReadLine());

                    coordes.Add($"Координаты в полярной. A({A[0]};{A[1]}), B({B[0]};{B[1]}), C({C[0]};{C[1]}), D({D[0]};{D[1]})");
           
                    Apol[0] = (A[0] * Math.Cos((A[1] / 180D) * Math.PI)); //x 
                    Apol[1] = (A[0] * Math.Sin((A[1] / 180D) * Math.PI)); //y
                     
                    Bpol[0] = (B[0] * Math.Cos((B[1] / 180D) * Math.PI));
                    Bpol[1] = (B[0] * Math.Sin((B[1] / 180D) * Math.PI));
                     
                    Cpol[0] = (C[0] * Math.Cos((C[1] / 180D) * Math.PI));
                    Cpol[1] = (C[0] * Math.Sin((C[1] / 180D) * Math.PI));
                     
                    Dpol[0] = (D[0] * Math.Cos((D[1] / 180D) * Math.PI));
                    Dpol[1] = (D[0] * Math.Sin((D[1] / 180D) * Math.PI));

                    for (int i = 0; i < 2; i++)
                    {
                        side1 += Math.Pow(A[i] - B[i], 2);
                        side2 += Math.Pow(B[i] - C[i], 2);
                        side3 += Math.Pow(C[i] - D[i], 2);
                        side4 += Math.Pow(D[i] - A[i], 2);
                        diagonal += Math.Pow(A[i] - C[i], 2);
                    }
                }
                else
                {
                    for (int i = 0; i < raspr; i++)
                    {
                        A.Add(0);
                        B.Add(0);
                        C.Add(0);
                        D.Add(0);
                    }

                    Console.WriteLine("Введите координаты первой точки четырехугольника");
                    nCoords += "A(";
                    for (int i = 0; i < raspr; i++) //координаты первой точки
                    {
                        A[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{A[i]} ";
                    }
                    nCoords += "), ";

                    Console.WriteLine("Введите координаты второй точки четырехугольника");
                    nCoords += "B(";
                    for (int i = 0; i < raspr; i++)
                    {
                        B[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{B[i]} ";
                    }
                    nCoords += "), ";

                    Console.WriteLine("Введите координаты третьей точки четырехугольника");
                    nCoords += "C(";
                    for (int i = 0; i < raspr; i++)
                    {
                        C[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{C[i]} ";
                    }
                    nCoords += "), ";

                    Console.WriteLine("Введите координаты четвертой точки четырехугольника");
                    nCoords += "D(";
                    for (int i = 0; i < raspr; i++)
                    {
                        D[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{D[i]} ";
                    }
                    nCoords += ")";

                    coordes.Add($"Координаты в декартовой. {nCoords}");

                    for (int i = 0; i < raspr; i++)
                    {
                        side1 += Math.Pow(A[i] - B[i], 2);
                        side2 += Math.Pow(B[i] - C[i], 2);
                        side3 += Math.Pow(C[i] - D[i], 2);
                        side4 += Math.Pow(D[i] - A[i], 2);
                        diagonal += Math.Pow(A[i] - C[i], 2);
                    }
                }
                
                side1 = (Math.Round(Math.Sqrt(side1), 2));
                side2 = (Math.Round(Math.Sqrt(side2), 2));
                side3 = (Math.Round(Math.Sqrt(side3), 2));
                side4 = (Math.Round(Math.Sqrt(side4), 2));

                per = Math.Round(side1 + side2 + side3 + side4, 2); //периметр

                diagonal = Math.Sqrt(diagonal); //диагональ

                double HalfperTri1, HalfperTri2; //полупериметры для формулы Герона
                HalfperTri1 = (side1 + side2 + diagonal) / 2;
                HalfperTri2 = (side3 + side4 + diagonal) / 2;

                double tri1 = Math.Sqrt(HalfperTri1 * (HalfperTri1 - side1) * (HalfperTri1 - side2) * (HalfperTri1 - diagonal)); //составной треугольник 1 четырехугольника
                double tri2 = Math.Sqrt(HalfperTri2 * (HalfperTri2 - diagonal) * (HalfperTri2 - side3) * (HalfperTri2 - side4)); //составной треугольник 2 четырехугольника

                area = Math.Round(tri1 + tri2, 2); //площадь из суммы треугольников

                nameFigrs.Add($"Четырехугольник. Периметр равен {per}.");
                ars.Add(area);
                cout++;

            }
        }//конец класса четырехугольник

        public class Circle : Figure
        {
            public static double per, area; //переменные для геометрии
            public static int radius;
            string nCoords = "";
            List<int> A = new List<int>();
            List<double> Apol = new List<double>();

            public void Geometry() 
            {
                if (raspr == 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        A.Add(0);
                        Apol.Add(0);
                    }

                    Console.WriteLine("Введите радиус точки круга");
                    A[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите угол (в градусах) точки круга");
                    A[1] = Convert.ToInt32(Console.ReadLine());

                    Apol[0] = Math.Round(A[0] * Math.Cos((A[1] / 180D) * Math.PI), 2); //x
                    Apol[1] = Math.Round(A[0] * Math.Sin((A[1] / 180D) * Math.PI), 2); //y

                    coordes.Add($"Координаты в полярной. O({A[0]};{A[1]}). Пересчитанные в декартову: O({Apol[0]};{Apol[1]})");
                }
                else
                {
                    for (int i = 0; i < raspr; i++)
                    {
                        A.Add(0);
                    }

                    Console.WriteLine("Введите координаты точки круга");
                    nCoords += "A(";
                    for (int i = 0; i < raspr; i++) //координаты первой точки
                    {
                        A[i] = Convert.ToInt32(Console.ReadLine());
                        nCoords += $"{A[i]} ";
                    }
                    nCoords += ")";

                    coordes.Add($"Координаты в декартовой. {nCoords}");
                }

                Console.WriteLine("                    Введите радиус круга                    ");
                radius = Math.Abs(InX());

                per = Math.Round(Math.PI * 2 * radius, 2); //периметр

                area = Math.Round(radius * radius * Math.PI, 2); //площадь

                nameFigrs.Add($"Круг. Периметр равен {per}.");
                ars.Add(area);
                cout++;

            }

        }

        static void Main(string[] args)
        {
            
            var triangle = new Triangle(); //экземпляр класса треугольник
            var tetragon = new Tetragon();
            var circle = new Circle();
            var point = new Point();
            int getInput;  
            bool flag = true;

            point.Dimension(); //определение размерности пространства

            while (flag)
            {
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Для треугольника введите <<1>>; для четырехугольника <<2>>; для круга <<3>>. Для выхода введите <<0>>.");
                    if (int.TryParse(Console.ReadLine(), out int a) && ((a == 1) || (a == 2) || (a == 3) || (a == 0)))
                    {
                        getInput = a;
                        break;
                    }
                }
                switch (getInput)
                {
                    case 1:
                        triangle.Geometry();
                        break;
                    case 2:
                        tetragon.Geometry();
                        break;
                    case 3:
                        circle.Geometry();
                        break;
                    case 0:

                        for (int i = 0; i < Figure.cout; i++)
                        {
                            //сортировка по площади
                            for (int j = 0; j < Figure.cout - 1; j++)
                            {
                                if (Figure.ars[j] > Figure.ars[j + 1])
                                {
                                    double zam1 = Figure.ars[j];
                                    Figure.ars[j] = Figure.ars[j + 1];
                                    Figure.ars[j + 1] = zam1;

                                    string zam2 = Figure.nameFigrs[j];
                                    Figure.nameFigrs[j] = Figure.nameFigrs[j + 1];
                                    Figure.nameFigrs[j + 1] = zam2;

                                    string zam3 = Figure.coordes[j];
                                    Figure.coordes[j] = Figure.coordes[j + 1];
                                    Figure.coordes[j + 1] = zam3;
                                }
                            }
                        }

                        for (int i = 0; i < Figure.cout; i++)
                        {
                            Console.WriteLine($"{Figure.nameFigrs[i]} Площадь равна {Figure.ars[i]}");
                            Console.WriteLine($"{Figure.coordes[i]}");
                        }
                        flag = false;
                        Console.WriteLine("\nВы вышли из программы");

                        break;
                }
            }
        }
    }
}
