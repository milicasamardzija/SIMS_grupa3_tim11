using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
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
using Hospital.Controller;

namespace Hospital
{
    public partial class IzmenaInventaraDijalog : UserControl
    {
        private Frame frame;
        private ObservableCollection<InventoryDTO> inventories;
        private int index;
        private InventoryDTO inventory = new InventoryDTO();
        public InventoryDTO Inventory
        {
            get { return inventory;}
            set { inventory = value; }
        }

        private InventoryController controller;
        public IzmenaInventaraDijalog(Frame frame, ObservableCollection<InventoryDTO> inventories, InventoryDTO inventory, int index)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.inventories = inventories;
            this.index = index;
            this.inventory = inventory;
            this.controller = new InventoryController();
            addType();
        }
        private void addType()
        {
            TypeTxt.ItemsSource = Enum.GetValues((typeof(InventoryType)));
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
           frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            controller.update(new InventoryDTO(inventory.Id,inventory.Name,inventory.Quantity,inventory.Type));
            inventories[index] = Inventory;
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }
    }
}
