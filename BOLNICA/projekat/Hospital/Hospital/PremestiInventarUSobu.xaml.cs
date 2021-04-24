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
    /// Interaction logic for PremestiInventarUSobu.xaml
    /// </summary>
    public partial class PremestiInventarUSobu : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int idInventory;
        public Inventory inventory;
        public ObservableCollection<Room> listRooms;

        public PremestiInventarUSobu(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, ObservableCollection<Room> listRoom)
        {
            InitializeComponent();

            frame = magacinFrame;
            listInventory = list;
            index = selectedIndex;
            inventory = selecetedInventory; //selektovani inevntar
            idInventory = selecetedInventory.InventoryId; //id selektovanog inventara
            listRooms = listRoom;

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

            //argumenti
            int idRoom = Convert.ToInt32(IdSobeTxt.Text);
            int quantity = Convert.ToInt32(KolicinaTxt.Text);
            String name = ImeTxt.SelectedText;
            InventoryType type = (InventoryType)TypeTxt.SelectedIndex;

            //ako ne postoji inventar u toj sobi, odnosno pravi se novi RoomInventory objekat
            Boolean nadjen = true;

            //liste
            List<RoomInventory> all = storage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            if (all != null)
            {

                foreach (RoomInventory roomInv in all)
                {
                    if (roomInv.Inventory != null) {
                        //ako vec postoji zeljeni inventar u unetoj sobi
                        if (roomInv.Inventory.InventoryId == idInventory && roomInv.Room.RoomId == idRoom)
                        {
                            roomInv.Quantity += quantity;   //povecava se kolicina inventara u sobi
                            nadjen = false;
                            storage.SaveAll(all);           //kompletna izmenja lista se serijalizuje
                            break;
                        }
                    }
                }

                //ako ne postoji izabrani inventar u unetoj sobi
                if (nadjen)
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
                    storage.Save(newRInventory);
                }

                foreach (Inventory i in inventories)
                {
                    if (i.InventoryId == idInventory)
                    {
                        i.Quantity -= quantity;
                        inventoryStorage.SaveAll(inventories);
                        listInventory[index] = new Inventory(inventory.InventoryId, inventory.Name, i.Quantity, inventory.Type);
                        break;
                    }
                }

            }

            frame.NavigationService.Navigate(this);
        }
    }
}
