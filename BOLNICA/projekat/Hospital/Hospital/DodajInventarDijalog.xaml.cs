using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DodajInventarDijalog.xaml
    /// </summary>
    public partial class DodajInventarDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public DodajInventarDijalog(Frame m,ObservableCollection<Inventory> list)
        {
            InitializeComponent();
            frame = m;
            listInventory = list;
        }

        public int generisiId()
        {
            int ret = 0;

            InventoryFileStorage storage = new InventoryFileStorage();
            List<Inventory> allInventories = storage.GetAll();

            foreach (Inventory inventoryBig in allInventories)
            {
                foreach (Inventory inventory in allInventories)
                {
                    if (ret == inventory.InventoryId)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            InventoryFileStorage storage = new InventoryFileStorage();

            Inventory newInventory = new Inventory(generisiId(),NameTxt.Text,Convert.ToInt32(QuantityTxt.Text),(InventoryType)TypeTxt.SelectedIndex);

            storage.Save(newInventory);
            listInventory.Add(newInventory);
        }
    }
}
