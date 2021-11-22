using System;
using System.Collections.Generic;

namespace CorrectedDots
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
                while (true) //цикл проверки на ввод
                {
                    Console.WriteLine("Введите число");
                    if (double.TryParse(Console.ReadLine(), out double b))
                    {
                        fi = b;
                        break;
                    }
                }
                return (fi);
            }
        }

        public class Figure: Point
        {
            public double Distance2D(double a, double b, double c, double d)
            {
                return (Math.Round(Math.Sqrt(Math.Pow(a - c, 2) + Math.Pow(b - d, 2)), 2));
            }
            public double Distance3D(double a, double b, double c, double d, double e, double f)
            {
                return (Math.Round(Math.Sqrt(Math.Pow(a - d, 2) + Math.Pow(b - e, 2) + Math.Pow(c - f, 2)), 2));
            }
            public double Distance4D(double a/*1*/, double b, double c, double d, double e/*5*/, double f, double g, double h)
            {
                return (Math.Round(Math.Sqrt(Math.Pow(a - e, 2) + Math.Pow(b - f, 2) + Math.Pow(c - g, 2) + Math.Pow(d - h, 2)), 2));
            }

            public static List<string> nameFigrs = new List<string>(); //для сортировки 1
            public static List<double> ars = new List<double>(); //для сортировки 2
            public static int cout = 0; //счетчик для сортировки

            public static List<double> coords = new List<double>(); //список последовательных координат точек .................................................................//был сменен тип с инта на дабл
            public static List<double> radFi = new List<double>();

            public void Zam(int a)
            {
                for (int i = 0; i < a; i++) //перевод из полярных координат в декартовы
                {
                    if (i % 2 != 0)
                    {
                        radFi.Add(coords[i - 1] * Math.Sin((coords[i] / 180D) * Math.PI));
                    }
                    else
                    {
                        radFi.Add(coords[i] * Math.Cos((coords[i + 1] / 180D) * Math.PI));
                    }

                }
            }

            public void Create() //метод заполнения списка координат -------------------------------------------------------------------------------------Использовать под циклом в мейне
            {
                coords.Add(InX());
            }

            public void CreatePol()
            {
                coords.Add(InFi());
            }

            public static void Clean(int j)
            {
                int i = j;
                while (i >= 0) //обнуление координат
                {
                    coords.RemoveAt(i); 
                    i--;
                }
            }
            public static void CleanPol(int j)
            {
                int i = j;
                while (i >= 0) //обнуление координат
                {
                    radFi.RemoveAt(i);
                    i--;
                }
            }
        }

        public class Triangle : Figure //класс треугольника
        {
            public static double side1, side2, side3, per, area, per05; //переменные для геометрии

            public void Geometry2D() //метод вычисления геометрии треугольника в 2D, с последующим добавлением в массив
            {
                
                side1 = Distance2D(coords[0], coords[1], coords[2], coords[3]);
                side2 = Distance2D(coords[2], coords[3], coords[4], coords[5]);
                side3 = Distance2D(coords[4], coords[5], coords[0], coords[1]);

                per = Math.Round(side1 + side2 + side3,2); //периметр
                per05 = per / 2; //полупериметр
                area = Math.Round(Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)), 2); //формула Герона
                
                nameFigrs.Add($"Треугольник в 2D. А({coords[0]}; {coords[1]}), В({coords[2]}; {coords[3]}), С({coords[4]}; {coords[5]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(5);
                
            }

            public void Geometry3D() //метод вычисления геометрии треугольника в 3D, с последующим добавлением в массив
            {
                side1 = Distance3D(coords[0], coords[1], coords[2], coords[3], coords[4], coords[5]);
                side2 = Distance3D(coords[3], coords[4], coords[5], coords[6], coords[7], coords[8]);
                side3 = Distance3D(coords[6], coords[7], coords[8], coords[0], coords[1], coords[2]);

                per = Math.Round(side1 + side2 + side3,2); //периметр
                per05 = per / 2; //полупериметр
                area = Math.Round(Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)), 2); //формула Герона

                nameFigrs.Add($"Треугольник в 3D. А({coords[0]}; {coords[1]}; {coords[2]}), В({coords[3]}; {coords[4]}; {coords[5]}), С({coords[6]}; {coords[7]}; {coords[8]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(8);
            }

            public void Geometry4D() //метод вычисления геометрии треугольника в 4D, с последующим добавлением в массив
            {
                side1 = Distance4D(coords[0], coords[1], coords[2], coords[3], coords[4], coords[5], coords[6], coords[7]);
                side2 = Distance4D(coords[4], coords[5], coords[6], coords[7], coords[8], coords[9], coords[10], coords[11]);
                side3 = Distance4D(coords[8], coords[9], coords[10], coords[11], coords[0], coords[1], coords[2], coords[3]);

                per = Math.Round(side1 + side2 + side3, 2); //периметр
                per05 = per / 2; //полупериметр
                area = Math.Round(Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)), 2); //формула Герона

                nameFigrs.Add($"Треугольник в 4D. А({coords[0]}; {coords[1]}; {coords[2]}; {coords[3]}), В({coords[4]}; {coords[5]}; {coords[6]}; {coords[7]}), С({coords[8]}; {coords[9]}; {coords[10]}; {coords[11]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(11);
            }

            public void GeometryPol()
            {
                Zam(6);

                side1 = Distance2D(radFi[0], radFi[1], radFi[2], radFi[3]);
                side2 = Distance2D(radFi[2], radFi[3], radFi[4], radFi[5]);
                side3 = Distance2D(radFi[4], radFi[5], radFi[0], radFi[1]);

                per = Math.Round(side1 + side2 + side3, 2); //периметр
                per05 = per / 2; //полупериметр
                area = Math.Round(Math.Sqrt(per05 * (per05 - side1) * (per05 - side2) * (per05 - side3)), 2); //формула Герона

                nameFigrs.Add($"Треугольник в полярной 2D. А({coords[0]}; {coords[1]}), В({coords[2]}; {coords[3]}), С({coords[4]}; {coords[5]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(5);
                CleanPol(5);
            }

        } //конец класса треугольник

        public class Tetragon: Figure
        {
            public static double side1, side2, side3, side4, per, area, diagonal; //переменные для геометрии

            public void Geometry2D() //метод вычисления геометрии четырехугольника в 2D, с последующим добавлением в массив
            {
                side1 = Distance2D(coords[0], coords[1], coords[2], coords[3]);
                side2 = Distance2D(coords[2], coords[3], coords[4], coords[5]);
                side3 = Distance2D(coords[4], coords[5], coords[6], coords[7]);
                side4 = Distance2D(coords[6], coords[7], coords[0], coords[1]);


                per = Math.Round(side1 + side2 + side3 + side4,2); //периметр
                
                diagonal = Math.Sqrt(Math.Pow(coords[0] - coords[4], 2) + Math.Pow(coords[1] - coords[5], 2)); //диагональ

                double HalfperTri1, HalfperTri2; //полупериметры для формулы Герона
                HalfperTri1 = (side1 + side2 + diagonal) / 2;
                HalfperTri2 = (side3 + side4 + diagonal) / 2;
                
                double tri1 = Math.Sqrt(HalfperTri1 * (HalfperTri1 - side1) * (HalfperTri1 - side2) * (HalfperTri1 - diagonal)); //составной треугольник 1 четырехугольника
                double tri2 = Math.Sqrt(HalfperTri2 * (HalfperTri2 - diagonal) * (HalfperTri2 - side3) * (HalfperTri2 - side4)); //составной треугольник 2 четырехугольника

                area = Math.Round(tri1 + tri2, 2); //площадь из суммы треугольников

                nameFigrs.Add($"Четырехугольник в 2D. А({coords[0]}; {coords[1]}), В({coords[2]}; {coords[3]}), С({coords[4]}; {coords[5]}), D({coords[6]}; {coords[7]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(7);
            }

            public void Geometry3D() //метод вычисления геометрии четырехугольника в 3D, с последующим добавлением в массив
            {
                side1 = Distance3D(coords[0], coords[1], coords[2], coords[3], coords[4], coords[5]);          
                side2 = Distance3D(coords[3], coords[4], coords[5], coords[6], coords[7], coords[8]);
                side3 = Distance3D(coords[6], coords[7], coords[8], coords[9], coords[10], coords[11]);
                side4 = Distance3D(coords[9], coords[10], coords[11], coords[0], coords[1], coords[2]);

                per = Math.Round(side1 + side2 + side3 + side4, 2); //периметр

                diagonal = Math.Sqrt(Math.Pow(coords[0] - coords[6], 2) + Math.Pow(coords[1] - coords[7], 2) + (Math.Pow(coords[2] - coords[8], 2))); //диагональ

                double HalfperTri1, HalfperTri2; //полупериметры для формулы Герона
                HalfperTri1 = (side1 + side2 + diagonal) / 2;
                HalfperTri2 = (side3 + side4 + diagonal) / 2;

                double tri1 = Math.Sqrt(HalfperTri1 * (HalfperTri1 - side1) * (HalfperTri1 - side2) * (HalfperTri1 - diagonal)); //составной треугольник 1 четырехугольника
                double tri2 = Math.Sqrt(HalfperTri2 * (HalfperTri2 - diagonal) * (HalfperTri2 - side3) * (HalfperTri2 - side4)); //составной треугольник 2 четырехугольника

                area = Math.Round(tri1 + tri2, 2); //площадь из суммы треугольников

                nameFigrs.Add($"Четырехугольник в 3D. А({coords[0]}; {coords[1]}; {coords[2]}), В({coords[3]}; {coords[4]}; {coords[5]}), С({coords[6]}; {coords[7]}; {coords[8]}), D({coords[9]}; {coords[10]}; {coords[11]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(11);
            }

            public void Geometry4D() //метод вычисления геометрии треугольника в 4D, с последующим добавлением в массив
            {
                side1 = Distance4D(coords[0], coords[1], coords[2], coords[3], coords[4], coords[5], coords[6], coords[7]);
                side2 = Distance4D(coords[4], coords[5], coords[6], coords[7], coords[8], coords[9], coords[10], coords[11]);
                side3 = Distance4D(coords[8], coords[9], coords[10], coords[11], coords[12], coords[13], coords[14], coords[15]);
                side4 = Distance4D(coords[12], coords[13], coords[14], coords[15], coords[0], coords[1], coords[2], coords[3]);

                per = Math.Round(side1 + side2 + side3 + side4, 2); //периметр

                diagonal = Math.Sqrt(Math.Pow(coords[0] - coords[8], 2) + Math.Pow(coords[1] - coords[9], 2) + (Math.Pow(coords[2] - coords[10], 2) + (Math.Pow(coords[3] - coords[11], 2)))); //диагональ

                double HalfperTri1, HalfperTri2; //полупериметры для формулы Герона
                HalfperTri1 = (side1 + side2 + diagonal) / 2;
                HalfperTri2 = (side3 + side4 + diagonal) / 2;

                double tri1 = Math.Sqrt(HalfperTri1 * (HalfperTri1 - side1) * (HalfperTri1 - side2) * (HalfperTri1 - diagonal)); //составной треугольник 1 четырехугольника
                double tri2 = Math.Sqrt(HalfperTri2 * (HalfperTri2 - diagonal) * (HalfperTri2 - side3) * (HalfperTri2 - side4)); //составной треугольник 2 четырехугольника

                area = Math.Round(tri1 + tri2, 2); //площадь из суммы треугольников

                nameFigrs.Add($"Четырехугольник в 4D. А({coords[0]}; {coords[1]}; {coords[2]}; {coords[3]}), В({coords[4]}; {coords[5]}; {coords[6]}; {coords[7]}), С({coords[8]}; {coords[9]}; {coords[10]}; {coords[11]}), D({coords[12]}; {coords[13]}; {coords[14]}; {coords[15]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(15);
            }
            public void GeometryPol()
            {
                Zam(8);

                side1 = Distance2D(radFi[0], radFi[1], radFi[2], radFi[3]);
                side2 = Distance2D(radFi[2], radFi[3], radFi[4], radFi[5]);
                side3 = Distance2D(radFi[4], radFi[5], radFi[6], radFi[7]);
                side4 = Distance2D(radFi[6], radFi[7], radFi[0], radFi[1]);


                per = Math.Round(side1 + side2 + side3 + side4, 2); //периметр

                diagonal = Math.Sqrt(Math.Pow(coords[0] - coords[4], 2) + Math.Pow(coords[1] - coords[5], 2)); //диагональ

                double HalfperTri1, HalfperTri2; //полупериметры для формулы Герона
                HalfperTri1 = (side1 + side2 + diagonal) / 2;
                HalfperTri2 = (side3 + side4 + diagonal) / 2;

                double tri1 = Math.Sqrt(HalfperTri1 * (HalfperTri1 - side1) * (HalfperTri1 - side2) * (HalfperTri1 - diagonal)); //составной треугольник 1 четырехугольника
                double tri2 = Math.Sqrt(HalfperTri2 * (HalfperTri2 - diagonal) * (HalfperTri2 - side3) * (HalfperTri2 - side4)); //составной треугольник 2 четырехугольника

                area = Math.Round(tri1 + tri2, 2); //площадь из суммы треугольников

                nameFigrs.Add($"Четырехугольник в полярной 2D. А({coords[0]}; {coords[1]}), В({coords[2]}; {coords[3]}), С({coords[4]}; {coords[5]}), D({coords[6]}; {coords[7]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(7);
                CleanPol(7);
            }

        }//конец класса четырехугольник

        public class Circle : Figure
        {
            public static double per, area; //переменные для геометрии
            public static int radius;
            public void Geometry2D() //метод вычисления геометрии четырехугольника в 2D, с последующим добавлением в массив
            {
                Console.WriteLine("                    Введите радиус                    ");
                radius = Math.Abs(InX());

                per = Math.Round(Math.PI * 2 * radius,2); //периметр

                area = Math.Round(radius * radius * Math.PI, 2); //площадь

                nameFigrs.Add($"Круг в 2D. O({coords[0]}; {coords[1]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(1);
            }

            public void Geometry3D() //метод вычисления геометрии четырехугольника в 3D, с последующим добавлением в массив
            {
                Console.WriteLine("                    Введите радиус                    ");
                radius = Math.Abs(InX());

                per = Math.Round(Math.PI * 2 * radius,2); //периметр

                area = Math.Round(radius * radius * Math.PI, 2); //площадь

                nameFigrs.Add($"Круг в 3D. O({coords[0]}; {coords[1]}; {coords[2]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(2);
            }

            public void Geometry4D()
            {
                Console.WriteLine("                    Введите радиус                    ");
                radius = Math.Abs(InX());

                per = Math.Round(Math.PI * 2 * radius, 2); //периметр

                area = Math.Round(radius * radius * Math.PI, 2); //площадь

                nameFigrs.Add($"Круг в 4D. O({coords[0]}; {coords[1]}; {coords[2]}; {coords[3]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(3);
            }

            public void GeometryPol()
            {
                Console.WriteLine("                    Введите радиус                    ");
                radius = Math.Abs(InX());

                per = Math.Round(Math.PI * 2 * radius, 2); //периметр

                area = Math.Round(radius * radius * Math.PI, 2); //площадь

                nameFigrs.Add($"Круг в полярных 2D. O({coords[0]}; {coords[1]}). Периметр равен {per}.");
                ars.Add(area);
                cout++;

                Clean(1);
            }

        } //конец класса круг

        static void Main(string[] args)
        {
            
            var figure = new Figure();
            var triangle = new Triangle(); //экземпляр класса треугольник
            var tetragon = new Tetragon();
            var circle = new Circle();

            int getInput;
            int sisCoor = 0;
            bool flag = true;
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

                if (getInput != 0)
                {
                    Console.WriteLine("Выберите систему отсчета: 1 - 2D; 2 - 3D; 3 - 4D; 4 - полярные 2D");
                    while (true) //цикл проверки на ввод
                    {
                        if (int.TryParse(Console.ReadLine(), out int a) && ((a == 1) || (a == 2) || (a == 3) || (a == 4)))
                        {
                            sisCoor = a;
                            break;
                        }
                    }
                    Console.WriteLine("Ввод координат точек следует производить последовательно. То есть: сначала X1, Y1, Z1, далее X2, Y2, Z2 и так далее.");
                }

                
                switch (getInput)
                {
                    case 1: //треугольник
                        
                        switch (sisCoor)
                        {
                            case 1: //2d
                                Console.WriteLine("Координаты для треугольника в 2D");
                                int i = 0;
                                while (i < 6)
                                {
                                    figure.Create();
                                    i++;
                                }

                                triangle.Geometry2D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 2: //3d
                                Console.WriteLine("Координаты для треугольника в 3D");
                                i = 0;
                                while (i < 9)
                                {
                                    figure.Create();
                                    i++;
                                }

                                triangle.Geometry3D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 3: //4d
                                Console.WriteLine("Координаты для треугольника в 4D");
                                i = 0;
                                while (i < 12)
                                {
                                    figure.Create();
                                    i++;
                                }

                                triangle.Geometry4D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 4:
                                Console.WriteLine("Координаты для треугольника в полярных 2D. Сначала следует вводить радиус, затем угол в градусах, и так для каждой переменной");
                                i = 0;
                                while (i < 6)
                                {
                                    figure.CreatePol();
                                    i++;
                                }

                                triangle.GeometryPol();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            
                        }

                        break;

                    case 2: //4уг

                        switch (sisCoor)
                        {
                            case 1: //2d
                                Console.WriteLine("Координаты для четырехугольника в 2D");
                                int i = 0;
                                while (i < 8)
                                {
                                    figure.Create();
                                    i++;
                                }

                                tetragon.Geometry2D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 2:
                                Console.WriteLine("Координаты для четырехугольника в 3D");
                                i = 0;
                                while (i < 12)
                                {
                                    figure.Create();
                                    i++;
                                }

                                tetragon.Geometry3D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 3:
                                Console.WriteLine("Координаты для четырехугольника в 4D");
                                i = 0;
                                while (i < 16)
                                {
                                    figure.Create();
                                    i++;
                                }

                                tetragon.Geometry4D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 4:
                                Console.WriteLine("Координаты для четырехугольника в 2D. Сначала следует вводить радиус, затем угол в градусах, и так для каждой переменной");
                                i = 0;
                                while (i < 8)
                                {
                                    figure.CreatePol();
                                    i++;
                                }

                                tetragon.GeometryPol();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                        }

                        break;

                    case 3: //круг

                        switch (sisCoor)
                        {
                            case 1: //2d
                                Console.WriteLine("Координаты для центра круга в 2D");
                                int i = 0;
                                while (i < 2)
                                {
                                    figure.Create();
                                    i++;
                                }

                                circle.Geometry2D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 2: //3d
                                Console.WriteLine("Координаты для центра круга в 3D");
                                i = 0;
                                while (i < 3)
                                {
                                    figure.Create();
                                    i++;
                                }

                                circle.Geometry3D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 3:
                                Console.WriteLine("Координаты для центра круга в 4D");
                                i = 0;
                                while (i < 4)
                                {
                                    figure.Create();
                                    i++;
                                }

                                circle.Geometry4D();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;
                            case 4:
                                Console.WriteLine("Координаты для центра круга в 2D. Сначала следует вводить радиус, затем угол в градусах, и так для каждой переменной");
                                i = 0;
                                while (i < 2)
                                {
                                    figure.CreatePol();
                                    i++;
                                }

                                circle.GeometryPol();
                                Console.WriteLine("_________________Конец ввода и подсчета величин_________________");
                                break;

                        }

                        break;

                    case 0:

                        for (int i = 0; i < Figure.cout; i++)
                        {
                            //сортировка по площади
                            for (int j = 0; j < Figure.cout -1; j++)
                            {
                                 if (Figure.ars[j] > Figure.ars[j + 1])
                                 {
                                        double zam1 = Figure.ars[j];
                                        Figure.ars[j] = Figure.ars[j + 1];
                                        Figure.ars[j + 1] = zam1;

                                        string zam2 = Figure.nameFigrs[j];
                                        Figure.nameFigrs[j] = Figure.nameFigrs[j + 1];
                                        Figure.nameFigrs[j + 1] = zam2;
                                 }
                            }
                        }

                        for (int i = 0; i < Figure.cout; i++)
                        {
                            Console.WriteLine($"{Figure.nameFigrs[i]} Площадь равна {Figure.ars[i]}");
                        }
                        flag = false;
                        Console.WriteLine("Вы вышли из программы");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
