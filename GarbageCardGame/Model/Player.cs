using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Model
{
    class Player
    {
        public string Name { get; private set; }
        public Hand Hand { get; set; }

        private readonly List<int> _ValidAnswers = new List<int>
            {
                (int)Stats.degradability + 1,
                (int)Stats.toxicity + 1,
                (int)Stats.recyclability + 1,
                (int)Stats.energyRecovery + 1,
            };

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public int PickStat(int initialStat)
        {
            int stat = initialStat;
            while (!_ValidAnswers.Contains(stat))
            {
                stat = int.Parse(Console.ReadLine());
            }
            
            switch (stat)
            {
                case 1:
                    Hand.CardsInHand[0].CompareThisStat = Hand.CardsInHand[0].Degradability;
                    break;
                case 2:
                    Hand.CardsInHand[0].CompareThisStat = Hand.CardsInHand[0].Toxicity;
                    break;
                case 3:
                    Hand.CardsInHand[0].CompareThisStat = Hand.CardsInHand[0].Recyclability;
                    break;
                case 4:
                    Hand.CardsInHand[0].CompareThisStat = Hand.CardsInHand[0].EnergyRecovery;
                    break;
            }
            return stat;
        }
    }
}
