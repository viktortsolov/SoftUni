using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int numberOfCommands = int.Parse(Console.ReadLine());

            int playerIndexRow = 0;
            int playerIndexCol = 0;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerIndexCol = col;
                        playerIndexRow = row;
                    }
                }
            }

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                matrix[playerIndexRow, playerIndexCol] = '-';
                switch (command)
                {
                    case "up":
                        playerIndexRow -= 1;
                        if (playerIndexRow == -1)
                        {
                            playerIndexRow = n - 1;
                        }

                        if (matrix[playerIndexRow, playerIndexCol] == 'T')
                        {
                            playerIndexRow += 1;
                        }
                        else if (matrix[playerIndexRow,playerIndexCol] == 'B')
                        {
                            playerIndexRow -= 1;
                        }
                        else if(matrix[playerIndexRow,playerIndexCol] == 'F')
                        {
                            matrix[playerIndexRow, playerIndexCol] = 'f';
                            Console.WriteLine("Player won!");
                            Print(matrix);
                            return;
                        }

                        if (playerIndexRow == -1)
                        {
                            playerIndexRow = n - 1;
                        }
                        matrix[playerIndexRow, playerIndexCol] = 'f';
                        break;

                    case "down":
                        playerIndexRow += 1;
                        if (playerIndexRow == n)
                        {
                            playerIndexRow = 0;
                        }

                        if (matrix[playerIndexRow, playerIndexCol] == 'T')
                        {
                            playerIndexRow -= 1;
                        }
                        else if (matrix[playerIndexRow, playerIndexCol] == 'B')
                        {
                            playerIndexRow += 1;
                        }
                        else if (matrix[playerIndexRow, playerIndexCol] == 'F')
                        {
                            matrix[playerIndexRow, playerIndexCol] = 'f';
                            Console.WriteLine("Player won!");
                            Print(matrix);
                            return;
                        }

                        if (playerIndexRow == n)
                        {
                            playerIndexRow = 0;
                        }
                        matrix[playerIndexRow, playerIndexCol] = 'f';
                        break;

                    case "left":
                        playerIndexCol -= 1;
                        if (playerIndexCol == -1)
                        {
                            playerIndexCol = n - 1;
                        }

                        if (matrix[playerIndexRow, playerIndexCol] == 'T')
                        {
                            playerIndexCol += 1;
                        }
                        else if (matrix[playerIndexRow, playerIndexCol] == 'B')
                        {
                            playerIndexCol -= 1;
                        }
                        else if (matrix[playerIndexRow, playerIndexCol] == 'F')
                        {
                            matrix[playerIndexCol, playerIndexCol] = 'f';
                            Console.WriteLine("Player won!");
                            Print(matrix);
                            return;
                        }

                        if (playerIndexCol == -1)
                        {
                            playerIndexCol = n - 1;
                        }
                        matrix[playerIndexRow, playerIndexCol] = 'f';
                        break;

                    case "right":
                        playerIndexCol += 1;
                        if (playerIndexCol == n)
                        {
                            playerIndexCol = 0;
                        }

                        if (matrix[playerIndexRow, playerIndexCol] == 'T')
                        {
                            playerIndexCol -= 1;
                        }
                        else if (matrix[playerIndexRow, playerIndexCol] == 'B')
                        {
                            playerIndexCol += 1;
                        }
                        else if (matrix[playerIndexRow, playerIndexCol] == 'F')
                        {
                            matrix[playerIndexCol, playerIndexCol] = 'f';
                            Console.WriteLine("Player won!");
                            Print(matrix);
                            return;
                        }

                        if (playerIndexCol == n)
                        {
                            playerIndexCol = 0;
                        }
                        matrix[playerIndexRow, playerIndexCol] = 'f';
                        break;
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
