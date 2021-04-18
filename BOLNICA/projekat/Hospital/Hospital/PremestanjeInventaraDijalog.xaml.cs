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
            if (!IdSobeTxt.Text.Equals(""))
            {
                idRoom = Convert.ToInt32(IdSobeTxt.Text);
            }
            
            int quantity = Convert.ToInt32(KolicinaTxt.Text);
            String name = ImeTxt.SelectedText;
            InventoryType type = (InventoryType)TypeTxt.SelectedIndex;

            //ako se prebacuje u magacin
            Boolean magacin = (Boolean)MagacinRB.IsChecked;

            //liste
            List<RoomInventory> all = storage.GetAll();
            List<Room> rooms = roomStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            Boolean nePostojiUSobi = true;

            if (magacin) // prebacuje se u magacin
            {
                foreach (RoomInventory inveRoom in all)
                {
                    //smanjuje se kolicina inventara u sobi
                    if (inveRoom.inventoryId == idInventory && inveRoom.roomId == roomOutId)
                    {
                        inveRoom.quantity -= quantity;
                        listInventory[index] = new Inventory(inveRoom.inventoryId, inventory.Name, inveRoom.quantity, inventory.Type);
                        storage.SaveAll(all);

                        foreach (Inventory i  in inventories)
                        {
                            if (i.InventoryId == idInventory)
                            {
                                i.Quantity += quantity;
                                inventoryStorage.SaveAll(inventories);
                                break;
                            }
                        }
                    }
                }

            } else //prebacuje se iz sobe u drugu sobu
            {
                foreach (RoomInventory roomInv in all)
                {
                    //ako inventar koji se prebacuje vec postoji u unetoj sobi
                    if (roomInv.inventoryId == idInventory && roomInv.roomId == idRoom)
                    {
                        roomInv.quantity += quantity;
                        nePostojiUSobi = false;
                        storage.SaveAll(all);

                        //promene se cuvaju i u RoomInventory listi sobe u koju se prebacuje
                        foreach (Room r in rooms)
                        {
                            if (r.RoomId == idRoom)
                            {
                                foreach (RoomInventory inventoryInRoom in r.roomInventory)
                                {
                                    if (inventoryInRoom.inventoryId == idInventory)
                                    {
                                        inventoryInRoom.quantity += quantity;
                                        roomStorage.SaveAll(rooms);
                                        break;
                                    }
                                }
                            }
                        }

                        //promene se cuvaju i u RoomInventory sobe iz koje se prebacuje
                        foreach (Room rOut in rooms)
                        {
                            if (rOut.RoomId == roomOutId)
                            {
                                foreach (RoomInventory inventoryInRoom in rOut.roomInventory)
                                {
                                    if (inventoryInRoom.inventoryId == idInventory)
                                    {
                                        inventoryInRoom.quantity -= quantity;
                                        roomStorage.SaveAll(rooms);
                                        break;
                                    }
                                }
                            }
                        }

                        //promene se cuvaju u inventar
                        foreach(RoomInventory ri in all)
                        {
                            if (ri.roomId ==roomOutId && ri.inventoryId==idInventory)
                            {
                                ri.quantity -= quantity;
                                listInventory[index] = new Inventory(ri.inventoryId,inventory.Name,ri.quantity,inventory.Type);
                                storage.SaveAll(all);
                            }
                        }

                        //promene u RoomInventory liste inventara koji se premesta
                        foreach (Inventory i in inventories)
                        {
                            if (i.InventoryId == idInventory)
                            {
                                foreach (RoomInventory roomInInventory in i.roomInventory)
                                {
                                    if (roomInInventory.inventoryId == idInventory && roomInInventory.roomId == idRoom) //soba iz koje se prebacuje
                                    {
                                        roomInInventory.quantity -= quantity;
                                        inventoryStorage.SaveAll(inventories);
                                        break;
                                    }
                                }
                            }
                        }

                        //promene u RoomInventory liste inventara koji se premesta
                        foreach (Inventory i in inventories)
                        {
                            if (i.InventoryId == idInventory)
                            {
                                foreach (RoomInventory roomInInventory in i.roomInventory)
                                {
                                    if (roomInInventory.inventoryId == idInventory && roomInInventory.roomId == roomOutId) //soba u koju se prebacuje
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

                //ako inventar koji se prebacuje ne postoji u sobi u koju se prebacuje
                if (nePostojiUSobi)
                {
                    //dodaje se novi objekat u fajl RoomInventory
                    RoomInventory newRInventory = new RoomInventory(idRoom,idInventory,quantity);
                    List<RoomInventory> listRoomInv = storage.GetAll();
                    listRoomInv.Add(newRInventory);
                    storage.SaveAll(listRoomInv);

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

                    //umanjuje se kolicina u sobi iz koje se izbacuje
                    foreach (RoomInventory ri in all)
                    {
                        if (ri.roomId == roomOutId && ri.inventoryId == idInventory)
                        {
                            ri.quantity -= quantity;
                            listInventory[index] = new Inventory(ri.inventoryId, inventory.Name, ri.quantity, inventory.Type);
                            storage.SaveAll(all);
                            break;
                        }
                    }
                }
            }

            frame.NavigationService.Navigate(this);

        }
    }
}
