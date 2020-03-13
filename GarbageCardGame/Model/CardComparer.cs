using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Model
{
    class CardComparer : IComparer<Card>
    {
        /// <summary>
        /// This method compares 2 cards by 1 stat.
        /// Use it to determine the winning card.
        /// Stat will be chosen by the player (in GameController when we ask the player to chose the stat we will have to include the line:
        /// Card.CompareThisStat = Card.Toxicity (or other stat) 
        /// </summary>
        public int Compare(Card card1, Card card2)
        {
            if (card1.CompareThisStat > card2.CompareThisStat)
                return 1;
            if (card1.CompareThisStat < card2.CompareThisStat)
                return -1;
            else
                return 0;
        }
    }
}
