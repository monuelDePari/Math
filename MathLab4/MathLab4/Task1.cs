using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLab4
{
    class Task1
    {
        List<double> XValueList = new List<double>();
        public int Calculate()
        {
            Console.WriteLine("x = tanx");
            int numberOfIterations = 0;
            double i = -1.0;
            bool ifIsTrue = true;
            var x = Math.Round(i, 3);
            while (ifIsTrue)
            {
                if(x >= 1.0)
                {
                    ifIsTrue = false;
                }
                if(Math.Round(Math.Tan(x), 2) - Math.Round(x, 2) == 0)
                {
                    numberOfIterations += 1;
                    XValueList.Add(Math.Round(x, 3));
                }
                x += 0.01;
            }
            return numberOfIterations;
        }
        public void Run()
        {
            Console.WriteLine($"amount of the roots - {Calculate()}");
            foreach (var item in XValueList)
            {
                Console.WriteLine($"x = {item}");
            }
        }
    }
}
