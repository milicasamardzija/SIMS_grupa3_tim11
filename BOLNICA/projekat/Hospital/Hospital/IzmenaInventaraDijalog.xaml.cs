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
    /// Interaction logic for IzmenaInventaraDijalog.xaml
    /// </summary>
    public partial class IzmenaInventaraDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int id;
        public Inventory inventory;
        public IzmenaInventaraDijalog(Frame m, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex)
        {
            InitializeComponent();
            frame = m;
            listInventory = list;
            id = selecetedInventory.InventoryId;
            index = selectedIndex;
            inventory = selecetedInventory;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
           frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            InventoryFileStorage storage = new InventoryFileStorage();

            inventory.Name = ImeTxt.Text;
            inventory.Quantity = Convert.ToInt32(KolicinaTxt.Text);
            inventory.Type = (InventoryType)TypeTxt.SelectedIndex;

            listInventory[index] = new Inventory(inventory.InventoryId,inventory.Name,inventory.Quantity,inventory.Type);

            storage.SaveAll(listInventory);
          //  storage.DeleteById(inventory.inventoryId);
           // storage.Save(inventory);

            frame.NavigationService.Navigate(this);

        }
    }
}
