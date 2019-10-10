using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Kramera
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix_2x2 matrix = new Matrix_2x2();
            matrix.Calculate_determinant();
            matrix.Calculate_determinants();
            matrix.Get_Value();
            matrix.output();
            Console.ReadLine();
        }
    }
}
