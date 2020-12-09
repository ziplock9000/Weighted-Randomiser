using System;

namespace Weighted_Randomiser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Create a list of items that can be randomly selected with weights
            WeightedRandomiser<string> itemDrops = new WeightedRandomiser<string>();

            itemDrops.AddEntry("10 Gold", 1.0);
            itemDrops.AddEntry("Sword", 20.0);
            itemDrops.AddEntry("Shield", 50.0);
            itemDrops.AddEntry("Armor", 20.0);
            itemDrops.AddEntry("Potion", 10.0);

            //Pick some random items
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Item {i} = {itemDrops.GetRandom()}");
            }

            Console.WriteLine("Hit Enter to exit");
            Console.ReadLine();
        }
    }
}
