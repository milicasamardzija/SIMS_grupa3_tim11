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
            RoomFileStorage roomStorage= new RoomFileStorage();

            int idRoom = Convert.ToInt32(IdSobeTxt.Text);
            int quantity = Convert.ToInt32(KolicinaTxt.Text);

            Boolean nadjen = true;

            List<RoomInventory> all = storage.GetAll();

            foreach (RoomInventory roomInv in all)
            {
                if (roomInv.inventoryId == idInventory && roomInv.roomId == Convert.ToInt32(IdSobeTxt.Text))
                {
                    roomInv.quantity += quantity;
                    inventory.Quantity -= quantity;
                    nadjen = false;
                    storage.SaveAll(all);
                    break;
                }
            }

            if (nadjen)
            {
                RoomInventory newInventory = new RoomInventory(idRoom, inventory.InventoryId, quantity);
                storage.Save(newInventory);
                inventory.Quantity -= quantity;

                inventory.roomInventory.Add(newInventory);

                List<Room> rooms = roomStorage.GetAll();

                foreach (Room r in rooms)
                {
                    if (r.RoomId == idRoom)
                    {
                        r.roomInventory.Add(newInventory);
                    }
                }

                roomStorage.SaveAll(rooms);
            }

            inventoryStorage.SaveAll(listInventory);

            listInventory[index] = new Inventory(inventory.InventoryId,inventory.Name,inventory.Quantity,inventory.Type);

            frame.NavigationService.Navigate(this);
        }
    }
}
