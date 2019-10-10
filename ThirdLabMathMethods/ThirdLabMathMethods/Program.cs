using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLabMathMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            matrix.GenereteWithRandomNumbersMatrix();
            matrix.Print();
            matrix.FindTransposedMatrix(matrix.GetMatrix());
            matrix.FindInvertedMatrix();
            matrix.Kramera();

            Console.ReadKey();
        }
    }
}
