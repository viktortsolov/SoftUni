using System;
using System.Linq;

namespace _2._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            var coordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            for (int row = 0; row < n; row++)
            {
                var currentCol = Console.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = char.Parse(currentCol[col]);
                    if (field[row, col] == '<')
                    {
                        firstPlayerShips += 1;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlayerShips += 1;
                    }
                }
            }

            int sunkedShips = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] cords = coordinates[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int rowCord = cords[0];
                int colCord = cords[1];

                if ((rowCord < 0 || rowCord >= n) || (colCord < 0 || colCord >= n))
                {
                    continue;
                }

                if (field[rowCord, colCord] == '>')
                {
                    field[rowCord, colCord] = 'X';
                    secondPlayerShips -= 1;
                    sunkedShips += 1;
                }
                else if (field[rowCord, colCord] == '<')
                {
                    field[rowCord, colCord] = 'X';
                    firstPlayerShips -= 1;
                    sunkedShips += 1;
                }
                else if (field[rowCord, colCord] == '#')
                {
                    //First
                    if (rowCord - 1 >= 0 && colCord - 1 > 0)
                    {
                        if (field[rowCord - 1, colCord - 1] == '>')
                        {
                            field[rowCord - 1, colCord - 1] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord - 1, colCord - 1] == '<')
                        {
                            field[rowCord - 1, colCord - 1] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Second
                    if (rowCord - 1 >= 0)
                    {
                        if (field[rowCord - 1, colCord] == '>')
                        {
                            field[rowCord - 1, colCord] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord - 1, colCord] == '<')
                        {
                            field[rowCord - 1, colCord] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Third
                    if (rowCord - 1 >= 0 && colCord + 1 < n)
                    {
                        if (field[rowCord - 1, colCord + 1] == '>')
                        {
                            field[rowCord - 1, colCord + 1] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord - 1, colCord + 1] == '<')
                        {
                            field[rowCord - 1, colCord + 1] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Forth
                    if (colCord - 1 >= 0)
                    {
                        if (field[rowCord, colCord - 1] == '>')
                        {
                            field[rowCord, colCord - 1] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord, colCord - 1] == '<')
                        {
                            field[rowCord, colCord - 1] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Fifth
                    if (colCord + 1 < n)
                    {
                        if (field[rowCord, colCord + 1] == '>')
                        {
                            field[rowCord, colCord + 1] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord, colCord + 1] == '<')
                        {
                            field[rowCord, colCord + 1] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Sixth
                    if (rowCord + 1 < n && colCord - 1 >= 0)
                    {
                        if (field[rowCord + 1, colCord - 1] == '>')
                        {
                            field[rowCord + 1, colCord - 1] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord + 1, colCord - 1] == '<')
                        {
                            field[rowCord + 1, colCord - 1] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Seventh
                    if (rowCord + 1 < n)
                    {
                        if (field[rowCord + 1, colCord] == '>')
                        {
                            field[rowCord + 1, colCord] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord + 1, colCord] == '<')
                        {
                            field[rowCord + 1, colCord] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                    //Eight
                    if (rowCord + 1 < n && colCord + 1 < n)
                    {
                        if (field[rowCord + 1, colCord + 1] == '>')
                        {
                            field[rowCord + 1, colCord + 1] = 'X';
                            sunkedShips += 1;
                            secondPlayerShips -= 1;
                        }
                        else if (field[rowCord + 1, colCord + 1] == '<')
                        {
                            field[rowCord + 1, colCord + 1] = 'X';
                            sunkedShips += 1;
                            firstPlayerShips -= 1;
                        }
                    }
                }

                if (firstPlayerShips <= 0)
                {
                    firstPlayerShips = 0;
                    Console.WriteLine($"Player Two has won the game! {sunkedShips} ships have been sunk in the battle.");
                    return;
                }
                else if (secondPlayerShips <= 0)
                {
                    secondPlayerShips = 0;
                    Console.WriteLine($"Player One has won the game! {sunkedShips} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }
    }
}
