using Hospital.Controller;
using Hospital.Model;
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
    public partial class PremestanjeInventaraDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int idInventory;
        public Inventory inventory;
        public Boolean magacin;
        public int roomOutId;
        private StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
        private int idRoom;
        private int quantity;
        private InventoryFileStorage inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
        private DataGrid listaInvetara;
        private InventoryController inventoryController = new InventoryController();
        public PremestanjeInventaraDijalog(Frame m, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, Room roomOut, DataGrid tablaPrikaz)
        {
            InitializeComponent();
            frame = m;
            listInventory = list;
            index = selectedIndex;
            inventory = selecetedInventory;
            idInventory = selecetedInventory.Id;
            roomOutId = roomOut.Id;
            listaInvetara = tablaPrikaz;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(3));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            if (IdSobeTxt.Text.Equals(""))
            {
                idRoom = -1;
            }
            else
            {
                idRoom = Convert.ToInt32(IdSobeTxt.Text);
            }
            quantity = Convert.ToInt32(KolicinaTxt.Text);

            inventoryController.moveInventory(new RoomInventory(idRoom, inventory.Id, quantity), roomOutId);
            listaInvetara.ItemsSource = loadJasonInventory();

            frame.NavigationService.Navigate(new BelsekaMagacin(3));
        }

        public ObservableCollection<Inventory> loadJasonInventory()
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");

            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>();

            foreach (RoomInventory r in storage.GetAll())
            {
                if (r.IdRoom.Equals(roomOutId))
                {
                    Inventory i = inventoryStorage.FindById(r.IdInventory);
                    if (i != null)
                        ret.Add(new Inventory(i.Id, i.Name, r.Quantity, i.Type));
                    else
                        break;
                }

            }

            return ret;
        }
    }
}
