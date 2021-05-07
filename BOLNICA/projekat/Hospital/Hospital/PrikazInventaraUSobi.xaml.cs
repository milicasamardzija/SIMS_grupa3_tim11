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
    /// Interaction logic for PrikazInventaraUSobi.xaml
    /// </summary>
    public partial class PrikazInventaraUSobi : UserControl
    {
        public ObservableCollection<Inventory> listInventory
        {
            get;
            set;
        }
        private List<Inventory> filteredInventory = new List<Inventory>();
        private ObservableCollection<Inventory> all = new ObservableCollection<Inventory>();
        public Room room;
        public PrikazInventaraUSobi(Room selectedRoom)
        {
            InitializeComponent();
            this.DataContext = this;
            room = selectedRoom;
            listInventory = loadJason();
            ListaInventara.ItemsSource = listInventory;
            InventarPemesti.NavigationService.Navigate(new BelsekaMagacin());
        }

        public ObservableCollection<Inventory> loadJason()
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();

            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>();

            foreach (RoomInventory r in storage.GetAll())
            {
                if (r.idRoom.Equals(room.RoomId))
                {
                    Inventory i = inventoryStorage.FindById(r.idInventory);
                    if (i != null)
                        ret.Add(new Inventory(i.InventoryId, i.Name, r.Quantity, i.Type));
                    else
                        break;
                }

            }

            return ret;
        }


        private void premesti(object sender, RoutedEventArgs e)
        {
            Inventory inventory = (Inventory)ListaInventara.SelectedItem;
            if (inventory.Type == InventoryType.staticki)
                InventarPemesti.NavigationService.Navigate(new PremestanjeInventara(InventarPemesti,listInventory,ListaInventara,false,room));
            else
                InventarPemesti.NavigationService.Navigate(new PremestanjeInventaraDijalog(InventarPemesti, listInventory, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, room));
        }

        
        private void PretragaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
      
            filteredInventory.Clear();
            all = loadJason();

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
                    if (PretragaTxt.Text.Contains("0") || PretragaTxt.Text.Contains("1") || PretragaTxt.Text.Contains("2") || PretragaTxt.Text.Contains("3") || PretragaTxt.Text.Contains("4") || PretragaTxt.Text.Contains("5") || PretragaTxt.Text.Contains("6") || PretragaTxt.Text.Contains("7") || PretragaTxt.Text.Contains("8") || PretragaTxt.Text.Contains("9"))
                    {
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
                    }
                    else if (PretragaTxt.Text.Equals("dinamicki"))
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
