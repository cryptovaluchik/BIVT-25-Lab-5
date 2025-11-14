using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here

            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for (int i = 0;  i < matrix.GetLength(0); i++)
            {
                //поиск индекса максимального
                int max = -100000000;
                int index_max = 0;
                for (int p = 0;  p < matrix.GetLength(1); p++)
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
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];

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
                    if (p != matrix.GetLength(1)-1)
                    {
                        answer[i, index] = matrix[i, p];
                        index++;
                    } else
                    {
                        answer[i, index] = list_max[i];
                        index++;
                    }
                }

            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here

            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here

            // end

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