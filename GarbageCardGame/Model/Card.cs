using System;
using System.Text;

namespace GarbageCardGame.Model
{
    public class Card : IComparable<Card>
    {
        public string CardName { get; set; }
        public int Degradability { get; set; }
        public int Toxicity { get; set; }
        public int Recyclability { get; set; }
        public int EnergyRecovery { get; set; }
        public int TotalStatSum { get; set; }
        public int? CompareThisStat { get; set; }

        public Card()
        {

        }

        public Card(string cardName, int[] numericalStats)
        {
            CardName = cardName;
            Degradability = numericalStats[(int)Stats.degradability];
            Toxicity = numericalStats[(int)Stats.toxicity];
            Recyclability = numericalStats[(int)Stats.recyclability];
            EnergyRecovery = numericalStats[(int)Stats.energyRecovery];
            TotalStatSum = Degradability + Toxicity + Recyclability + EnergyRecovery;
            CompareThisStat = null;
        }

        /// <summary>
        /// This is the implementation for IComparable interface.
        /// This method compares the total sum off all card stats.
        /// It is the default comparer for the Card class which sorts cards in descending order.
        /// </summary>
        public int CompareTo(Card other)
        {
            if (this.TotalStatSum < other.TotalStatSum)
                return 1;
            if (this.TotalStatSum > other.TotalStatSum)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            string separatorLine = "|========================|";

            StringBuilder cardString = new StringBuilder();
            cardString.AppendLine(separatorLine);
            cardString.AppendLine(CardName);
            cardString.AppendLine(separatorLine);
            cardString.AppendLine($"1. Degradability = {Degradability}");
            cardString.AppendLine($"2. Toxicity = {Toxicity}");
            cardString.AppendLine($"3. Recyclability = {Recyclability}");
            cardString.AppendLine($"4. Energy Recovery = {EnergyRecovery}");
            cardString.AppendLine(separatorLine);
            return cardString.ToString();
        }
    }
}
