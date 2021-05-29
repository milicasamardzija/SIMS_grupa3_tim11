using Hospital.Controller;
using Hospital.DTO;
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
    public partial class DodajInventarDijalog : UserControl
    {
        private Frame frame;
        private ObservableCollection<InventoryDTO> inventories;
        private InventoryController inventoryController;
        private InventoryDTO inventory = new InventoryDTO();

        public InventoryDTO Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        public DodajInventarDijalog(Frame frame,ObservableCollection<InventoryDTO> inventories)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.inventories = inventories;
            this.inventoryController = new InventoryController();
        }


        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            inventoryController.save(inventory);
            inventories.Add(inventory);
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
