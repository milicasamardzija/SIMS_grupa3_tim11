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
        private Frame back = new Frame();
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public PrikazInventaraUSobi(ObservableCollection<Room> roomList, Room selectedRoom,Frame roomss)
        {
            InitializeComponent();
            this.DataContext = this;
            room = selectedRoom;
            listInventory = loadJason();
            ListaInventara.ItemsSource = listInventory;
            InventarPemesti.NavigationService.Navigate(new BelsekaMagacin());
            back = roomss;
            rooms = roomList;
        }

        public ObservableCollection<Inventory> loadJason()
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();

            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>();

            foreach (RoomInventory r in storage.GetAll())
            {
                if (r.IdRoom.Equals(room.RoomId))
                {
                    Inventory i = inventoryStorage.FindById(r.IdInventory);
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
            if (ListaInventara.SelectedItem == null)
            {
                InventarPemesti.NavigationService.Navigate(new BelsekaMagacin());
            }
            else
            {
                Inventory inventory = (Inventory)ListaInventara.SelectedItem;
                if (inventory.Type == InventoryType.staticki)
                    InventarPemesti.NavigationService.Navigate(new PremestanjeInventara(InventarPemesti, listInventory, ListaInventara, false, room, ListaInventara));
                else
                    InventarPemesti.NavigationService.Navigate(new PremestanjeInventaraDijalog(InventarPemesti, listInventory, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, room, ListaInventara));
            }
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
                    if (inv.Name.ToUpper().Equals(PretragaTxt.Text.ToUpper()))
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
                    if (PretragaTxt.Text.ToUpper().Equals("staticki".ToUpper()))
                    {
                        if (inv.Type == InventoryType.staticki)
                        {
                            filteredInventory.Add(inv);
                        }
                    }
                    else if (PretragaTxt.Text.ToUpper().Equals("dinamicki".ToUpper()))
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

        private void unazad(object sender, RoutedEventArgs e)
        {
            back.NavigationService.Navigate(new Sobe(rooms,back));
        }
    }
}
