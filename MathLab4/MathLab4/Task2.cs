using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLab4
{
    class Task2
    {
        double fp(double x) { return -3 * Math.Pow(x, 2) + 4 * x; }
        public void Run()
        {
            double a, b;
            Console.WriteLine("Input start of range");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input end of range ");
            b = Convert.ToDouble(Console.ReadLine());
            double e, i = 0;
            Console.WriteLine("Enter e");
            e = Convert.ToDouble(Console.ReadLine());
            if (Math.Abs(fp(a)) < a || Math.Abs(fp(a)) > b || Math.Abs(fp(b)) < a || Math.Abs(fp(b)) > b)
                Console.WriteLine("Error");
            else
            {
                double x, x1;
                x1 = 0.01;
                do
                {
                    x = x1;
                    Console.WriteLine($"{i}\t{x}\t");
                    x1 = -3 * x * x + 4 * x;
                    Console.WriteLine($"{x1}");
                    i++;
                } while (Math.Abs(x1 - x) > e);
            }
            Console.Read();
        }
    }
}
