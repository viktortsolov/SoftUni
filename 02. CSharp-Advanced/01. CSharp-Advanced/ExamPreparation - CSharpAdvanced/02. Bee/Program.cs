using System;
using System.Linq;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int rowOfBee = -1;
            int colOfBee = -1;

            //enter the field
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'B')
                    {
                        rowOfBee = row;
                        colOfBee = col;
                    }
                }
            }

            string input = string.Empty;
            int pollinatedFlowers = 0;

            //commands
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "up")
                {
                    matrix[rowOfBee, colOfBee] = '.';
                    rowOfBee--;

                    if (IsInField(matrix, rowOfBee, colOfBee) == false)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[rowOfBee, colOfBee] == 'O')
                    {
                        matrix[rowOfBee, colOfBee] = '.';
                        rowOfBee--;

                        if (IsInField(matrix, rowOfBee, colOfBee) == false)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                    }

                    if (matrix[rowOfBee, colOfBee] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }
                else if (input == "down")
                {
                    matrix[rowOfBee, colOfBee] = '.';
                    rowOfBee++;

                    if (IsInField(matrix, rowOfBee, colOfBee) == false)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[rowOfBee, colOfBee] == 'O')
                    {
                        matrix[rowOfBee, colOfBee] = '.';
                        rowOfBee++;

                        if (IsInField(matrix, rowOfBee, colOfBee) == false)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                    }

                    if (matrix[rowOfBee, colOfBee] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }
                else if (input == "right")
                {
                    matrix[rowOfBee, colOfBee] = '.';
                    colOfBee++;

                    if (IsInField(matrix, rowOfBee, colOfBee) == false)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[rowOfBee, colOfBee] == 'O')
                    {
                        matrix[rowOfBee, colOfBee] = '.';
                        colOfBee++;

                        if (IsInField(matrix, rowOfBee, colOfBee) == false)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                    }

                    if (matrix[rowOfBee, colOfBee] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }
                else if (input == "left")
                {
                    matrix[rowOfBee, colOfBee] = '.';
                    colOfBee--;

                    if (IsInField(matrix, rowOfBee, colOfBee) == false)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[rowOfBee, colOfBee] == 'O')
                    {
                        matrix[rowOfBee, colOfBee] = '.';
                        colOfBee--;

                        if (IsInField(matrix, rowOfBee, colOfBee) == false)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                    }

                    if (matrix[rowOfBee, colOfBee] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }

                matrix[rowOfBee, colOfBee] = 'B';
            }
            //check if the pollinated flowers are enough
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            //print matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsInField(char[,] matrix, int rowOfBee, int colOfBee)
        {
            if ((rowOfBee >= 0 && rowOfBee < matrix.GetLength(0)) &&
                (colOfBee >= 0 && colOfBee < matrix.GetLength(1)))
            {
                return true;
            }
            else
            {
                return false;
            }    
        }
    }
}
