using System;
using System.Reflection.Emit;

class Program
{
    static void Main()
    {
        int maxValueAbs = 1000;
        int accuracy = 3;
        Console.Write("Введите коэффициенты\na: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        if (Math.Abs(a) > maxValueAbs || Math.Abs(b) > maxValueAbs || Math.Abs(c) > maxValueAbs)
        {
            Console.WriteLine("Уравнение имеет слишком большой по модулю коэффициент!");
            Console.ReadKey();
            Environment.Exit(0);
        }
        a = Math.Round(a, accuracy);
        b = Math.Round(b, accuracy);
        c = Math.Round(c, accuracy);
        Solution(a, b, c, accuracy);
        Console.ReadKey();
    }
    static void Solution(double a, double b, double c, int accuracy)
    {
        //double D = Math.Pow(b, 2) - 4 * a * c;
        //if (D > 0 && a == 0 && c == 0)
        //{
        //    double x = 0;
        //    Console.WriteLine("Корень уравнения: " + x);
        //}
        //else if (D > 0 && a == 0)
        //{
        //    double x = Math.Round(-c / b, accuracy);
        //    Console.WriteLine("Корень уравнения: " + x);
        //}
        //else if (D > 0 && c == 0)
        //{
        //    double x1 = 0;
        //    double x2 = Math.Round(-b / 2, accuracy);
        //    Console.WriteLine($"Корни уравнения: {x1}, {x2}");
        //}
        //else
        //{
        //    double x1 = Math.Round((-b + Math.Sqrt(D)) / 2 * a, accuracy);
        //    double x2 = Math.Round((-b - Math.Sqrt(D)) / 2 * a, accuracy);
        //    Console.WriteLine($"Корни уравнения: {x1}, {x2}");
        //}
        //if (D == 0 && a != 0 && b != 0)
        //{
        //    double x = -b / 2 * a;
        //    Console.WriteLine("Корень уравнения: " + Math.Round(x, accuracy));
        //}
        //else
        //{
        //    Console.WriteLine("Данное уравнение не имеет действительных корней");
        //}
        double D = Math.Pow(b, 2) - 4 * a * c;
        if (a == 0)
        {
            if (b == 0) //D = 0
            {
                Console.WriteLine("Это не уравнение!");
            }
            else //D = b^2
            {
                double x1 = Math.Round((-b + Math.Sqrt(D)) / 2 * a, accuracy);
                double x2 = Math.Round((-b - Math.Sqrt(D)) / 2 * a, accuracy);
                Console.WriteLine($"Корни уравнения: {x1}, {x2}");
            }
        }
        else
        {
            if (b == 0)
            {
                if (c == 0) //D = 0
                {
                    double x = 0;
                    Console.WriteLine($"Корень уравнения: {x}");
                }
                else //D = -4*a*c
                {
                    double x1 = Math.Round((-b + Math.Sqrt(D)) / 2 * a, accuracy);
                    double x2 = Math.Round((-b - Math.Sqrt(D)) / 2 * a, accuracy);
                    Console.WriteLine($"Корни уравнения: {x1}, {x2}");
                }
            }
            else //D = b^2 - 4*a*c
            {
                double x1 = Math.Round((-b + Math.Sqrt(D)) / 2 * a, accuracy);
                double x2 = Math.Round((-b - Math.Sqrt(D)) / 2 * a, accuracy);
                Console.WriteLine($"Корни уравнения: {x1}, {x2}");
            }
        }
    }
}