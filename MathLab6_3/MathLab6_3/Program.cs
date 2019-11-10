using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLab6_3
{
    class Program
    {
        public class MatrixOperations
        {
            public static double[] cramersRule(double[,] a, double[] y)
            {
                double det = getDet(a, a.Length);
                double[] x = new double[y.Length];
                for (int i = 0; i < y.Length; i++)
                {
                    double[,] temp = getTempMatrix(a, y, i);
                    double tempDet = getDet(temp, temp.Length);
                    x[i] = tempDet / det;
                }
                return x;
            }
            public static double getDet(double[,] a, int n)
            {
                double det = 0, sign = 1;
                int p = 0, q = 0;
                if (n == 1) { det = a[0, 0]; }
                else
                {
                    double[,] b = new double[n - 1, n - 1];
                    for (int x = 0; x < n; x++)
                    {
                        p = 0; q = 0;
                        for (int i = 1; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (j != x)
                                {
                                    b[p, q++] = a[i, j];
                                    if (q % (n - 1) == 0) { p++; q = 0; }
                                }
                            }
                        }
                        det = det + a[0, x] * getDet(b, n - 1) * sign;
                        sign = -sign;
                    }
                }
                return det;
            }
            public static double[,] getTempMatrix(double[,] a, double[] y, int index)
            {
                double[,] temp = new double[a.Length, a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (j == index) { try { temp[i, j] = y[i]; } catch (Exception e) { } }
                        else { try { temp[i, j] = a[i, j]; } catch (Exception e) { } }
                    }
                }
                return temp;
            }
        }
        public class Second
        {
            double[] y;
            double[] x;
            double xMin; 
            double xMax; 
            public double[] coef;
            public Second() {
                y = new double[100]; 
                x = new double[100]; 
                xMin = 0.2;
                xMax = 12.4;
                fillArrays(); 
                coef = First.equalitySystemSolution(x, y);
                for (int i = 0; i < coef.Length; i++) 
                { 
                    coef[i] /= Math.Pow(10, 12);
                    coef[i] = Math.Round(coef[i] * 1000.0) / 1000.0; 
                } 
            }
            public void fillArrays() 
            {
                x[0] = xMin; 
                y[0] = getY(xMin);
                for (int i = 1; i < 100; i++)
                {
                    x[i] = x[i - 1] + (xMax - xMin) / 100.0; y[i] = getY(x[i]);
                } 
            }
            public double getY(double x) 
            { 
                return 23.5 * 7 * Math.Exp(0.34 * 7 * x) + Math.Sqrt(Math.Pow(x, 1.4 * 7)); 
            }
        }
        public class First
        {
            public static double[] equalitySystemSolution(double[] x, double[] y)
            {
                double xSum = 0, ySum = 0, xySum = 0, x2Sum = 0, x2ySum = 0, x3Sum = 0, x4Sum = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    xSum += x[i];
                    ySum += y[i];
                    xySum += x[i] * y[i];
                    x2Sum += Math.Pow(x[i], 2);
                    x2ySum += Math.Pow(x[i], 2) * y[i];
                    x3Sum += Math.Pow(x[i], 3);
                    x4Sum += Math.Pow(x[i], 4);
                }
                double[,] equalSys = { { x.Length * 1.0, xSum, x2Sum }, { xSum, x2Sum, x3Sum }, { x2Sum, x3Sum, x4Sum } };
                double[] solArr = { ySum, xySum, x2ySum };
                double[] a = MatrixOperations.cramersRule(equalSys, solArr);
                return a;
            }
        }
        public class Third
        {
            private double[] x = new double[] { 1.2, 1.4, 1.6, 1.8, 2, 2.2, 2.4, 2.6 };
            private double[] y = new double[] { 2.325, 2.515, 2.638, 2.700, 2.696, 2.626, 2.491, 2.291 };
            public double[] quadCoef;
            public double[] linearCoef;
            public Third() { quadCoef = getQuadCoef(); linearCoef = getLinearCoef(); }
            public double[] getQuadCoef()
            {
                return First.equalitySystemSolution(x, y);
            }
            public double[] getLinearCoef()
            {
                double xSum = 0, ySum = 0, x2Sum = 0, xySum = 0, count = x.Length * 1.0;
                for (int i = 0; i < x.Length; i++)
                {
                    xSum += x[i];
                    ySum += y[i];
                    x2Sum += Math.Pow(x[i], 2);
                    xySum += x[i] * y[i];
                }
                double[,] equalSys = { { x2Sum, xSum }, { xSum, count } };
                double[] solArr = { xySum, ySum };
                double[] a = MatrixOperations.cramersRule(equalSys, solArr);
                return a;
            }
        }
        static void Main(string[] args)
        {
            //Second Task
            Second s = new Second();
            String coef1str = s.coef[1] >= 0 ? " + " + s.coef[1] : " - " + (-s.coef[1]);
            Console.WriteLine("(" + s.coef[0] + coef1str + "x)/(1 + " + s.coef[2] + "x)");
            //Third task
            Third t = new Third();
            Console.WriteLine(t.quadCoef[0] + " + " + t.quadCoef[1] + "x + " + t.quadCoef[2] + "x^2");
            Console.WriteLine(t.linearCoef[0] + "x + " + t.linearCoef[1]);
            Console.ReadKey();
        }
    }
}