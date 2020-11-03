using System;
using System.Collections.Generic;
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
        List<double> roots = Solution(a, b, c, accuracy, maxValueAbs);
        if (roots.Count == 0)
        {
            Console.WriteLine("Это не уравнение!");
        }
        else if(roots.Count == 1)
        {
            Console.WriteLine($"Корень уравнения: {roots[0]}");
        }
        else
        {
            if (roots[0] > maxValueAbs)
            {
                Console.WriteLine($"Корни уравнения: {roots[0] / Math.Pow(maxValueAbs, 2)}i, {roots[1] / Math.Pow(maxValueAbs, 2)}i");
            }
            else
            {
                Console.WriteLine($"Корни уравнения: {roots[0]}, {roots[1]}");
            }
        }
        Console.ReadKey();
    }
    static List<double> Solution(double a, double b, double c, int accuracy, int maxValueAbs)
    {
        List<double> roots = new List<double>();
        double D = Math.Pow(b, 2) - 4 * a * c;
        if (D > 0) //b^2 > 4*a*c
        {
            if (a == 0 && c == 0)
            {
                double x = 0;
                roots.Add(x);
            }
            else if (a == 0)
            {
                double x = -c / b;
                roots.Add(x);
            }
            else if (c == 0)
            {
                double x1 = 0;
                double x2 = -b / a;
                roots.Add(x1);
                roots.Add(x2);
            }
            else
            {
                double x1 = Math.Round((-b + Math.Sqrt(D)) / 2 * a, accuracy);
                double x2 = Math.Round((-b - Math.Sqrt(D)) / 2 * a, accuracy);
                roots.Add(x1);
                roots.Add(x2);
            }
        }
        else if (D == 0) //b^2 = 4*a*c
        {
            if (b == 0 && a == 0)
            {
                return roots;
            }
            else if (b == 0 && c == 0)
            {
                double x = 0;
                roots.Add(x);
            }
            else
            {
                double x = Math.Round(-b / 2 * a, accuracy);
                roots.Add(x);
            }
        }
        else //b^2 < 4*a*c --> complex numbers
        {
            if (b == 0) //D = - 4*a*c
            {
                double x1 = -Math.Round(Math.Sqrt(-D) / 2 * a, accuracy);
                double x2 = Math.Round(Math.Sqrt(-D) / 2 * a, accuracy);
                roots.Add(x1 * Math.Pow(maxValueAbs, 2));
                roots.Add(x2 * Math.Pow(maxValueAbs, 2));
            }
            else
            {
                double x1 = -Math.Round(-b + Math.Sqrt(-D) / 2 * a, accuracy);
                double x2 = Math.Round(-b - Math.Sqrt(-D) / 2 * a, accuracy);
                roots.Add(x1 * Math.Pow(maxValueAbs, 2));
                roots.Add(x2 * Math.Pow(maxValueAbs, 2));
            }
        }
        return roots;
    }
}