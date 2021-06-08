using Hospital.Controller;
using Hospital.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private ObservableCollection<Inventory> inventories;
        private InventoryController inventoryController;
        private Inventory inventory = new Inventory();

        public Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        public DodajInventarDijalog(Frame frame,ObservableCollection<Inventory> inventories)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.inventories = inventories;
            this.inventoryController = new InventoryController();
            addType();
            dodajBtn.IsEnabled = false;
        }

        private void addType()
        {
            TypeTxt.ItemsSource = Enum.GetValues((typeof(InventoryType)));
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            inventoryController.save(new InventoryDTO(inventory.Id,inventory.Name,inventory.Quantity,inventory.Type));
            inventories.Add(inventory);
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void QuantityTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!NameTxt.Text.Equals("") && !QuantityTxt.Text.Equals("") && TypeTxt.SelectedIndex != -1)
            {
                dodajBtn.IsEnabled = true;
            }
        }
    }
}
