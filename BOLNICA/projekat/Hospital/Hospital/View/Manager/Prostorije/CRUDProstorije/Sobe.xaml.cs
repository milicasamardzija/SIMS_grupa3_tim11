using Hospital.Controller;
using Hospital.DTO;
using Hospital.View.Manager.Prostorije.RenoviranjeProstorije;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
using Hospital.View.Manager.Ostalo;

namespace Hospital
{
    public partial class Sobe : UserControl
    {
        public ObservableCollection<RoomDTO> Rooms { get; set; }
        private Frame frameMagacin { get; set; }
        private RoomsController roomController = new RoomsController();
        private InventoryController inventoryController = new InventoryController();
        public Sobe(Frame magacin)
        {
            InitializeComponent();
            this.DataContext = this;
            frameMagacin = magacin;
            Rooms = new ObservableCollection<RoomDTO>(roomController.getAll());
            ucitajInventar();
            SobeFrame.NavigationService.Navigate(new BelsekaMagacin(1));
            setTooltips();
        }

        void setTooltips()
        {
            if (ProfilUpravnik.isToolTipVisible)
            {
                Style style = new Style(typeof(ToolTip));
                style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
                style.Seal();
                this.Resources.Add(typeof(ToolTip), style);
            }
            else
            {
                this.Resources.Remove(typeof(ToolTip));
            }
        }

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            SobeFrame.NavigationService.Navigate(new DodajProstoriju(ListaProstorija,Rooms, SobeFrame));
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            if (ListaProstorija.SelectedItem == null)
            {
                SobeFrame.NavigationService.Navigate(new BelsekaMagacin(1));
            }
            else
            {
                SobeFrame.NavigationService.Navigate(new IzbrisiProstoriju(Rooms, (RoomDTO)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex, SobeFrame));
            }
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (ListaProstorija.SelectedItem == null)
            {
                SobeFrame.NavigationService.Navigate(new BelsekaMagacin(1));
            }
            else
            {
                SobeFrame.NavigationService.Navigate(new IzmeniProstoriju(Rooms, (RoomDTO)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex, SobeFrame));
            }
        }

        private void prikazInventara(object sender, RoutedEventArgs e)
        {
           frameMagacin.NavigationService.Navigate(new PrikazInventaraUSobi(Rooms, (RoomDTO)ListaProstorija.SelectedItem,frameMagacin));
        }
      
        private void PretragaSobe(object sender, TextChangedEventArgs e)
        {
            if (PretragaTxt.Text == "")
            {
                ListaProstorija.ItemsSource = roomController.getAll();
            }
            else
            {
                ListaProstorija.ItemsSource = roomController.roomsByType(PretragaTxt.Text);
            }
        }

        public void ucitajInventar()
        {
            foreach (InventoryDTO inventory in inventoryController.getAll())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = inventory.Name;
                item.Tag = inventory.Id;
                ImeInventarTxt.Items.Add(item);
            }
        }
        private void KolicinaInventarTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            int quantity = -1;
            if (!KolicinaInventarTxt.Text.Equals("")) {
                quantity = Convert.ToInt32(KolicinaInventarTxt.Text);
            }
            if (KolicinaInventarTxt.Text.Equals(""))
            {
                ListaProstorija.ItemsSource = roomController.getAll();
            } else
            {
                ListaProstorija.ItemsSource = roomController.roomByInventory(Convert.ToInt32(((ComboBoxItem)ImeInventarTxt.SelectedItem).Tag), quantity);
            }
        } 

        private void zakaziRenoviranje(object sender, RoutedEventArgs e)
        {
            if (ListaProstorija.SelectedItem == null)
            {
                SobeFrame.NavigationService.Navigate(new BelsekaMagacin(1));
            } else {
                SobeFrame.NavigationService.Navigate(new Renoviranje(SobeFrame, (RoomDTO)ListaProstorija.SelectedItem));
            }
        }

        private void RenoviranjePrikaz(object sender, RoutedEventArgs e)
        {
            frameMagacin.NavigationService.Navigate(new PrikazSobaRenoviranje(frameMagacin));
        }
    }
}
