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
    public partial class PrikazInventaraUSobi : UserControl
    {
        public ObservableCollection<InventoryDTO> inventories
        {
            get;
            set;
        }
        public RoomDTO room;
        private Frame frame;
        private InventoryController inventoryController = new InventoryController();
        public PrikazInventaraUSobi(ObservableCollection<RoomDTO> rooms, RoomDTO room,Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.room = room;
            inventories = new ObservableCollection<InventoryDTO>(inventoryController.getInventoryForRoom(room.Id));
            ListaInventara.ItemsSource = inventoryController.getInventoryForRoom(room.Id);
            InventarPemesti.NavigationService.Navigate(new BelsekaMagacin(3));
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                InventarPemesti.NavigationService.Navigate(new BelsekaMagacin(3));
                MessageBoxResult result = MessageBox.Show("Niste selektovali inventar!");
            }
            else { 
                if (((InventoryDTO)ListaInventara.SelectedItem).Type == InventoryType.staticki)
                    InventarPemesti.NavigationService.Navigate(new PremestanjeInventara(InventarPemesti, inventories, ListaInventara, false, room, ListaInventara));
                else
                    InventarPemesti.NavigationService.Navigate(new PremestanjeInventaraDijalog(InventarPemesti, inventories, (InventoryDTO)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, room, ListaInventara));
            }
        }

        
        private void PretragaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PretragaTxt.Text.Equals(""))
            {
                ListaInventara.ItemsSource = inventoryController.getInventoryForRoom(room.Id);
            } else 
            {
                ListaInventara.ItemsSource = inventoryController.inventoryByName(PretragaTxt.Text);
            }
        }

        private void unazad(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Sobe(frame));
        }
    }
}
