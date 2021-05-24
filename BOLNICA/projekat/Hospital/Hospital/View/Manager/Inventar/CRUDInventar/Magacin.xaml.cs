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
        private Frame managerFrame = new Frame();
   
        public Magacin(ObservableCollection<Room> roomList, Frame frame)
        {
            InitializeComponent();
            MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
            this.DataContext = this;
            InventoryList = loadJason();
            ListRoom = roomList;
            ListaInventara.ItemsSource = InventoryList;
            managerFrame = frame;
        }

        public ObservableCollection<Inventory> loadJason()
        {
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>(storage.GetAll());
            return ret;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new DodajInventarDijalog(MagacinFrame,InventoryList));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
            }
            else
            {
                MagacinFrame.NavigationService.Navigate(new IzbrisiInventarDijalog(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
            }
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
            }
            else
            {
                Inventory inventory = (Inventory)ListaInventara.SelectedItem;
                if (inventory.Type == InventoryType.staticki)
                    MagacinFrame.NavigationService.Navigate(new PremestanjeInventara(MagacinFrame, InventoryList, ListaInventara, true, null, ListaInventara));
                else
                    MagacinFrame.NavigationService.Navigate(new PremestiInventarUSobu(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, ListaInventara));
            }
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
            }
            else
            {
                MagacinFrame.NavigationService.Navigate(new IzmenaInventaraDijalog(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
            }
        }

        private List<Inventory> filteredInventory = new List<Inventory>();

        private void PretragaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
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
                    if (inv.Name.ToUpper().Equals(PretragaTxt.Text.ToUpper()))
                    {
                        filteredInventory.Add(inv);

                    }
                    if (PretragaTxt.Text.Contains("0") || PretragaTxt.Text.Contains("1") || PretragaTxt.Text.Contains("2") || PretragaTxt.Text.Contains("3") || PretragaTxt.Text.Contains("4") || PretragaTxt.Text.Contains("5") || PretragaTxt.Text.Contains("6") || PretragaTxt.Text.Contains("7") || PretragaTxt.Text.Contains("8") || PretragaTxt.Text.Contains("9")) {
                        if (inv.Quantity == Convert.ToInt32(PretragaTxt.Text))
                        {
                            filteredInventory.Add(inv);
                        }

                    }
                    if (PretragaTxt.Text.ToUpper().Equals("staticki".ToUpper()))
                    {
                        if (inv.Type == InventoryType.staticki)
                        {
                            filteredInventory.Add(inv);
                        }
                    } else if (PretragaTxt.Text.ToUpper().Equals("dinamicki".ToUpper()))
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

        private void filtriranjeKolicina(object sender, TextChangedEventArgs e)
        {
            int kolicina = -1;
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            List<Inventory> all = storage.GetAll();
            if (!KolicinaFiltriranja.Text.Equals(""))
            {
               kolicina = Convert.ToInt32(KolicinaFiltriranja.Text);
            }
            filteredInventory.Clear();

            if (UslovFiltriranja.SelectedIndex == 0) //>=
            {
                foreach (Inventory inventory in all)
                {
                    if (inventory.Quantity >= kolicina)
                    {
                        filteredInventory.Add(inventory);
                    } 
                }
                ListaInventara.ItemsSource = filteredInventory.ToList();
                if (KolicinaFiltriranja.Text.Equals(""))
                {
                    ListaInventara.ItemsSource = InventoryList;
                }

            } else if (UslovFiltriranja.SelectedIndex == 1) //<=
            {
                foreach (Inventory inventory in all)
                {
                    if (inventory.Quantity <= kolicina)
                    {
                        filteredInventory.Add(inventory);
                    }
                }
                ListaInventara.ItemsSource = filteredInventory.ToList();
                if (KolicinaFiltriranja.Text.Equals(""))
                {
                    ListaInventara.ItemsSource = InventoryList;
                }
            } 
            
        }

    }
}
