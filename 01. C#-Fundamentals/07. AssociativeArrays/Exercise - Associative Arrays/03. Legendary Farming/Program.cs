﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyMaterials = new Dictionary<string, int>();
            var junkMaterials = new Dictionary<string, int>();

            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["shards"] = 0;

            bool hasToBreak = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards" || material == "motes" || material == "fragments")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;
                            switch (material)
                            {
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;

                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;

                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                            }
                            hasToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials.Add(material, 0);
                        }
                        junkMaterials[material] += quantity;
                    
                    }
                }
                if (hasToBreak)
                {
                    break;
                }
            }

            keyMaterials = keyMaterials.OrderByDescending(v => v.Value)
                                        .ThenBy(k => k.Key)
                                        .ToDictionary(a => a.Key, a => a.Value);

            foreach (var pair in keyMaterials)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (var pair in junkMaterials.OrderBy(k=>k.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}