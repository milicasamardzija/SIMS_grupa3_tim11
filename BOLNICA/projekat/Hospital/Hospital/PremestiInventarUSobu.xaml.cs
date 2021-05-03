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
        private StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
        private InventoryFileStorage inventoryStorage = new InventoryFileStorage();
        private int idRoom;
        private int quantity;

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
            idRoom = Convert.ToInt32(IdSobeTxt.Text);
            
            quantity = Convert.ToInt32(KolicinaTxt.Text);
            inventoryStorage.moveInventory(inventory, idRoom, -1, quantity);
            frame.NavigationService.Navigate(this);
        }
    }
}
