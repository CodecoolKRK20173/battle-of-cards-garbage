using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Model
{
    class CardComparer : IComparer<Card>
    {
        public int Compare(Card card1, Card card2)
        {
            if (card1.Degradability > card2.Degradability)
                return 1;
            if (card1.Degradability < card2.Degradability)
                return -1;
            else
                return 0;
        }
    }
}
