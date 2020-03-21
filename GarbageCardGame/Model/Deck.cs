using System;
using System.Collections.Generic;
using System.Linq;
using GarbageCardGame.DAO;

namespace GarbageCardGame.Model
{
    class Deck
    {
        private ICardDAO CardDAO { get; set; }
        public List<Card> CardDeck { get; private set; }

        public Deck(ICardDAO cardDAO)
        {
            CardDAO = cardDAO;
            CardDeck = CardDAO.GetDeck();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            CardDeck = CardDeck.OrderBy(x => rand.Next()).ToList();
        }
    }
}
