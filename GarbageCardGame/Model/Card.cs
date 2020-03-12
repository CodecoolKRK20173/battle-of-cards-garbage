using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GarbageCardGame.Model
{
    class Card : IComparable<Card>
    {
        public string CardName { get; private set; }
        public int Degradability { get; private set; }
        public int Toxicity { get; private set; }
        public int Recyclability { get; private set; }
        public int EnergyRecovery { get; private set; }
        public int CompareThisStat { get; set; }

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
        public int CompareTo(Card obj)
        {
            throw new NotImplementedException();
        }
    }
}
