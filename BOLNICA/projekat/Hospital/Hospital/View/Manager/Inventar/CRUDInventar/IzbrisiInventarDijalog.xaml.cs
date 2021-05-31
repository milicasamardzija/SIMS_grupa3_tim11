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
using Hospital.Controller;
using Hospital.View.Manager.Inventar.CRUDInventar;

namespace Hospital
{
    public partial class IzbrisiInventarDijalog : UserControl
    {
        private Frame frame;
        private ObservableCollection<InventoryDTO> inventories;
        private int index;
        private InventoryController controller;
        private InventoryDTO inventory;
        public InventoryDTO Inventory
        {
            get { return inventory;}
            set { inventory = value; }
        }
        public IzbrisiInventarDijalog(Frame frame,ObservableCollection<InventoryDTO> inventories, InventoryDTO inventory, int index)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.inventories = inventories;
            this.index = index;
            this.controller = new InventoryController();
            this.inventory = inventory;
            addType();
        }
        private void addType()
        {
            TypeTxt.ItemsSource = Enum.GetValues((typeof(InventoryType)));
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            BrisanjePotvrdiInventar brisanje = new BrisanjePotvrdiInventar(inventory.Id,inventories,index);
            brisanje.Show();
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
