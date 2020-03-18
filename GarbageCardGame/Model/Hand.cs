using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Model
{
    class Hand
    {
        public List<Card> CardsInHand { get; private set; }

        public Hand()
        {
            CardsInHand = GetHand();
        }

        private List<Card> GetHand()
        {
            throw new NotImplementedException();
        }

        public void AddCard(Card card)
        {
            CardsInHand.Add(card);
        }

        public void RemoveCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
