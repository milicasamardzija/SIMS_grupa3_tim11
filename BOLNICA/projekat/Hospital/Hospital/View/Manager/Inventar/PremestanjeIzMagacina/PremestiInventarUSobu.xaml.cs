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
        public ObservableCollection<InventoryDTO> inventories;
        public InventoryDTO inventory;
        private DataGrid inventarTabela;
        private InventoryController inventoryController = new InventoryController();
        private RoomsController roomController = new RoomsController();
        public PremestiInventarUSobu(Frame frame, ObservableCollection<InventoryDTO> inventories, InventoryDTO inventory, int selectedIndex, DataGrid listaInventara)
        {
            InitializeComponent();
            this.frame = frame;
            this.inventories = inventories;
            this.inventory = inventory;
            this.inventarTabela = listaInventara;
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

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            inventoryController.moveInventory(new RoomInventory(-1, Convert.ToInt32(((ComboBoxItem)SobeComboBox.SelectedItem).Tag), inventory.Id, Convert.ToInt32(KolicinaTxt.Text)), -1);
            inventarTabela.ItemsSource = inventoryController.getAll();
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
