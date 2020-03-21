using GarbageCardGame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace GarbageCardGame.DAO
{
    class CardXmlDAO : ICardDAO
    {
        public List<Card> GetDeck()
        {
            throw new NotImplementedException();
        }

        public void SerializeToXml(List<Card> cards, string filePath)
        {
            XmlSerializer XMLSerializer = new XmlSerializer(typeof(List<Card>));
            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                XMLSerializer.Serialize(textWriter, cards);
            }
        }

        public List<Card> DeserializeFromXml(string filePath)
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
