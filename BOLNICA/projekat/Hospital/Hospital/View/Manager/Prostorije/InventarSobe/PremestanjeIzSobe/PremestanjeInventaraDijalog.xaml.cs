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
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;

namespace Hospital
{
    public partial class PremestanjeInventaraDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<InventoryDTO> inventories;
        public InventoryDTO inventory;
        public Boolean magacin;
        public int roomOutId;
        private int idRoom;
        private DataGrid listaInvetara;
        private InventoryController inventoryController = new InventoryController();
        public PremestanjeInventaraDijalog(Frame frame, ObservableCollection<InventoryDTO> inventories, InventoryDTO selecetedInventory, int selectedIndex, RoomDTO roomOut, DataGrid tablaPrikaz)
        {
            InitializeComponent();
            this.frame = frame;
            this.inventories = inventories;
            this.inventory = selecetedInventory;
            roomOutId = roomOut.Id;
            listaInvetara = tablaPrikaz;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(3));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            if (IdSobeTxt.Text.Equals(""))
            {
                idRoom = -1;
            }
            else
            {
                idRoom = Convert.ToInt32(IdSobeTxt.Text);
            }

            inventoryController.moveInventory(new RoomInventory(-1,idRoom, inventory.Id, Convert.ToInt32(KolicinaTxt.Text)), roomOutId);
            listaInvetara.ItemsSource = new ObservableCollection<InventoryDTO>(inventoryController.loadJasonInventory(roomOutId));

            frame.NavigationService.Navigate(new BelsekaMagacin(3));
        }
    }
}
