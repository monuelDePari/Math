using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_2
{
    class Number
    {
        public double numeric_rounded { get; set; }
        double delta_x = 0, sygma_x = 0;
        public int N { get; set; }
        public double Numeric { get; set; }

        public Number(int n1)
        {
            N = n1;
        }

        public Number(double numeric, int n1)
        {
            Numeric = numeric;
            N = n1;
        }

        public void calculate_delta_sygma()
        {
            numeric_rounded = Math.Round(Numeric, N);
            delta_x = Math.Abs(Numeric - numeric_rounded);
            sygma_x = delta_x / numeric_rounded;
        }

        public void Print()
        {
            Console.WriteLine("Numeric: " + numeric_rounded + " delta " + delta_x + " sygma " + sygma_x);
        }

        public static Number operator +(Number number1, Number number2)
        {
            Console.WriteLine("Write n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Number number = new Number(n);
            number1.calculate_delta_sygma();
            number1.Print();
            number2.calculate_delta_sygma();
            number2.Print();
            number.delta_x = number1.delta_x + number2.delta_x;
            number.sygma_x = Math.Abs(number1.numeric_rounded / (number1.numeric_rounded + number2.numeric_rounded)) * number1.sygma_x + Math.Abs(number2.numeric_rounded / (number1.numeric_rounded + number2.numeric_rounded)) * number2.sygma_x;
            number.Numeric = number1.Numeric + number2.Numeric;
            number.numeric_rounded = Math.Round(number.Numeric, number.N);
            return number;
        }
        public static Number operator -(Number number1, Number number2)
        {
            Console.WriteLine("Write n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Number number = new Number(n);
            number1.calculate_delta_sygma();
            number1.Print();
            number2.calculate_delta_sygma();
            number2.Print();
            number.delta_x = number1.delta_x + number2.delta_x;
            number.sygma_x = (number1.numeric_rounded * number1.sygma_x + number2.numeric_rounded * number2.sygma_x) / (number1.numeric_rounded - number2.numeric_rounded);
            number.Numeric = number1.Numeric - number2.Numeric;
            number.numeric_rounded = Math.Round(number.Numeric, number.N);
            return number;
        }
        public static Number operator *(Number number1, Number number2)
        {
            Console.WriteLine("Write n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Number number = new Number(n);
            number1.calculate_delta_sygma();
            number1.Print();
            number2.calculate_delta_sygma();
            number2.Print();
            number.delta_x = Math.Abs(number2.numeric_rounded) * number1.delta_x + Math.Abs(number1.numeric_rounded) * number2.delta_x;
            number.sygma_x = number1.sygma_x + number2.sygma_x;
            number.Numeric = number1.Numeric * number2.Numeric;
            number.numeric_rounded = Math.Round(number.Numeric, number.N);
            return number;
        }
        public static Number operator /(Number number1, Number number2)
        {
            Console.WriteLine("Write n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Number number = new Number(n);
            number1.calculate_delta_sygma();
            number1.Print();
            number2.calculate_delta_sygma();
            number2.Print();
            number.delta_x = (Math.Abs(number2.numeric_rounded) * number1.delta_x + Math.Abs(number1.numeric_rounded) * number2.delta_x) / Math.Pow(number2.numeric_rounded, 2);
            number.sygma_x = number1.sygma_x + number2.sygma_x;
            number.Numeric = number1.Numeric * number2.Numeric;
            number.numeric_rounded = Math.Round(number.Numeric, number.N);
            return number;
        }
    }
}
