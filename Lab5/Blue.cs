using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = new double[matrix.GetLength(0)];

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int s = 0;
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        count++;
                    }
                }
                if (count == 0)
                {
                    answer[i] = 0;
                } else
                {
                    answer[i] = ((double)s) / count; ;
                }
            }
            Console.WriteLine(String.Join(", ", answer));
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0)-1, matrix.GetLength(1) - 1];

            // code here
            int max = matrix[0, 0];
            int index_i = 0;
            int index_j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        index_i = i;
                        index_j = j;
                    }
                }
            }
            int index_moment_i = 0;
            int index_moment_j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == index_i)
                {
                    continue;
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == index_j)
                    {
                        continue;
                    }

                    answer[index_moment_i, index_moment_j] = matrix[i, j];
                    index_moment_j++;
                }
                index_moment_i++;
                index_moment_j = 0;
            }
            Console.WriteLine($"Максимум: {max} на позиции [{index_i}, {index_j}]");
            Console.WriteLine("Результат:");
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    Console.Write(answer[i, j] + "\t");
                }
                Console.WriteLine();
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //поиск индекса максимального
                int max = -100000000;
                int index_max = 0;
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if (matrix[i, p] > max)
                    {
                        index_max = p;
                        max = matrix[i, p];
                    }
                }

                Console.WriteLine(index_max);

                int index_current = 0;
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if (p != index_max)
                    {
                        matrix[i, index_current] = matrix[i, p];
                        index_current++;
                    }
                }

                //Console.WriteLine(matrix.GetLength(0) - 1);
                matrix[i, matrix.GetLength(1) - 1] = max;

                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    Console.Write(matrix[i, p] + ", ");
                }

                Console.WriteLine();

            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            // code here
            int[] list_max = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //поиск индекса максимального
                int max = -100000000;
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if (matrix[i, p] > max)
                    {
                        max = matrix[i, p];
                    }
                }

                list_max[i] = max;

            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int index = 0;
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if (p == matrix.GetLength(1) - 1)
                    {
                        answer[i, index] = list_max[i];
                        index++;
                    }

                    answer[i, index] = matrix[i, p];
                    index++;
                }

            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {

            // code here
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if ((i+p) % 2 == 1)
                    {
                        count++;
                    }
                }

            }

            int[] answer = new int[count];

            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    if ((i + p) % 2 == 1)
                    {
                        answer[index] = matrix[i, p];
                        index++;
                    }
                }

            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // защита от некорректных входных данных
            if (rows == 0 || cols == 0) return;
            if (k < 0 || k >= cols) return; // либо throw new ArgumentOutOfRangeException(nameof(k));

            // ищем индекс строки с максимальным элементом на главной диагонали
            int diagLimit = Math.Min(rows, cols);
            int line_max = 0;
            int max = int.MinValue;
            for (int i = 0; i < diagLimit; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    line_max = i;
                }
            }

            // ищем первую строку в k-ом столбце с отрицательным элементом
            int line_minus = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, k] < 0)
                {
                    line_minus = i;
                    break;
                }
            }

            // если не найден отрицательный или индексы совпадают — не делать обмен
            if (line_minus == -1 || line_minus == line_max)
                return;

            // меняем строки местами поэлементно (надёжный in-place обмен)
            for (int j = 0; j < cols; j++)
            {
                int tmp = matrix[line_max, j];
                matrix[line_max, j] = matrix[line_minus, j];
                matrix[line_minus, j] = tmp;
            }
        }

        public void Task7(int[,] matrix, int[] array)
        {

            // code here

            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
    }
}