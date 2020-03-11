using GarbageCardGame.Model;
using System.Collections.Generic;

namespace GarbageCardGame.DAO
{
    interface ICardDAO
    {
        List<Card> GetDeck();
    }
}
