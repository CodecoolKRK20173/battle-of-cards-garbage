﻿using System;
using System.Collections.Generic;
using GarbageCardGame.DAO;
using GarbageCardGame.Model;
using GarbageCardGame.View;

namespace GarbageCardGame.Controller
{
    class GameController
    {
        public Deck GameDeck { get; set; }
        public Hand TemporaryHand { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        private IComparer<Card> Comparer { get; set; }
        private ViewGarbage View { get; set; }

        public GameController()
        {
            GameDeck = new Deck(new CardDAO(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv"));
            GameDeck.Shuffle();
            TemporaryHand = new Hand();
            Player1 = new Player("Player1", true);
            Player1.Hand.GetHand(GameDeck);
            Player2 = new Player("Player2");
            Player2.Hand.GetHand(GameDeck);
            Comparer = new CardComparer();
            View = new ViewGarbage();
        }

        public void PlayRound(Player player1, Player player2)
        {
            if (player1.IsActive)
            {
                PrintCardMenu(player1);
                PickAStatToCompare(player1, player2);
            }
            else
            {
                PrintCardMenu(player2);
                PickAStatToCompare(player2, player1);
            }

            if (player1.Hand.CardsInHand[0].CompareThisStat.HasValue)
            {
                int result = CompareCards();
                ResolveComparison(result);
            }
        }

        private void PrintCardMenu(Player player)
        {
            Console.Clear();
            View.Print($"{player.Name} is active now:\n");
            View.Print(player.Hand.CardsInHand[0].ToString());
            View.Print("\nWhich stat would you like to use for comparison?");
        }

        private void PickAStatToCompare(Player playerA, Player playerB)
        {
            int initialFalseStarterValue = -1;
            int pickedStat = playerA.PickStat(initialFalseStarterValue);
            playerB.PickStat(pickedStat);
        }

        private int CompareCards()
        {
            return Comparer.Compare(Player1.Hand.CardsInHand[0], Player2.Hand.CardsInHand[0]);
        }

        private void ResolveComparison(int result)
        {
            if (result == 1)
            {
                View.Print("Player1 won this round");
                MoveResolvedCards(Player1, Player2);
                ChangeActivePlayer(Player1, Player2);
            }
            if (result == -1)
            {
                View.Print("Player2 won this round");
                MoveResolvedCards(Player2, Player1);
                ChangeActivePlayer(Player2, Player1);
            }
            if (result == 0)
            {
                View.Print("It was a draw. Game continues...");
                TemporaryHand.AddCard(Player1.Hand.CardsInHand[0]);
                TemporaryHand.RemoveCard(Player1.Hand.CardsInHand[0]);
                TemporaryHand.RemoveCard(Player2.Hand.CardsInHand[0]);
                TemporaryHand.AddCard(Player1.Hand.CardsInHand[0]);
            }
        }

        private void MoveResolvedCards(Player playerA, Player playerB)
        {
            playerA.Hand.AddCard(playerA.Hand.CardsInHand[0]);
            playerA.Hand.RemoveCard(playerA.Hand.CardsInHand[0]);
            playerA.Hand.AddCard(playerB.Hand.CardsInHand[0]);
            playerB.Hand.RemoveCard(playerB.Hand.CardsInHand[0]);
            foreach (var card in TemporaryHand.CardsInHand)
            {
                playerA.Hand.AddCard(card);
                TemporaryHand.RemoveCard(card);
            }
        }

        private void ChangeActivePlayer(Player playerA, Player playerB)
        {
            playerA.IsActive = true;
            playerB.IsActive = false;
        }

        public bool AnyPlayerHasWon()
        {
            return (Player1.Hand.CardsInHand.Count == 0 || Player2.Hand.CardsInHand.Count == 0) ? true : false;
        }

        public void EndGameScenario()
        {
            string winner = (Player1.Hand.CardsInHand.Count > 0) ? Player1.Name : Player2.Name;
            Console.Clear();
            View.Print($"Congratulations {winner}!!!\nYou have won the game.");
        }
    }
}
