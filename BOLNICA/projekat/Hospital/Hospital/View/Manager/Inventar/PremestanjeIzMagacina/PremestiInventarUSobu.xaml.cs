using Hospital.Controller;
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
using Hospital.DTO;

namespace Hospital
{
    public partial class PremestiInventarUSobu : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int idInventory;
        public Inventory inventory;
        public ObservableCollection<Room> listRooms;
        private StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
        private InventoryFileStorage inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
        private int idRoom;
        private int quantity;
        private DataGrid inventarTabela;
        private InventoryController inventoryController = new InventoryController();
        private RoomsController roomController = new RoomsController();
        public PremestiInventarUSobu(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, DataGrid listaInventara)
        {
            InitializeComponent();

            frame = magacinFrame;
            listInventory = list;
            index = selectedIndex;
            inventory = selecetedInventory; //selektovani inevntar
            idInventory = selecetedInventory.Id; //id selektovanog inventara
            listRooms = loadJason();
            inventarTabela = listaInventara;
            addRooms();
            potvrdiBtn.IsEnabled = false;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }

        private void addRooms()
        {
            SobeComboBox.Items.Clear();
            foreach (RoomDTO room in roomController.getAll())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = Convert.ToString(room.Purpose) + " broj " + Convert.ToString(room.Id);
                item.Tag = room.Id;
                SobeComboBox.Items.Add(item);
            }
        }

        public ObservableCollection<Room> loadJason()
        {
            RoomFileStorage fs = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
            ObservableCollection<Room> rs = new ObservableCollection<Room>(fs.GetAll());
            return rs;
        }

        public ObservableCollection<Inventory> loadJsonInventory()
        {
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>(storage.GetAll());
            return ret;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            idRoom = Convert.ToInt32(((ComboBoxItem)SobeComboBox.SelectedItem).Tag);
            quantity = Convert.ToInt32(KolicinaTxt.Text);

            inventoryController.moveInventory(new RoomInventory(-1,idRoom, inventory.Id, quantity), -1);
            inventarTabela.ItemsSource = loadJsonInventory();
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void SobeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!ImeTxt.Text.Equals("") && !KolicinaTxt.Text.Equals("") && SobeComboBox.SelectedIndex != -1)
            {
                potvrdiBtn.IsEnabled = true;
            }
        }
    }
}
