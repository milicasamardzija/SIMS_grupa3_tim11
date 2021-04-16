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
    /// Interaction logic for Magacin.xaml
    /// </summary>
    public partial class Magacin : UserControl
    {
        public ObservableCollection<Inventory> InventoryList
        {
            get;
            set;
        }

        public ObservableCollection<Room> ListRoom
        {
            get;
            set;
        }

        public Magacin(ObservableCollection<Room> roomList)
        {
            InitializeComponent();
            MagacinFrame.NavigationService.Navigate(new BelsekaMagacin());
            this.DataContext = this;
            InventoryList = loadJason();
            ListRoom = roomList;
        }

        public ObservableCollection<Inventory> loadJason()
        {
            InventoryFileStorage storage = new InventoryFileStorage();
            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>(storage.GetAll());
            return ret;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new DodajInventarDijalog(MagacinFrame,InventoryList));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new IzbrisiInventarDijalog(MagacinFrame,InventoryList,(Inventory)ListaInventara.SelectedItem,ListaInventara.SelectedIndex));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new PremestiInventarUSobu(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, ListRoom));
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new IzmenaInventaraDijalog(MagacinFrame, InventoryList, (Inventory)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
        }
    }
}
