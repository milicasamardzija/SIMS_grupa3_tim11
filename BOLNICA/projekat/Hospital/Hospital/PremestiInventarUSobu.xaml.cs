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
            InventoryType type = (InventoryType)TypeTxt.SelectedIndex;

            //ako ne postoji inventar u toj sobi, odnosno pravi se oni RoomInventory objekat
            Boolean nadjen = true;

            //liste
            List<RoomInventory> all = storage.GetAll();
            List<Room> rooms = roomStorage.GetAll();

            //ako postoji vec zeljeni inventar u unetoj sobi
            foreach (RoomInventory roomInv in all)
            {
                if (roomInv.inventoryId == idInventory && roomInv.roomId == idRoom)
                {
                    roomInv.quantity += quantity;   //povecava se inventar u sobi
                    inventory.Quantity -= quantity; //smanjuje se inevntar u magacinu
                    nadjen = false;                 //new pravi se novi objekat RoomIvnetory
                    storage.SaveAll(all);           //izmene se cuvaju u RoomInventory

                    //izmene se cuvaju i u listi RoomInventory sobe u koju se prebacuje
                    foreach (Room r in rooms)
                    {
                        if (r.RoomId == idRoom)
                        {
                            foreach (RoomInventory ri in r.roomInventory)
                            {
                                if (ri.inventoryId == idInventory)
                                {
                                    ri.quantity += quantity;
                                }
                            }
                        }

                        break;
                    }

                    List<RoomInventory> inventoryRoomInv = inventory.roomInventory;

                    foreach (RoomInventory invent in inventoryRoomInv)
                    {
                        if ( invent.roomId == idRoom && invent.inventoryId == idInventory)
                        {
                            invent.quantity += quantity;        //cuvaju se izmene u inventaru u listi RoomInventory
                        }
                    }

                    break;
                }
            }

            if (nadjen)  //ako ne postoji izabrani inventar u unetoj sobi
            {
                RoomInventory newInventory = new RoomInventory(idRoom, inventory.InventoryId, quantity); //pravi se novi objekat
                storage.Save(newInventory);       //cuva se u fajl RoomStorage
                inventory.Quantity -= quantity;   //smanjuje se kolicina inventara u magacinu

                inventory.roomInventory.Add(newInventory);   //dodaju se izmene i u inventary

                foreach (Room r in rooms)                    //cuvaju se izmene i u sobi u koju se prebacuje
                {
                    if (r.RoomId == idRoom)
                    {
                        r.roomInventory.Add(newInventory);
                    }
                }

                roomStorage.SaveAll(rooms);
            }

            inventoryStorage.SaveAll(listInventory);          //sve izmene nad inventarom se cuvaju

            listInventory[index] = new Inventory(inventory.InventoryId,inventory.Name,inventory.Quantity,inventory.Type);

            frame.NavigationService.Navigate(this);
        }
    }
}
