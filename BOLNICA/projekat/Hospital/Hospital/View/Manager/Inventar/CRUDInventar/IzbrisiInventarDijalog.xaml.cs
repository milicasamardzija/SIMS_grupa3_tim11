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
    /// <summary>
    /// Interaction logic for IzbrisiInventarDijalog.xaml
    /// </summary>
    public partial class IzbrisiInventarDijalog : UserControl
    {
        public Frame frame;
        public ObservableCollection<InventoryDTO> listInventory;
        public int index;
        public int id;
        public IzbrisiInventarDijalog(Frame m,ObservableCollection<InventoryDTO> list,Inventory selecetdInventory, int selectedIndex)
        {
            InitializeComponent();
            frame = m;
            listInventory = list;
            id = selecetdInventory.Id;
            index = selectedIndex;

            ImeTxt.SelectedText = selecetdInventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(selecetdInventory.Quantity);
            TypeTxt.SelectedIndex = (int)selecetdInventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            storage.DeleteById(id);
            listInventory.RemoveAt(index);
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
