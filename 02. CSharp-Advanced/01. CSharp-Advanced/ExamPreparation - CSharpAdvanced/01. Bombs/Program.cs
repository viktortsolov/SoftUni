using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombsEffect = new Queue<int>(Console.ReadLine()
                                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse));

            Stack<int> bombsCasing = new Stack<int>(Console.ReadLine()
                                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse));

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;

            bool areMoreThanThreeBombsEach = false;

            while (bombsEffect.Count > 0 && bombsCasing.Count > 0)
            {
                areMoreThanThreeBombsEach = daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3;
                if (areMoreThanThreeBombsEach)
                {
                    break; 
                }

                int bombEffect = bombsEffect.Peek();
                int bombCasing = bombsCasing.Peek();

                int sum = bombEffect + bombCasing;

                switch (sum)
                {
                    case 40:
                        daturaBombs++;

                        bombsCasing.Pop();
                        bombsEffect.Dequeue();
                        break;

                    case 60:
                        cherryBombs++;

                        bombsCasing.Pop();
                        bombsEffect.Dequeue();
                        break;

                    case 120:
                        smokeDecoyBombs++;

                        bombsCasing.Pop();
                        bombsEffect.Dequeue();
                        break;

                    default:
                        bombCasing -= 5;

                        int[] array = new int[bombsCasing.Count()];
                        array[0] = bombCasing;
                        bombsCasing.Pop();
                        for (int i = 1; i < array.Length; i++)
                        {
                            array[i] = bombsCasing.Pop();
                        }
                        array = array.Reverse().ToArray();
                        foreach (var item in array)
                        {
                            bombsCasing.Push(item);
                        }        
                        break;
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            if (areMoreThanThreeBombsEach)
            {
               stringBuilder.AppendLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                stringBuilder.AppendLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombsEffect.Count() == 0)
            {
                stringBuilder.AppendLine("Bomb Effects: empty");
            }
            else
            {
                stringBuilder.AppendLine($"Bomb Effects: {string.Join(", ", bombsEffect)}");
            }
            if (bombsCasing.Count() == 0)
            {
                stringBuilder.AppendLine("Bomb Casings: empty");
            }
            else
            {
                stringBuilder.AppendLine($"Bomb Casings: {string.Join(", ", bombsCasing)}");
            }

            stringBuilder.AppendLine($"Cherry Bombs: {cherryBombs}");
            stringBuilder.AppendLine($"Datura Bombs: {daturaBombs}");
            stringBuilder.AppendLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");

            Console.WriteLine(stringBuilder.ToString().Trim());
        }
    }
}
