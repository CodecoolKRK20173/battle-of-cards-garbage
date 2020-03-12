using System;
using System.IO;
using GarbageCardGame.DAO;
using GarbageCardGame.Model;

namespace GarbageCardGame
{
    class MainApp
    {
        static void Main(string[] args)
        {

            //TESTING ZONE
            Console.WriteLine("Hello World!");
            string path = Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv";
            Console.WriteLine(path);
            
            Deck Talia = new Deck(new CardDAO(path));
            Talia.Shuffle();
            foreach (var card in Talia.CardDeck)
            {
                Console.WriteLine($"{card.CardName}, {card.EnergyRecovery}");
            }
            //TESTING ZONE END
            
        }
    }
}
