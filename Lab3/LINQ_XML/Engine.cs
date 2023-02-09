using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LINQ_XML
{
    [XmlRoot(ElementName = "engine")]
    public class Engine
    {
        public double displacement { get; set; }
        public double horsePower { get; set; }

        [XmlAttribute]
        public string model { get; set; }

        public Engine() {}
        public Engine(double displacement, double horsePower, string model)
        {
            this.displacement = displacement;
            this.horsePower = horsePower;
            this.model = model;
        }
    }
}
