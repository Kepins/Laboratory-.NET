using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace LINQ_XML
{
    public static class Serializer
    {
        public static XmlDocument SerializeCarsXML(List<Car>cars)
        {
            XmlDocument doc = new XmlDocument();
            XPathNavigator nav = doc.CreateNavigator();
            using (XmlWriter w = nav.AppendChild())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));
                serializer.Serialize(w, cars);
            }
            return doc;
        }

        public static List<Car> DeserializeCarsXML(XmlDocument doc)
        {
            List<Car> cars = new List<Car>();
            using (XmlReader r = new XmlNodeReader(doc))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));
                cars = (List<Car>)serializer.Deserialize(r);
            }
            return cars;
        }

    }
}
