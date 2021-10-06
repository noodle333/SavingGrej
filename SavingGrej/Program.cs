using System;
using System.IO;
using System.Text.Json;

namespace SavingGrej
{
    class Program
    {
        static void Main(string[] args)
        {
            Boulder stone = new Boulder();
            GetValues(stone);
            string json = JsonSerializer.Serialize<Boulder>(stone);
            File.WriteAllText("json.json", json);
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
