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
    /// Interaction logic for PremestanjeInventaraDijalog.xaml
    /// </summary>
    public partial class PremestanjeInventaraDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int idInventory;
        public Inventory inventory;
        public Boolean magacin;

        public PremestanjeInventaraDijalog(Frame m, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex)
        {
            InitializeComponent();
            frame = m;
            listInventory = list;
            index = selectedIndex;
            inventory = selecetedInventory;
            idInventory = selecetedInventory.InventoryId;

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
            frame.NavigationService.Navigate(this);

        }
    }
}
