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
            CardsInHand = new List<Card>();
        }

        public void GetHand(Deck deck)
        {
            for (int i = 0; i < 5; i++)
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
    }
}
