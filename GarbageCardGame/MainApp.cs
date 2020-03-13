using System;
using System.Collections;
using System.Collections.Generic;
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
