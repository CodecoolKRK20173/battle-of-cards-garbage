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

        public int PickStat()
        {
            int answer = -1;
            while (!_ValidAnswers.Contains(answer))
            {
                Console.WriteLine("What stat do you chose?");
                answer = int.Parse(Console.ReadLine());
            }
            return answer;
        }
    }
}
