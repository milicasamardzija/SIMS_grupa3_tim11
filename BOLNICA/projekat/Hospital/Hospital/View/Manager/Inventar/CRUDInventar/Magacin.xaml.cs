using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
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
using Hospital.View.Manager.Ostalo;

namespace Hospital
{
    public partial class Magacin : UserControl
    {
        public ObservableCollection<InventoryDTO> inventories
        {
            get;
            set;
        }

        public ObservableCollection<RoomDTO> rooms
        {
            get;
            set;
        }
        private Frame frame;
        private RoomsController roomController;
        private InventoryController inventoryController;

        public Magacin(Frame frame)
        {
            InitializeComponent();
            MagacinFrame.NavigationService.Navigate(new BelsekaMagacin(0));
            this.DataContext = this;
            this.frame = frame;
            this.roomController = new RoomsController();
            this.inventoryController = new InventoryController();
            this.inventories = new ObservableCollection<InventoryDTO>(inventoryController.getAll());
            setTooltips();
        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinFrame.NavigationService.Navigate(new DodajInventarDijalog(MagacinFrame,inventories));
        }

        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                MagacinFrame.NavigationService.Navigate(new BelsekaMagacin(0));
                MessageBoxResult result = MessageBox.Show("Niste selektovali inventar!");
            }
            else
            {
                MagacinFrame.NavigationService.Navigate(new IzbrisiInventarDijalog(MagacinFrame, inventories, (InventoryDTO)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
            }
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                MagacinFrame.NavigationService.Navigate(new BelsekaMagacin(0));
                MessageBoxResult result = MessageBox.Show("Niste selektovali inventar!");
            }
            else
            {
                if (((InventoryDTO)ListaInventara.SelectedItem).Type == InventoryType.staticki)
                    MagacinFrame.NavigationService.Navigate(new PremestanjeInventara(MagacinFrame, inventories, ListaInventara, true, null, ListaInventara));
                else
                    MagacinFrame.NavigationService.Navigate(new PremestiInventarUSobu(MagacinFrame, inventories, (InventoryDTO)ListaInventara.SelectedItem, ListaInventara.SelectedIndex, ListaInventara));
            }
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (ListaInventara.SelectedItem == null)
            {
                MagacinFrame.NavigationService.Navigate(new BelsekaMagacin(0));
                MessageBoxResult result = MessageBox.Show("Niste selektovali inventar!");
            }
            else
            {
                MagacinFrame.NavigationService.Navigate(new IzmenaInventaraDijalog(MagacinFrame, inventories, (InventoryDTO)ListaInventara.SelectedItem, ListaInventara.SelectedIndex));
            }
        }

        private void PretragaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PretragaTxt.Text.Equals(""))
            {
                ListaInventara.ItemsSource = inventoryController.getAll();
            }
            else //fali pretraga za tip i kolicinu
            {
                ListaInventara.ItemsSource = inventoryController.inventoryByName(PretragaTxt.Text);
            }
        }

        private void filtriranjeKolicina(object sender, TextChangedEventArgs e)
        {
            /*int kolicina = -1;
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            List<Inventory> all = storage.GetAll();
            if (!KolicinaFiltriranja.Text.Equals(""))
            {
               kolicina = Convert.ToInt32(KolicinaFiltriranja.Text);
            }
            filteredInventory.Clear();

            if (UslovFiltriranja.SelectedIndex == 0) 
            {
                foreach (Inventory inventory in all)
                {
                    if (inventory.Quantity >= kolicina)
                    {
                        filteredInventory.Add(inventory);
                    } 
                }
                ListaInventara.ItemsSource = filteredInventory.ToList();
                if (KolicinaFiltriranja.Text.Equals(""))
                {
                    ListaInventara.ItemsSource = inventories;
                }

            } else if (UslovFiltriranja.SelectedIndex == 1)
            {
                foreach (Inventory inventory in all)
                {
                    if (inventory.Quantity <= kolicina)
                    {
                        filteredInventory.Add(inventory);
                    }
                }
                ListaInventara.ItemsSource = filteredInventory.ToList();
                if (KolicinaFiltriranja.Text.Equals(""))
                {
                    ListaInventara.ItemsSource = inventories;
                }
            } 
            */
        }

        void setTooltips()
        {
            if (ProfilUpravnik.isToolTipVisible)
            {
                Style style = new Style(typeof(ToolTip));
                style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
                style.Seal();
                this.Resources.Remove(typeof(ToolTip));
            }
            else
            {
                Style style = new Style(typeof(ToolTip));
                style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
                style.Seal();
                this.Resources.Add(typeof(ToolTip), style);
            }
        }
    }
}
