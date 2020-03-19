using System;
using System.Collections.Generic;
using System.Text;
using GarbageCardGame.View;

namespace GarbageCardGame.Model
{
    class Player
    {
        public string Name { get; private set; }
        public Hand Hand { get; private set; }
        public bool IsActive { get; set; }

        private readonly List<int> _ValidAnswers = new List<int>
            {
                (int)Stats.degradability + 1,
                (int)Stats.toxicity + 1,
                (int)Stats.recyclability + 1,
                (int)Stats.energyRecovery + 1,
            };

        public Player(string name, bool isActive = false)
        {
            Name = name;
            Hand = new Hand();
            IsActive = isActive;
        }

        public int PickStat(int initialStat)
        {
            int stat = initialStat;
            while (!_ValidAnswers.Contains(stat))
            {
                ViewGarbage error = new ViewGarbage();
                try
                {
                    stat = int.Parse(Console.ReadLine());
                    if (!_ValidAnswers.Contains(stat)) throw new ArgumentException();
                }
                catch (FormatException)
                {
                    error.Print("Please enter a value '1', '2', '3', or '4'.");
                }
                catch (ArgumentException)
                {
                    error.Print("Please enter a value in range 1-4.");
                }
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
