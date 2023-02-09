using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarsWPF
{
    [XmlRoot(ElementName = "engine")]
    public class Engine : IComparable
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Engine otherEngine = obj as Engine;
            if (otherEngine != null)
                return this.horsePower.CompareTo(otherEngine.horsePower);
            else
                throw new ArgumentException("Object is not an Engine");
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ({2} hp)", this.model, this.displacement, this.horsePower);
        }
    }
}
