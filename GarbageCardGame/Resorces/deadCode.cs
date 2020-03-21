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

            Deck allCadrds = new Deck(new CardDAO(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv"));
            SerializeToXml(allCadrds.CardDeck, Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.xml");

            List<Card> deserializedCards = DeserializeFromXml(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.xml");
            Console.WriteLine(deserializedCards[0]);
            //TESTING ZONE END
        }

        private static List<Card> DeserializeFromXml(string v)
        {
            throw new NotImplementedException();
        }

        private static void SerializeToXml(List<Card> cardDeck, string v)
        {
            throw new NotImplementedException();
        }
    }
}
