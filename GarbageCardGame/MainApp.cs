using GarbageCardGame.View;
using GarbageCardGame.Controller;
using System.Collections.Generic;
using System.Xml.Serialization;
using GarbageCardGame.Model;
using System.IO;
using System;
using GarbageCardGame.DAO;

namespace GarbageCardGame
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ViewGarbage View = new ViewGarbage();
            //GameController Game = new GameController();

            Deck allCadrds = new Deck(new CardDAO(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.csv"));
            SerializeToXml(allCadrds.CardDeck, Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.xml");

            List<Card> deserializedCards = DeserializeFromXml(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.xml");
            Console.WriteLine(deserializedCards[0]);

            //View.Print("Welcome to the game.\nThe cards are already dealt.\nIt is Player1 turn...");
            //System.Threading.Thread.Sleep(3000);
            //while (!Game.AnyPlayerHasWon())
            //{
            //    Game.PlayRound(Game.Player1, Game.Player2);
            //}
            //Game.EndGameScenario();
        }

        public static void SerializeToXml(List<Card> cards, string filePath)
        {
            XmlSerializer XMLSerializer = new XmlSerializer(typeof(List<Card>));
            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                XMLSerializer.Serialize(textWriter, cards);
            }
        }

        public static List<Card> DeserializeFromXml(string filePath)
        {
            XmlSerializer XMLDeserializer = new XmlSerializer(typeof(List<Card>));
            List<Card> cards;
            using (TextReader textReader = new StreamReader(filePath))
            {
                cards = (List<Card>)XMLDeserializer.Deserialize(textReader);
            }
            return cards;
        }
    }
}

//TODO override hashCode() method and equals() method
