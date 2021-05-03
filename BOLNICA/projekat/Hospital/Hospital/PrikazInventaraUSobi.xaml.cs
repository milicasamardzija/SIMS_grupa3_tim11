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

        public Room room;
        public PrikazInventaraUSobi(Room selectedRoom)
        {
            InitializeComponent();
            this.DataContext = this;
            room = selectedRoom;
            listInventory = loadJason();
            InventarPemesti.NavigationService.Navigate(new BelsekaMagacin());
        }

        public ObservableCollection<Inventory> loadJason()
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();

            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>();

            foreach (RoomInventory r in storage.GetAll())
            {
                if (r.idRoom.Equals(room.RoomId))
                {
                    Inventory i = inventoryStorage.FindById(r.idInventory);
                    ret.Add(new Inventory(i.InventoryId,i.Name,r.Quantity,i.Type));
                }

            }

            return ret;
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            Inventory inventory = (Inventory)ListaInventara.SelectedItem;
            if (inventory.Type == InventoryType.staticki)
                InventarPemesti.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventaraUSobu(InventarPemesti, listInventory, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, room));
            else
                InventarPemesti.NavigationService.Navigate(new PremestanjeInventaraDijalog(InventarPemesti, listInventory, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, room));
        }
    }
}
