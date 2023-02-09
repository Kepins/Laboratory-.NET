using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingSource carBindingSource;
        private BindingListCar bindListCar;

        public MainWindow()
        {
            InitializeComponent();
            CarsController carsController = new CarsController(new List<Car>(){
                new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
                new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
                new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
                new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
                new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
                new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
                new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
                new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
                new Car("S8", new Engine(4.0, 513, "TFSI"), 2012)
        });
            this.bindListCar = new BindingListCar(carsController.myCars);
            this.carBindingSource = new BindingSource();
            carBindingSource.DataSource = this.bindListCar;
            this.dataGrid1.ItemsSource = carBindingSource;

            carsController.LinqExample();
            carsController.DelegatesExample();

            bindListCar.Sort("motor", System.ComponentModel.ListSortDirection.Ascending);
            bindListCar.Sort("year", System.ComponentModel.ListSortDirection.Descending);

            Car car = bindListCar.Find("model", "S8");
            car = bindListCar.Find("year", 2009);

            carBindingSource.DataSource = this.bindListCar;
            this.dataGrid1.ItemsSource = carBindingSource;
        }

        
    }
}
