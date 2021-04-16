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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Inventar.xaml
    /// </summary>
    public partial class Inventar : Window
    {
        public ObservableCollection<Inventory> listInventory
        {
            get;
            set;
        }

        public Room room;

        public Inventar(Room selectedRoom)
        {
            InitializeComponent();
            this.DataContext = this;
            room = selectedRoom;
            listInventory = loadJason();
            InventarPemesti.NavigationService.Navigate(new PremestanjeInventaraDijalog(InventarPemesti, listInventory,(Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
        }

        public ObservableCollection<Inventory> loadJason()
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage storageInventory = new InventoryFileStorage();

            List<RoomInventory> rooms = new List<RoomInventory>(); //lista RoomInvnetory koja sadrzi samo elemente koji imaju id selektovane sobe
            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>();

           foreach (RoomInventory r in storage.GetAll())
           {
                if (r.roomId.Equals(room.RoomId))
                {
                    RoomInventory roomFound = storage.FindById(r.roomId);
                    rooms.Add(new RoomInventory(r.roomId,r.inventoryId,r.quantity));
                }

           }

            foreach (RoomInventory i in rooms) 
            {
                 foreach (Inventory inventr in storageInventory.GetAll())
                 {
                        if (i.inventoryId == inventr.InventoryId)
                        {
                            Inventory foundInventory = storageInventory.FindById(i.inventoryId);
                            ret.Add(new Inventory(foundInventory.InventoryId, foundInventory.Name, i.quantity, foundInventory.Type));
                        }
                   }
             }
            return ret;
        }
    }
}
