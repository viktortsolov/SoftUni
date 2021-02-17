using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cmdCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < cmdCount; i++)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow -= 1;
                    if (playerRow < 0)
                    {
                        playerRow = n - 1;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow -= 1; 
                        if (playerRow < 0)
                        {
                            playerRow = n - 1;
                        }

                        matrix[playerRow, playerCol] = 'f';
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow += 1;
                        matrix[playerRow, playerCol] = 'f';
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        matrix[playerRow, playerCol] = 'f';
                        Print(matrix);
                        return;
                    }
                }
                else if (command == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow += 1;
                    if (playerRow == n)
                    {
                        playerRow = 0;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow += 1; 
                        if (playerRow == n)
                        {
                            playerRow = 0;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow -= 1;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        Print(matrix);
                        return;
                    }
                }
                else if (command == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol -= 1;
                    if (playerCol < 0)
                    {
                        playerCol = n - 1;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol -= 1;
                        if (playerCol < 0)
                        {
                            playerCol = n - 1;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol += 1;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        Print(matrix);
                        return;
                    }
                }
                else if (command == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol += 1;
                    if (playerCol == n)
                    {
                        playerCol = 0;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol += 1;
                        if (playerCol == n)
                        {
                            playerCol = 0;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol -= 1;
                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        Print(matrix);
                        return;
                    }
                }
            }
            Console.WriteLine("Player lost!");
            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
