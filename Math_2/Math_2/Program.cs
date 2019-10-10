using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Number number1 = new Number(121.512, n);
            Number number2 = new Number(122.711, n);
            Number number3 = new Number(112.111, n);
            Number number = new Number(n);
            number = (number2 * number2 + number1) / number3;
            number.Print();

            Console.ReadKey();
        }
    }
}
