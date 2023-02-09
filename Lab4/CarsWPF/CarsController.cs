using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarsWPF
{
    class CarsController
    {
        public List<Car> myCars;
        public CarsController(List<Car> cars)
        {
            myCars = cars;
        }

        public void LinqExample()
        {
            var elements = from e in (
                               from c in myCars
                               where c.model == "A6"
                               select new
                               {
                                   engineType = c.motor.model == "TDI" ? "Diesel" : "Petrol",
                                   hppl = c.motor.horsePower / c.motor.displacement
                               })
                           group e by e.engineType into gr
                           select new
                           {
                               engineType = gr.Key,
                               avgHPPL = gr.Average(p => p.hppl)
                           };
            foreach (var e in elements) Console.WriteLine(e.engineType + ": " + e.avgHPPL);

            var elementsMB = myCars.
                Where(c => c.model == "A6").
                Select(c => new {
                    engineType = c.motor.model == "TDI" ? "Diesel" : "Petrol",
                    hppl = c.motor.horsePower / c.motor.displacement
                }).
                GroupBy(e => e.engineType).
                Select(gr => new {
                    engineType = gr.Key,
                    avgHPPL = gr.Average(p => p.hppl)
                });
            foreach (var e in elementsMB) Console.WriteLine(e.engineType + ": " + e.avgHPPL);
        }

        public void DelegatesExample()
        {
            List<Car> myCarscpy = this.myCars;
            Func<Car, Car, int> arg1 = ComparePowers;
            Predicate<Car> arg2 = IsTdi;
            Action<Car> arg3 = ShowInMessageBox;
            myCarscpy.Sort(new Comparison<Car>(arg1));
            myCarscpy.FindAll(arg2).ForEach(arg3);
        }

        public static int ComparePowers(Car car1, Car car2)
        {
            return car2.motor.horsePower.CompareTo(car1.motor.horsePower);
        }

        public static bool IsTdi(Car car)
        {
            return car.motor.model == "TDI";
        }

        public static void ShowInMessageBox(Car car)
        {
            MessageBox.Show(String.Format(
                "Model:{0} \nYear: {1} \n Displacement {2} \n Engine model: {3}\n Horsepower: {4}", 
                car.model, car.year, car.motor.displacement, car.motor.model, car.motor.horsePower),
                "Car");
        }
    }
}
