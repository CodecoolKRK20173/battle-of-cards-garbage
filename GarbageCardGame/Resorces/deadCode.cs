using GarbageCardGame.DAO;
using GarbageCardGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Resorces
{
    class deadCode
    {
        static void MainXXX()
        {
            //TESTING ZONE
            Console.WriteLine("=== TEST ZONE ===");
            string path = Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv";
            Console.WriteLine(path);

            Deck Talia = new Deck(new CardDAO(path));
            Talia.Shuffle();
            IComparer<Card> comparer = new CardComparer();
            int result = comparer.Compare(Talia.CardDeck[0], Talia.CardDeck[1]);
            Console.WriteLine($"{Talia.CardDeck[0].Degradability} : {Talia.CardDeck[1].Degradability} --> {result}");
            Talia.CardDeck.Sort(comparer);
            foreach (var card in Talia.CardDeck)
            {
                Console.WriteLine($"{card.CardName}, {card.Degradability}");
            }
            Talia.CardDeck.Sort();
            foreach (var card in Talia.CardDeck)
            {
                Console.WriteLine($"{card.CardName}, {card.TotalStatSum}");
            }
            //TESTING ZONE END
        }
    }
}
