using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace LINQ_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>(){
                new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
                new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
                new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
                new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
                new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
                new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
                new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
                new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
                new Car("S8", new Engine(4.0, 513, "TFSI"), 2012)
            };
            var enginesA6 = from car in myCars
                     where car.model == "A6"
                     select new {
                            engineType = car.motor.model == "TDI" ? "Diesel" : "Petrol",
                            hppl = car.motor.horsePower / car.motor.displacement
                        };
            var groupedEnginesA6 = from engine in enginesA6
                                   group engine by engine.engineType
                                   into g
                                   select g;
            foreach (var group in groupedEnginesA6)
            {
                double average = 0.0;
                foreach (var value in group)
                {
                    average += value.hppl;
                }
                average /= group.Count();

                Console.WriteLine(group.Key + ": " + average);
            }

            XmlDocument carsXML = Serializer.SerializeCarsXML(myCars);

            //save XmlDocument to file
            using (StreamWriter sw = new StreamWriter("CarsCollection.xml"))
            {
                carsXML.Save(sw);
            }

            //read data from file
            XmlDocument carsReadXML = new XmlDocument();
            using (StreamReader sr = new StreamReader("CarsCollection.xml"))
            {
                carsReadXML.Load(sr);
            }

            List<Car> carsDeserialized = Serializer.DeserializeCarsXML(carsReadXML);


            //XPATH expressions
            XElement rootNode = XElement.Load("CarsCollection.xml");
            double avgHP = (double)rootNode.XPathEvaluate("sum(/car/engine[@model!=\"TDI\"]/horsePower) div count(/car/engine[@model!=\"TDI\"])");

            IEnumerable<XElement> models = rootNode.XPathSelectElements("/car[not(model = following-sibling::car/model)]/model");
            foreach(var model in models)
            {
                Console.WriteLine(model.Value);
            }

            
            createXmlFromLinq(myCars);
            createXhtmlFromLinq(myCars);
            changeCarsCollection();
        }

        private static void createXmlFromLinq(List<Car> myCars)
        {
            IEnumerable<XElement> nodes = myCars.Select(c =>
                                    new XElement("car",
                                        new XElement("model", c.model),
                                        new XElement("engine", new XAttribute("model", c.motor.model), new XElement("displacement", c.motor.displacement),
                                            new XElement("horsePower", c.motor.horsePower)),
                                        new XElement("year", c.year)));
            XElement rootNode = new XElement("cars", nodes); //create a root node to contain the query results
            rootNode.Save("CarsFromLinq.xml");
        }

        private static void createXhtmlFromLinq(List<Car> myCars)
        {
            IEnumerable<XElement> rows = myCars.Select(c =>
                new XElement("tr", new XAttribute("style", "border: 2px solid black"),
                    new XElement("td", new XAttribute("style", "border: 2px double black"), c.model),
                    new XElement("td", new XAttribute("style", "border: 2px double black"), c.motor.model),
                    new XElement("td", new XAttribute("style", "border: 2px double black"), c.motor.displacement),
                    new XElement("td", new XAttribute("style", "border: 2px double black"), c.motor.horsePower),
                    new XElement("td", new XAttribute("style", "border: 2px double black"), c.year)));
            XElement table = new XElement("table", new XAttribute("style", "border: 2px double black"), rows);
            XElement template = XElement.Load("template.html");
            XElement body = template.Element("{http://www.w3.org/1999/xhtml}body");
            body.Add(table);
            template.Save("table.html");
        }

        private static void changeCarsCollection()
        {
            XElement xml = XElement.Load("CarsCollection.xml");
            foreach(var car in xml.Elements())
            {
                var engine = car.Element("engine");
                var horsePower = engine.Element("horsePower");
                horsePower.Name = "hp";

                var year = car.Element("year");
                var model = car.Element("model");
                XAttribute yearattr = new XAttribute("year", year.Value);
                model.Add(yearattr);
                year.Remove();
            }
            xml.Save("CarsCollectionModified.xml");
        }
    }
}
