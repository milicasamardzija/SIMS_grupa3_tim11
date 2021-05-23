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
            id = selecetedInventory.Id;
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
            InventoryIFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            List<Inventory> allInventories = storage.GetAll();

            foreach (Inventory i in allInventories) {
                if (i.Id == id)
                {
                    i.Name = ImeTxt.Text;
                    i.Quantity = Convert.ToInt32(KolicinaTxt.Text);
                    i.Type = (InventoryType)TypeTxt.SelectedIndex;
                    listInventory[index] = new Inventory(i.Id, i.Name, i.Quantity, i.Type);
                    break;
                }
            }

            storage.SaveAll(allInventories);

            frame.NavigationService.Navigate(new BelsekaMagacin());

        }
    }
}
