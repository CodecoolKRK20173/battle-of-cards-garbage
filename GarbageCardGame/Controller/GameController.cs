using System;
using System.Collections.Generic;
using System.Text;
using GarbageCardGame.DAO;
using GarbageCardGame.Model;
using GarbageCardGame.View;

namespace GarbageCardGame.Controller
{
    class GameController
    {
        public Deck GameDeck { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        private IComparer<Card> Comparer { get; set; }

        public GameController()
        {
            GameDeck = new Deck(new CardDAO(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv"));
            GameDeck.Shuffle();

            Player1 = new Player("Player1");
            Player1.Hand.GetHand(GameDeck);
            Player2 = new Player("Player2");
            Player2.Hand.GetHand(GameDeck);

            Comparer = new CardComparer();
        }

        public void PlayRound(Player player1, Player player2)
        {
            PrintCardMenu(player1);
            PickAStatToCompare(player1, player2);
            int result = CompareCards(player1, player2);
            ResolveComparison(result);
        }

        private void PrintCardMenu(Player player)
        {
            ViewGarbage View = new ViewGarbage();
            View.Print(player.Hand.CardsInHand[0].ToString());
            View.Print("\nWhich stat would u like to use for comparison?");
        }
        private void PickAStatToCompare(Player player1, Player player2)
        {
            int initialFalseStatrterValue = -1;
            int pickedStat = player1.PickStat(initialFalseStatrterValue);
            player2.PickStat(pickedStat);
        }

        private int CompareCards(Player player1, Player player2)
        {
            return Comparer.Compare(player1.Hand.CardsInHand[0], player2.Hand.CardsInHand[0]);
        }

        private void ResolveComparison(int result)
        {
            //TODO proper implementation for this method
            if (result == 1) Console.WriteLine("Player1won");
            if (result == -1) Console.WriteLine("Player2won");
            if (result == 0) Console.WriteLine("Draw");
        }

        public bool AnyPlayerHasWon()
        {
            return (Player1.Hand.CardsInHand.Count == 0 || Player2.Hand.CardsInHand.Count == 0) ? true : false;
        }
    }
}
