using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Kramera
{
    class Matrix_2x2
    {
        int m = 2, n = 2;
        double[] determinants_value;
        double[] value;
        double[,] GetV;
        double determinant;
        int[] value_of_variables;
        public Matrix_2x2()
        {
            GetV = new double[m, n];
            value = new double[m];
            determinants_value = new double[m];
            input();
        }
        public void input()
        {
            try
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        GetV[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }
                for (int i = 0; i < value.Length; i++)
                {
                    value[i] = Convert.ToDouble(Console.ReadLine());
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message + " / Invalid input");
            }
        }
        public void Calculate_determinant()
        {
            determinant = GetV[0, 0] * GetV[1, 1] - GetV[0, 1] * GetV[1, 0];
        }
        public void Calculate_determinants()
        {
            determinants_value[0] = value[0] * GetV[1, 1] - value[1] * GetV[0, 1];
            determinants_value[1] = GetV[0, 0] * value[1] - GetV[1, 0] * value[0];
        }
        public void Get_Value()
        {
            value_of_variables = new int[m];
            value_of_variables[0] = (int)(determinants_value[0] / determinant); // тут виникає обчислювальна похибка
            value_of_variables[1] = (int)(determinants_value[1] / determinant);
        }
        public void output()
        {
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(GetV[i, j] + " ");
                }
                Console.WriteLine(value[i]);
            }
            Console.WriteLine("Main determinant value is: " + determinant);
            Console.WriteLine("other determinants");
            foreach (var item in determinants_value)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("variables value");
            foreach (var item in value_of_variables)
            {
                Console.WriteLine(item);
            }
        }
    }
}
