using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageCardGame.Model
{
    class Player
    {
        public string Name { get; private set; }
        public Hand Hand { get; set; }

        public void PickStat()
        {
            throw new NotImplementedException();
        }
    }
}
