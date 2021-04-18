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
            //storages
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            RoomFileStorage roomStorage= new RoomFileStorage();

            //argumenti
            int idRoom = Convert.ToInt32(IdSobeTxt.Text);
            int quantity = Convert.ToInt32(KolicinaTxt.Text);
            String name = ImeTxt.SelectedText;
            InventoryType type = (InventoryType)TypeTxt.SelectedIndex;

            //ako ne postoji inventar u toj sobi, odnosno pravi se novi RoomInventory objekat
            Boolean nadjen = true;

            //liste
            List<RoomInventory> all = storage.GetAll();
            List<Room> rooms = roomStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            foreach (RoomInventory roomInv in all)
            {
                //ako vec postoji zeljeni inventar u unetoj sobi
                if (roomInv.inventoryId == idInventory && roomInv.roomId == idRoom)
                {
                    roomInv.quantity += quantity;  //povecava se kolicina inventara u sobi
                    nadjen = false;
                    storage.SaveAll(all);           //kompletna izmenja lista se serijalizuje


                    //izmene se cuvaju i u RoomInventory listi sobe u koju se prebacuje
                    foreach (Room r in rooms)
                    {
                        if (r.RoomId == idRoom)
                        {
                            foreach (RoomInventory inventoryInRoom in r.roomInventory)
                            {
                                if (inventoryInRoom.inventoryId == idInventory)
                                {
                                    inventoryInRoom.quantity += quantity;   //uvecava se kolicina pronadjenog inventara
                                    roomStorage.SaveAll(rooms);
                                    break;
                                }
                            }
                        }
                    }

                    //izmene se cuvaju i u RoomInventory listi inventara koji se prebacuje
                    foreach (Inventory i in inventories)
                    {
                        if (i.InventoryId == idInventory)
                        {
                            i.Quantity -= quantity;
                            listInventory[index] = new Inventory(i.InventoryId, i.Name, i.Quantity, i.Type);
                            foreach (RoomInventory roomInInventory in i.roomInventory)
                            {
                                if (roomInInventory.inventoryId == idInventory)
                                {
                                    roomInInventory.quantity += quantity;
                                    inventoryStorage.SaveAll(inventories);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
            }

            //ako ne postoji izabrani inventar u unetoj sobi
            if (nadjen)
            {
                //dodaje se novi objekat u fajl RoomInventory
                RoomInventory newRInventory = new RoomInventory(idRoom,idInventory,quantity);
                storage.Save(newRInventory);

                //dodaje se u listu RoomInventory unete sobe
                foreach (Room r in rooms)
                {
                    if (r.RoomId == idRoom)
                    {
                        r.roomInventory.Add(newRInventory);
                        roomStorage.SaveAll(rooms);
                        break;
                    }
                }

                //dodaje se u listu RoomInventory izabranog inventara
                foreach (Inventory i in inventories)
                {
                    if (i.InventoryId == idInventory)
                    {
                        i.Quantity -= quantity;
                        listInventory[index] = new Inventory(i.InventoryId, i.Name, i.Quantity, i.Type);
                        i.roomInventory.Add(newRInventory);
                        inventoryStorage.SaveAll(inventories);
                        break;
                    }
                }
            }

            frame.NavigationService.Navigate(this);
        }
    }
}
