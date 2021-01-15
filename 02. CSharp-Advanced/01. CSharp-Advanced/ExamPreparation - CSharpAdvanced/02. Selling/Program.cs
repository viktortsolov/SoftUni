﻿using System;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int dollars = 0;
            while (dollars < 50)
            {
                string input = Console.ReadLine();

                if (input == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow -= 1;
                    if (playerRow < 0) 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[playerRow,playerCol]))
                    {
                        dollars += int.Parse(matrix[playerRow, playerCol].ToString());
                        matrix[playerRow, playerCol] = 'S';
                    }
                    else if (matrix[playerRow, playerCol] == 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }

                        playerRow = rowO;
                        playerCol = colO;
                        matrix[playerRow, playerCol] = 'S';
                    }
                }

                else if (input == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow += 1;
                    if (playerRow >= n)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[playerRow, playerCol]))
                    {
                        dollars += int.Parse(matrix[playerRow, playerCol].ToString());
                        matrix[playerRow, playerCol] = 'S';
                    }
                    else if (matrix[playerRow, playerCol] == 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }

                        playerRow = rowO;
                        playerCol = colO;
                        matrix[playerRow, playerCol] = 'S';
                        
                    }
                }

                else if (input == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol += 1;
                    if (playerCol >= n)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[playerRow, playerCol]))
                    {
                        dollars += int.Parse(matrix[playerRow, playerCol].ToString());
                        matrix[playerRow, playerCol] = 'S';
                    }
                    else if (matrix[playerRow, playerCol] == 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }

                        playerRow = rowO;
                        playerCol = colO;
                        matrix[playerRow, playerCol] = 'S';
                    }
                }

                else if (input == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol -= 1;
                    if (playerCol < 0)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[playerRow, playerCol]))
                    {
                        dollars += int.Parse(matrix[playerRow, playerCol].ToString());
                        matrix[playerRow, playerCol] = 'S';
                    }
                    else if (matrix[playerRow, playerCol] == 'O')
                    {
                        matrix[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }

                        playerRow = rowO;
                        playerCol = colO;
                        matrix[playerRow, playerCol] = 'S';
                    }
                }
            }

            if (dollars >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {dollars}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
