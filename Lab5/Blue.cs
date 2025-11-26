using System;
using System.Linq;
using System.Reflection;
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

            // code here
            int line_max = 0;
            int max = matrix[0, 0];
            int line_minus = -1;

            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return;

            for (int i = 0; i < Math.Min(matrix.GetLength(0), matrix.GetLength(1)); i++)
            {
                if (matrix[i, i] > max)
                    {
                        max = matrix[i, i];
                        line_max = i;
                    }
                if (line_minus == -1 && matrix[i, k] < 0)
                    line_minus = i;

            }

            if (line_minus == -1)
                return;

            int[] first_stroka = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                first_stroka[i] = matrix[line_max, i];

            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (k>=0 && k < matrix.GetLength(1) && matrix[i, k] < 0)
                {
                    line_minus = i;
                    break;
                }

            }
            if (line_minus != -1 && line_max != line_minus)
            {
                int[] second_stroka = new int[matrix.GetLength(1)];
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    second_stroka[i] = matrix[line_minus, i];

                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if ( i == line_minus)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] = first_stroka[j];
                        }
                    }

                    if (i == line_max)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] = second_stroka[j];
                        }
                    }

                }

            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    Console.Write(matrix[i, p] + " ");
                }

                Console.WriteLine();

            }
            Console.WriteLine();

            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int stroka = 0;
            int max = matrix[0, 0];

            if (matrix.GetLength(1) < 3)
            {
                return;
            }

            if (matrix.GetLength(1) != array.Length)
                return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1)-2] > max) {
                    max = matrix[i, matrix.GetLength(1) - 2];
                    stroka = i;
                }

            }

            for (int j = 0; j < Math.Min(array.Length, matrix.GetLength(1)); j++)
            {
                matrix[stroka, j] = array[j];
            }
            
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int max_index = 0;
                int max = matrix[0, i];
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        max_index = j;
                    }
                }

                if (max_index < matrix.GetLength(0)/2)
                {
                    int sum = 0;
                    for (int j = max_index+1; j < matrix.GetLength(0); j++)
                    {
                        sum += matrix[j, i];
                    }
                    matrix[0, i] = sum;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    Console.Write(matrix[i, p] + " ");
                }

                Console.WriteLine();

            }
            Console.WriteLine();
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i+=2)
            {
                int max_index_1 = 0;
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_index_1 = j;
                    }
                }

                if (i+1 <= matrix.GetLength(0)-1)
                {
                    int max_index_2 = 0;
                    max = matrix[i + 1, 0];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i + 1, j] > max)
                        {
                            max = matrix[i + 1, j];
                            max_index_2 = j;
                        }
                    }

                    (matrix[i, max_index_1], matrix[i + 1, max_index_2]) = (matrix[i + 1, max_index_2], matrix[i, max_index_1]);
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int index_i = 0;
            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
               
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    index_i = i;
                }
            }

            for (int i = 0; i < index_i; i++)
            {
                for (int j = i+1; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
                // end
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    Console.Write(matrix[i, p] + " ");
                }

                Console.WriteLine();

            }
            Console.WriteLine();
        }
        public void Task11(int[,] matrix)
        {

            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                        count++;

                array[i] = count;
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < matrix.GetLength(0); j++)
                    if (array[j] > array[maxIndex])
                        maxIndex = j;

                if (maxIndex == i)
                    continue;

                for (int j = 0; j < matrix.GetLength(1); j++)
                    (matrix[i, j], matrix[maxIndex, j]) = (matrix[maxIndex, j], matrix[i, j]);

                (array[i], array[maxIndex]) = (array[maxIndex], array[i]);
            }
        }


        public int[][] Task12(int[][] array)
        {
            int totalSum = 0;
            int totalCount = 0;

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalSum += array[i][j];
                    totalCount++;
                }

            double globalAvg = (double)totalSum / totalCount;

            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];

                double avg = (double)sum / array[i].Length;

                if (avg >= globalAvg)
                    k++;
            }

            int[][] answer = new int[k][];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];

                double avg = (double)sum / array[i].Length;

                if (avg >= globalAvg)
                {
                    answer[index] = array[i];
                    index++;
                }
            }

            return answer;
        }

    }
}