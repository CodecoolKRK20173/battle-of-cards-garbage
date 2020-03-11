using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame
{
    class Card
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
    }
}
