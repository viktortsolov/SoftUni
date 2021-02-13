using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];

            int rowOfSnake = -1;
            int colOfSnake = -1;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = currentRow[col];
                    if (territory[row, col] == 'S')
                    { 
                        rowOfSnake = row;
                        colOfSnake = col;
                    }
                }
            }

            string command = string.Empty;
            int foodQuantity = 0;

            while (foodQuantity < 10)
            {
                command = Console.ReadLine();
                if (command == "up")
                {
                    territory[rowOfSnake, colOfSnake] = '.';
                    rowOfSnake -= 1;

                    if (rowOfSnake < 0)
                    {
                        GameOver(territory, foodQuantity);
                        return;
                    }

                    if (territory[rowOfSnake,colOfSnake] == '*')
                    {
                        territory[rowOfSnake, colOfSnake] = 'S';
                        foodQuantity++;
                    }

                    if (territory[rowOfSnake, colOfSnake] == 'B')
                    {
                        territory[rowOfSnake, colOfSnake] = '.';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (territory[row, col] == 'B')
                                {
                                    territory[row, col] = 'S';

                                    rowOfSnake = row;
                                    colOfSnake = col;
                                }
                            }
                        }
                    }
                }
                else if (command == "down")
                {
                    territory[rowOfSnake, colOfSnake] = '.';
                    rowOfSnake += 1;

                    if (rowOfSnake == n)
                    {
                        GameOver(territory, foodQuantity);
                        return;
                    }

                    if (territory[rowOfSnake, colOfSnake] == '*')
                    {
                        territory[rowOfSnake, colOfSnake] = 'S';
                        foodQuantity++;
                    }

                    if (territory[rowOfSnake, colOfSnake] == 'B')
                    {
                        territory[rowOfSnake, colOfSnake] = '.';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (territory[row, col] == 'B')
                                {
                                    territory[row, col] = 'S';

                                    rowOfSnake = row;
                                    colOfSnake = col;
                                }
                            }
                        }
                    }
                }
                else if (command == "left")
                {
                    territory[rowOfSnake, colOfSnake] = '.';
                    colOfSnake -= 1;

                    if (rowOfSnake < 0)
                    {
                        GameOver(territory, foodQuantity);
                        return;
                    }

                    if (territory[rowOfSnake, colOfSnake] == '*')
                    {
                        territory[rowOfSnake, colOfSnake] = 'S';
                        foodQuantity++;
                    }

                    if (territory[rowOfSnake, colOfSnake] == 'B')
                    {
                        territory[rowOfSnake, colOfSnake] = '.';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (territory[row, col] == 'B')
                                {
                                    territory[row, col] = 'S';

                                    rowOfSnake = row;
                                    colOfSnake = col;
                                }
                            }
                        }
                    }
                }
                else if (command == "right")
                {
                    territory[rowOfSnake, colOfSnake] = '.';
                    colOfSnake += 1;

                    if (rowOfSnake == n)
                    {
                        GameOver(territory, foodQuantity);
                        return;
                    }

                    if (territory[rowOfSnake, colOfSnake] == '*')
                    {
                        territory[rowOfSnake, colOfSnake] = 'S';
                        foodQuantity++;
                    }

                    if (territory[rowOfSnake, colOfSnake] == 'B')
                    {
                        territory[rowOfSnake, colOfSnake] = '.';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (territory[row, col] == 'B')
                                {
                                    territory[row, col] = 'S';

                                    rowOfSnake = row;
                                    colOfSnake = col;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            Print(territory);
        }

        private static void GameOver(char[,] territory, int foodQuantity)
        {
            Console.WriteLine("Game over!");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            Print(territory);
        }

        private static void Print(char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
