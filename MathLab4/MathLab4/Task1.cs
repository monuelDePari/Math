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
        public void Calculate()
        {
            Console.WriteLine("x = tanx");
            double i = -1.0;
            bool ifIsTrue = true;
            var x = Math.Round(i, 3); 
            while (ifIsTrue)
            {
                if(x >= 1.0)
                {
                    ifIsTrue = false;
                }
                if(Math.Round(Math.Tan(x), 3) - Math.Round(x, 3) == 0)
                {
                    XValueList.Add(Math.Round(x, 3));
                }
                x += 0.01;
            }
        }
        public void Run()
        {
            Calculate();
            var PositiveXValueList = from t in XValueList
                                     where t >= 0
                                     orderby t
                                     select t;
            Console.WriteLine($"amount of the roots - {PositiveXValueList.Count()}");
            foreach (var item in PositiveXValueList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
