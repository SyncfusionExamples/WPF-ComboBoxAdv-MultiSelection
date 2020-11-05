using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comboboxadv_items
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> _items;

        private ObservableCollection<object> selectedItems;
        public ObservableCollection<object> SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                RaisePropertyChanged("SelectedItems");
            }
        }
        private ObservableCollection<Country> countries;
        public ObservableCollection<Country> Countries
        {
            get { return countries; }
            set
            {
                countries = value;
            }
        }
        public ViewModel()
        {
            Countries = new ObservableCollection<Country>();

            Countries.Add(new Country() { Name = "Denmark" });
            Countries.Add(new Country() { Name = "New Zealand" });
            Countries.Add(new Country() { Name = "Canada" });
            Countries.Add(new Country() { Name = "Russia" });
            Countries.Add(new Country() { Name = "Japan" });

            _items = new ObservableCollection<object>();
            for (int i = 0; i < 2; i++)
            {
                _items.Add(Countries[i]);
            }
            SelectedItems = new ObservableCollection<object>(_items);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            var property = PropertyChanged;
            if (property != null)
                property(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
