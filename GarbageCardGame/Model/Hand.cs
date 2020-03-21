using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Model
{
    class Hand
    {
        public List<Card> CardsInHand { get; private set; } 
        private readonly int _NumberOfStartingCards = 5;

        public Hand()
        {
            CardsInHand = new List<Card>();
        }

        public void GetHand(Deck deck)
        {
            for (int i = 0; i < _NumberOfStartingCards; i++)
            {
                CardsInHand.Add(deck.CardDeck[0]);
                deck.CardDeck.Remove(deck.CardDeck[0]);
            }
        }

        public void AddCard(Card card)
        {
            CardsInHand.Add(card);
        }

        public void RemoveCard(Card card)
        {
            CardsInHand.Remove(card);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (!(obj is Hand))
            {
                return false;
            }
            return this.CalculateTotalHandValue().Equals(((Hand)obj).CalculateTotalHandValue());
        }

        private int CalculateTotalHandValue()
        {
            int totalHandValue = 0;
            foreach (var card in CardsInHand)
            {
                totalHandValue += card.TotalStatSum;
            }
            return totalHandValue;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = 10711;
                const int HashingMultiplier = 10739;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ CalculateTotalHandValue();
                return hash;
            }
        }
    }
}
