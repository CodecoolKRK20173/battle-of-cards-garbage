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

        public Card(string cardName, int degradability, int recyclability, int toxicity, int energyRecovery)
        {
            CardName = cardName;
            Degradability = degradability;
            Toxicity = toxicity;
            Recyclability = recyclability;
            EnergyRecovery = energyRecovery;
        }
    }
}
