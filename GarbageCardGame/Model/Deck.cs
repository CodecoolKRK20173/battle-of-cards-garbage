using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
