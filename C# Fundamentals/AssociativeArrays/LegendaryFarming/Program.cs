using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
                {
                { "fragments",0 },
                {"shards",0},
                {"motes",0}
                };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            bool isLegendaryFound = false;
            while (!isLegendaryFound)
            {
                //3 Motes 5 stones 5 Shards
                //6 leathers 255 fragments 7 Shards

                string[] input = Console.ReadLine().Split();
                for (int i = 1; i <= input.Length; i += 2)
                {
                    string material = input[i].ToLower();
                    int materialCount = int.Parse(input[i - 1]);
                    if (material == "shards" || material == "fragments" || material == "motes")
                    {



                        keyMaterials[material] += materialCount;

                        if (keyMaterials[material] >= 250)
                        {
                            isLegendaryFound = true;
                            keyMaterials[material] -= 250;
                            switch (material)
                            {
                                case "shards":

                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                                default:
                                    break;

                            }

                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk[material] = materialCount;
                        }
                        else
                        {
                            junk[material] += materialCount;
                        }
                    }


                }

            }
            foreach (var material in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key.ToLower()}: {material.Value}");
            }

            foreach (var item in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key.ToLower()}: {item.Value}");
            }

        }
    }
}
