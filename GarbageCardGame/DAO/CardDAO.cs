using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace GarbageCardGame.DAO
{
    class CardDAO : ICardDAO
    {
        public List<Card> AllCards { get; private set; }
        private string Path { get; set; }

        public CardDAO(string path)
        {
            Path = path;
        }

        public List<Card> GetDeck()
        {
            var allCards = new List<Card>();
            string[] cards = File.ReadAllLines(Path);

            foreach (var card in cards)
            {
                var singleCardStats = card.Split(",");
                var singleCard = ParseCardBaseOn(singleCardStats);
                allCards.Add(singleCard);
            }
            return allCards;
        }

        private Card ParseCardBaseOn(string[] singleCardStats)
        {
            string[] numericalStats = singleCardStats.Skip(1).ToArray();
            int[] numericalStatsAsInt = Array.ConvertAll(numericalStats, new Converter<string, int>(StringToInt));
            return new Card(singleCardStats[0], numericalStatsAsInt);
        }

        private int StringToInt(string input)
        {
            return int.Parse(input);
        }
    }
}
