using System;
namespace ThirdLabMathMethods
{
    class Matrix
    {
        private int row_matrix;
        private int column_matrix;
        double[,] matrix = new double[5, 5];
        double[,] matrixForKramer = new double[5, 6];

        public void Init()
        {
            row_matrix = matrix.GetLength(0);
            column_matrix = matrix.GetLength(1);
        }

        public double[,] GetMatrix()
        {
            return matrix;
        }

        public void SetMatrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public void GenereteWithRandomNumbersMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }
            for (int i = 0; i < matrixForKramer.GetLength(0); i++)
            {
                for (int j = 0; j < matrixForKramer.GetLength(1); j++)
                {
                    matrixForKramer[i, j] = random.Next(1, 10);
                }
            }
        }
        
        public double[,] FindTransposedMatrix(double[,] matrixBeforeTranspose)
        {
            double[,] matrixAfterTranspose = new double[matrixBeforeTranspose.GetLength(0), matrixBeforeTranspose.GetLength(1)];
            for (int i = 0; i < matrixBeforeTranspose.GetLength(0); i++)
            {
                for (int j = 0; j < matrixBeforeTranspose.GetLength(1); j++)
                {
                    matrixAfterTranspose[j, i] = matrixBeforeTranspose[i, j];
                }
            }
            for (int i = 0; i < matrixBeforeTranspose.GetLength(0); i++)
            {
                for (int j = 0; j < matrixBeforeTranspose.GetLength(1); j++)
                {
                    Console.Write($"{matrixAfterTranspose[i, j]} ");
                }
                Console.WriteLine();
            }
            return matrixAfterTranspose;
        }

        public void FindInvertedMatrix()
        {
            double[,] minorMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double[,] minor = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    minor = CreateSmallerMatrix(matrix, i, j);
                    minorMatrix[i, j] = Determinant(minor);
                }
            }
            minorMatrix = FindTransposedMatrix(minorMatrix);
            double determinant = Determinant(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    minorMatrix[i, j] /= determinant;
                }
            }
            for (int i = 0; i < minorMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < minorMatrix.GetLength(1); j++)
                {
                    Console.Write($"{minorMatrix[i, j]} ");
                }
                Console.WriteLine();
            }

        }

        static double[,] CreateSmallerMatrix(double[,] input, int i, int j)
        {
            int order = input.GetLength(0);
            double[,] output = new double[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }

        static int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public double Determinant(double[,] input)
        {
            int order = input.GetLength(0);
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    double[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * Determinant(Temp));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }
        }

        //Допиляти Крамера, ексепшин виб'є

        public void Kramera()
        {
            double determinant = 0;
            double[] vectorOfDeterminants = new double[matrix.GetLength(1)];
            double[,] minor = new double[matrix.GetLength(0), matrix.GetLength(1) + 1];
            double[,] minorDet = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double[] vectorOfValues = new double[] { 5, 3, 7, 1, 2 };

            for (int j = 0; j < minor.GetLength(0); j++)
            {
                for (int k = 0; k < minor.GetLength(0); k++)
                {
                    minor[j, k] = matrix[j, k];
                }
            }

            for (int i = 0; i < minor.GetLength(0); i++)
            {
                minor[i, minor.GetLength(1) - 1] = vectorOfValues[i];
            }

            for (int j = 0; j < minor.GetLength(0); j++)
            {
                for (int k = 0; k < minor.GetLength(1); k++)
                {
                    Console.Write(minor[j, k] + " ");
                }
                Console.WriteLine();
            }

            determinant = Determinant(matrix);
            for (int i = 0; i < minor.GetLength(1) - 1; i++)
            {
                minorDet = CreateSmallerMatrix(minor, 0, i);
                vectorOfDeterminants[i] = Determinant(minorDet);
            }

            for (int i = 0; i < vectorOfDeterminants.Length; i++)
            {
                vectorOfDeterminants[i] /= determinant;
                Console.Write($"values: {vectorOfDeterminants[i]} ");
            }
        }

        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix();
            double[,] firstArray = firstMatrix.GetMatrix();
            double[,] secondArray = secondMatrix.GetMatrix();
            if (firstArray.GetLength(0) == secondArray.GetLength(0) && firstArray.GetLength(1) == firstArray.GetLength(1))
            {
                for (int i = 0; i < firstArray.GetLength(0); i++)
                {
                    for (int j = 0; j < firstArray.GetLength(1); j++)
                    {
                        firstArray[i, j] += secondArray[i, j];
                    }
                }
                matrix.SetMatrix(firstArray);
            }
            else
            {
                matrix.SetMatrix(null);
                Console.WriteLine("n != m dimension");
            }
            return matrix;
        }

        public static Matrix operator *(Matrix firstMatrix, int numeric)
        {
            Matrix matrix = new Matrix();
            double[,] firstArray = firstMatrix.GetMatrix();
            if (firstArray != null)
            {
                for (int i = 0; i < firstArray.GetLength(0); i++)
                {
                    for (int j = 0; j < firstArray.GetLength(1); j++)
                    {
                        firstArray[i, j] *= numeric;
                    }
                }
                matrix.SetMatrix(firstArray);
            }
            else
            {
                matrix.SetMatrix(null);
                Console.WriteLine("n != m dimension");
            }
            return matrix;
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix();
            double[,] firstArray = firstMatrix.GetMatrix();
            double[,] secondArray = secondMatrix.GetMatrix();
            if (firstArray.GetLength(0) == secondArray.GetLength(0) && firstArray.GetLength(1) == firstArray.GetLength(1))
            {
                for (int i = 0; i < firstArray.GetLength(0); i++)
                {
                    for (int j = 0; j < firstArray.GetLength(1); j++)
                    {
                        firstArray[i, j] -= secondArray[i, j];
                    }
                }
                matrix.SetMatrix(firstArray);
            }
            else
            {
                matrix.SetMatrix(null);
                Console.WriteLine("n != m dimension");
            }
            return matrix;
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix();
            double[,] firstArray = firstMatrix.GetMatrix();
            double[,] secondArray = secondMatrix.GetMatrix();
            if (firstArray.GetLength(0) == secondArray.GetLength(1) && firstArray.GetLength(1) == firstArray.GetLength(0))
            {
                for (int i = 0; i < firstArray.GetLength(0); i++)
                {
                    for (int j = 0; j < firstArray.GetLength(1); j++)
                    {
                        firstArray[i, j] *= secondArray[j, i];
                    }
                }
                matrix.SetMatrix(firstArray);
            }
            else
            {
                matrix.SetMatrix(null);
                Console.WriteLine("n != m dimension");
            }
            return firstMatrix;
        }
    }
}
