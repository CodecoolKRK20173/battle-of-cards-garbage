using GarbageCardGame.View;
using GarbageCardGame.Controller;
using System.Collections.Generic;
using System.Xml.Serialization;
using GarbageCardGame.Model;
using System.IO;
using System;

namespace GarbageCardGame
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ViewGarbage View = new ViewGarbage();
            GameController Game = new GameController();

            SerializeToXml(Game.GameDeck.CardDeck, Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.xml");

            View.Print("Welcome to the game.\nThe cards are already dealt.\nIt is Player1 turn...");
            System.Threading.Thread.Sleep(3000);
            while (!Game.AnyPlayerHasWon())
            {
                Game.PlayRound(Game.Player1, Game.Player2);
            }
            Game.EndGameScenario();
        }

        public static void SerializeToXml(List<Card> cards, string filePath)
        {
            XmlSerializer XMLSerializer = new XmlSerializer(typeof(List<Card>));
            TextWriter textWriter = new StreamWriter(filePath);
            XMLSerializer.Serialize(textWriter, cards);
            textWriter.Close();
        }

        public static List<Card> DeserializeFromXml(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Card>));
            TextReader tr = new StreamReader(@filePath);
            List<Card> movie;
            movie = (List<Card>)deserializer.Deserialize(tr);
            tr.Close();

            return movie;
        }
    }
}

//TODO override hashCode() method and equals() method
