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
    /// Interaction logic for Magacin.xaml
    /// </summary>
    public partial class Magacin : UserControl
    {
        public ObservableCollection<Inventory> InventoryList
        {
            get;
            set;
        }

        public ObservableCollection<Room> ListRoom
        {
            get;
            set;
        }

        public Magacin(ObservableCollection<Room> roomList)
        {
            InitializeComponent();
            MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
            this.DataContext = this;
            InventoryList = loadJason();
            ListRoom = roomList;
            ListaInventara.ItemsSource = InventoryList;
        }

        public ObservableCollection<Inventory> loadJason()
        {
            InventoryFileStorage storage = new InventoryFileStorage();
            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>(storage.GetAll());
            return ret;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new DodajInventarDijalog(MagacinFrame,InventoryList));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new IzbrisiInventarDijalog(MagacinFrame,InventoryList,(Inventory)ListaInventara.SelectedItem,ListaInventara.SelectedIndex));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            Inventory inventory = (Inventory)ListaInventara.SelectedItem;
            if (inventory.Type == InventoryType.staticki)
                MagacinFrame.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventara(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
            else
                MagacinFrame.NavigationService.Navigate(new PremestiInventarUSobu(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, ListRoom));
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new IzmenaInventaraDijalog(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
        }

        private List<Inventory> filteredInventory = new List<Inventory>();

        private void PretragaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            InventoryFileStorage storage = new InventoryFileStorage();
            List<Inventory> all = storage.GetAll();

            filteredInventory.Clear();

            if (PretragaTxt.Text.Equals(""))
            {
                ListaInventara.ItemsSource = loadJason();
            }
            else
            {
                foreach (Inventory inv in all)
                {
                    if (inv.Name.Contains(PretragaTxt.Text))
                    {
                        filteredInventory.Add(inv);

                    }
                    if (PretragaTxt.Text.Contains("0") || PretragaTxt.Text.Contains("1") || PretragaTxt.Text.Contains("2") || PretragaTxt.Text.Contains("3") || PretragaTxt.Text.Contains("4") || PretragaTxt.Text.Contains("5") || PretragaTxt.Text.Contains("6") || PretragaTxt.Text.Contains("7") || PretragaTxt.Text.Contains("8") || PretragaTxt.Text.Contains("9")) {
                        if (inv.Quantity == Convert.ToInt32(PretragaTxt.Text))
                        {
                            filteredInventory.Add(inv);
                        }

                    }
                    if (PretragaTxt.Text.Equals("staticki"))
                    {
                        if (inv.Type == InventoryType.staticki)
                        {
                            filteredInventory.Add(inv);
                        }
                    } else if (PretragaTxt.Text.Equals("dinamicki"))
                    {
                        if (inv.Type == InventoryType.dinamicki)
                        {
                            filteredInventory.Add(inv);
                        }
                    }
                }
                ListaInventara.ItemsSource = filteredInventory.ToList();
            }
        }
    }
}
