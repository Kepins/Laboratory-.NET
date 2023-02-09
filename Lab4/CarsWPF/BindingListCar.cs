using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWPF 
{
    class BindingListCar : BindingList<Car>
    {
        public BindingListCar(List<Car> list)
        {
            foreach(Car car in list)
            {
                Add(car);
            }
        }
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (prop.PropertyType.GetInterface("IComparable") != null)
            {
                List<Tuple<object, Car>> sorted = new List<Tuple<object, Car>>();

                foreach(Car car in Items)
                {
                    sorted.Add(Tuple.Create(prop.GetValue(car), car));
                }

                sorted.Sort((x, y) =>
                {
                    Type type = prop.PropertyType;
                    dynamic x_t = Convert.ChangeType(x.Item1, type);
                    dynamic y_t = Convert.ChangeType(y.Item1, type);
                    return x_t.CompareTo(y_t);
                });
                if (direction == ListSortDirection.Descending)
                {
                    sorted.Reverse();
                }

                Clear();
                foreach(var tuple in sorted)
                {
                    Add(tuple.Item2);
                }
            }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            for (int i= 0; i<Items.Count; i++)
            {
                Type type = prop.PropertyType;
                dynamic key_t = Convert.ChangeType(key, type);
                dynamic field_t = Convert.ChangeType(prop.GetValue(Items[i]), type);
                if (field_t == key_t)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Sort(string prop_name, ListSortDirection direction)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Car));
            var prop = properties.Find(prop_name, true);
            if (prop!=null)
            {
                ApplySortCore(prop, direction);
            }
        }

        public Car Find(string prop_name, object key)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Car));
            var prop = properties.Find(prop_name, true);
            if (prop != null)
            {
                int idx = FindCore(prop, key);
                if (idx != -1)
                {
                    return Items[FindCore(prop, key)];
                }
            }
            return null;
        }
    }
}
