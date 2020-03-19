using System.Collections.Generic;

namespace GarbageCardGame.Model
{
    class CardComparer : IComparer<Card>
    {
        /// <summary>
        /// This method compares 2 cards by 1 stat.
        /// Use it to determine the winning card.
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
