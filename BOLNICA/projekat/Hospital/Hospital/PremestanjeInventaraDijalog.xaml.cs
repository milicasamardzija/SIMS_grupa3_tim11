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
    /// Interaction logic for PremestanjeInventaraDijalog.xaml
    /// </summary>
    public partial class PremestanjeInventaraDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int idInventory;
        public Inventory inventory;
        public Boolean magacin;
        public int roomOutId;

        public PremestanjeInventaraDijalog(Frame m, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, Room roomOut)
        {
            InitializeComponent();
            frame = m;
            listInventory = list;
            index = selectedIndex;
            inventory = selecetedInventory;
            idInventory = selecetedInventory.InventoryId;
            roomOutId = roomOut.RoomId;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            RoomFileStorage roomStorage = new RoomFileStorage();
            int idRoom = -1;

            //argumenti
            if (!IdSobeTxt.Text.Equals("")) {
                idRoom = Convert.ToInt32(IdSobeTxt.Text);
            }

            int quantity = Convert.ToInt32(KolicinaTxt.Text);
            String name = ImeTxt.SelectedText;
            InventoryType type = (InventoryType)TypeTxt.SelectedIndex;

            //ako se prebacuje u magacin
            Boolean magacin = (Boolean)MagacinRB.IsChecked;
            Boolean soba = (Boolean)ProstorijaRB.IsChecked;

            //liste
            List<RoomInventory> all = storage.GetAll();
            List<Room> rooms = roomStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            Boolean nePostojiUSobi = true;

            if (magacin) // prebacuje se u magacin
            {
                foreach (RoomInventory ri in all)
                {
                    if (ri.Inventory.InventoryId == idInventory && ri.Room.RoomId == roomOutId)
                    {
                        ri.Quantity -= quantity;
                        listInventory[index] = new Inventory(inventory.InventoryId, inventory.Name, ri.Quantity, inventory.Type);
                        storage.SaveAll(all);
                        break;
                    }
                }

                foreach (Inventory invent in inventories)
                {
                    if (invent.InventoryId == idInventory)
                    {
                        invent.Quantity += quantity;
                        inventoryStorage.SaveAll(inventories);
                        break;
                    }
                }

            } 
            //prebacuje se iz sobe u drugu sobu
            if (soba)
            {
                foreach (RoomInventory roomInv in all)
                {
                    //ako inventar koji se prebacuje vec postoji u unetoj sobi
                    if (roomInv.Inventory.InventoryId == idInventory && roomInv.Room.RoomId == idRoom)
                    {
                        roomInv.Quantity += quantity;
                        nePostojiUSobi = false;
                        storage.SaveAll(all);
                        break;
                    }
                }

                //ako inventar koji se prebacuje ne postoji u sobi u koju se prebacuje
                if (nePostojiUSobi)
                {
                    Room room = new Room();
                    Inventory invent = new Inventory();

                    foreach (Room r in roomStorage.GetAll())
                    {
                        if (r.RoomId == idRoom)
                        {
                            room.RoomId = r.RoomId;
                            room.Floor = r.Floor;
                            room.Occupancy = r.Occupancy;
                            room.Purpose = r.Purpose;
                            break;
                        }
                    }

                    foreach (Inventory i in inventoryStorage.GetAll())
                    {
                        if (i.InventoryId == idInventory)
                        {
                            invent.InventoryId = i.InventoryId;
                            invent.Name = i.Name;
                            invent.Quantity = i.Quantity;
                            invent.Type = i.Type;
                            break;
                        }
                    }

                    RoomInventory newRInventory = new RoomInventory(room, invent, quantity);
                    all.Add(newRInventory);
                }

                //umanjuje se kolicina u sobi iz koje se izbacuje
                foreach (RoomInventory ri in all)
                {
                    if (ri.Room.RoomId == roomOutId && ri.Inventory.InventoryId == idInventory)
                    {
                        ri.Quantity -= quantity;
                        listInventory[index] = new Inventory(inventory.InventoryId, inventory.Name, ri.Quantity, inventory.Type);
                        storage.SaveAll(all);
                        break;
                    }
                }

            }

            frame.NavigationService.Navigate(this);

        }
    }
}
