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
    /// Interaction logic for IzbrisiProstoriju.xaml
    /// </summary>
    public partial class IzbrisiProstoriju : UserControl
    {
        public ObservableCollection<Room> listRoom;
        public int index;
        public int id;
        public Frame frame;
        public IzbrisiProstoriju(ObservableCollection<Room> list, Room selectedRoom, int selectedIndex,Frame f)
        {
            InitializeComponent();
            listRoom = list;
            id = selectedRoom.RoomId; //id sobe koja je selktovana
            index = selectedIndex; //indeks u tabeli
            frame = f;

            brojProstorijeTxt.SelectedText = Convert.ToString(selectedRoom.RoomId);
            spratTxt.SelectedText = Convert.ToString(selectedRoom.Floor);
            namenaTxt.SelectedIndex = (int)selectedRoom.Purpose;
            kapacitetTxt.SelectedText = Convert.ToString(selectedRoom.Capacity);
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            RoomFileStorage storage = new RoomFileStorage();
            RoomInventoryFileStorage storageInventory = new RoomInventoryFileStorage();
            InventoryFileStorage storageOfInventories = new InventoryFileStorage();

            storage.DeleteById(id); //brise se iz fajla na osnovu id-a
            listRoom.RemoveAt(index); //brise se iz prikaza tabele

            foreach (RoomInventory inventory in storageInventory.GetAll())
            {
                if (inventory.roomId == id)
                {
                    storageInventory.DeleteByIdRoom(id);
                }
            }

            List<Inventory> allInventories = storageOfInventories.GetAll();
            foreach (Inventory inv in allInventories)
            {
                if (inv.roomInventory != null)
                {
                    foreach (RoomInventory ri in inv.roomInventory.ToList())
                    {
                        if (ri.roomId == id)
                        {
                            inv.roomInventory.Remove(ri);
                            storageOfInventories.SaveAll(allInventories);
                        }
                    }
                }
            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
