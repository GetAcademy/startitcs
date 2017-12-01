using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace UndervisningPersistens
{
    public class NewspaperDemo
    {
        public static void Start()
        {
            var newspaper = Read();
            foreach (var item in newspaper.channel.item)
            {
                Console.WriteLine(item.title);
            }
        }

        private static rss Read()
        {
            const string url = "http://www.vg.no/rss/feed/?categories=1068,1069,1070&keywords=&limit=10&format=rss";
            XmlSerializer serializer = new XmlSerializer(typeof(rss));
            var webClient = new WebClient();            
            using (var reader = new StreamReader(webClient.OpenRead(url)))
            {
                return (rss)serializer.Deserialize(reader);
            }
        }
    }
}
