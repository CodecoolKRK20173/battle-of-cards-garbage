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

        public GameController()
        {
            GameDeck = new Deck(new CardDAO(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv"));
            GameDeck.Shuffle();

            Player1 = new Player("Player1");
            Player1.Hand.GetHand(GameDeck);
            Player2 = new Player("Player2");
            Player2.Hand.GetHand(GameDeck);
        }
    }
}
