using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SavingGrej
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Boulder> boulderList = new List<Boulder>();

            while (true)
            {
                int boulderAmount = boulderList.Count;
                string option = "";
                while (option != "new" && option != "load")
                {
                    Console.WriteLine("Would you like to create a new Boulder or load a Boulder? (Write 'new' or 'load'");
                    option = Console.ReadLine();
                }

                if (option == "new")
                {
                    boulderList.Add(new Boulder());
                    CreateJson(boulderList[boulderList.Count - 1], boulderAmount - 1);
                }
                else
                {
                    Console.WriteLine("Which boulder would you like to load (write the list numbers. 0, 1, 2 etc. PLEASE WRITE AN ACTUAL NUMBER");
                    string userBoulder = Console.ReadLine();
                    if (File.Exists($"json{userBoulder}.json"))
                    {
                        LoadJson(userBoulder);
                    }
                    else
                    {
                        Console.WriteLine("This file does not exist.");
                    }
                }

                Console.ReadLine();
            }
        }

        static void CreateJson(Boulder b, int i)
        {
            GetValues(b);
            string json = JsonSerializer.Serialize<Boulder>(b);
            File.WriteAllText($"json{i + 1}.json", json);
            Console.WriteLine(json);
        }

        static void LoadJson(string i)
        {
            string json = File.ReadAllText($"json{i}.json");
            Console.WriteLine(json);
        }

        static void GetValues(Boulder b)
        {
            Console.WriteLine("What's your boulders name?");
            b.Name = Console.ReadLine();
            Console.WriteLine("How much does your boulder weigh?");
            b.Weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What's the density of your boulder?");
            b.Density = Convert.ToInt32(Console.ReadLine());
        }


    }
}
