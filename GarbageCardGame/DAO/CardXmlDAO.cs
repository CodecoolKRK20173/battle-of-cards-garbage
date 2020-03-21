using GarbageCardGame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GarbageCardGame.DAO
{
    class CardXmlDAO : ICardDAO
    {
        public List<Card> GetDeck()
        {
            List<Card> deserializedCards = DeserializeFromXml(Environment.CurrentDirectory + @"..\..\..\..\Resorces\waste.xml");
            return deserializedCards;
        }

        private List<Card> DeserializeFromXml(string filePath)
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
