using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GarbageCardGame.Model
{
    class Card : IComparable
    {
        public string CardName { get; private set; }
        public int Degradability { get; private set; }
        public int Toxicity { get; private set; }
        public int Recyclability { get; private set; }
        public int EnergyRecovery { get; private set; }

        private enum Stats
        {
            degradability,
            toxicity,
            recyclability,
            energyRecovery,
        }

        public Card(string cardName, int[] numericalStats)
        {
            CardName = cardName;
            Degradability = numericalStats[(int)Stats.degradability];
            Toxicity = numericalStats[(int)Stats.toxicity];
            Recyclability = numericalStats[(int)Stats.recyclability];
            EnergyRecovery = numericalStats[(int)Stats.energyRecovery];
        }

        //TODO Implement IComparable
        //TODO override hashCode() method and equals() method
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        private class sortCardsByDegradability : IComparer<Card>
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
}
