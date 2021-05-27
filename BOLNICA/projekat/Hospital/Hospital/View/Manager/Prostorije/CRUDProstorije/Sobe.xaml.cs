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
    public partial class Sobe : UserControl
    {
        public ObservableCollection<RoomDTO> Rooms { get; set; }
        private Frame frameMagacin { get; set; }
        private RoomsController roomController = new RoomsController();
        public Sobe(Frame magacin)
        {
            InitializeComponent();
            this.DataContext = this;
            frameMagacin = magacin;
            Rooms = new ObservableCollection<RoomDTO>(roomController.getAll());
            ucitajInventar();
            //SobeFrame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            SobeFrame.NavigationService.Navigate(new DodajProstoriju(Rooms, (RoomDTO)ListaProstorija.SelectedItem, SobeFrame));
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            if (ListaProstorija.SelectedItem == null)
            {
                SobeFrame.NavigationService.Navigate(new BelsekaMagacin());
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
                SobeFrame.NavigationService.Navigate(new BelsekaMagacin());
            }
            else
            {
                SobeFrame.NavigationService.Navigate(new IzmeniProstoriju(Rooms, (RoomDTO)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex, SobeFrame));
            }
        }

        private void prikazInventara(object sender, RoutedEventArgs e)
        {
  //         frameMagacin.NavigationService.Navigate(new PrikazInventaraUSobi(rooms, (RoomDTO)ListaProstorija.SelectedItem,frameMagacin));
        }
      
        private List<Room> filtratedRooms = new List<Room>();
        private void PretragaSobe(object sender, TextChangedEventArgs e)
        {
           /* List<Room> all = storageRooms.GetAll();
            filtratedRooms.Clear();

            if (PretragaTxt.Text.Equals(""))
            {
                ListaProstorija.ItemsSource = loadJason();
            } else
            {
                foreach (Room room in all)
                {
                    if (PretragaTxt.Text.Contains("0") || PretragaTxt.Text.Contains("1") || PretragaTxt.Text.Contains("2") || PretragaTxt.Text.Contains("3") || PretragaTxt.Text.Contains("4") || PretragaTxt.Text.Contains("5") || PretragaTxt.Text.Contains("6") || PretragaTxt.Text.Contains("7") || PretragaTxt.Text.Contains("8") || PretragaTxt.Text.Contains("9"))
                    {
                        if (room.Floor == Convert.ToInt32(PretragaTxt.Text))
                        {
                            filtratedRooms.Add(room);
                        }
                    }
                    if (PretragaTxt.Text.ToUpper().Contains("soba".ToUpper()))
                    {
                        if (room.Purpose == Purpose.soba)
                        {
                            filtratedRooms.Add(room);
                        }
                    }
                    else if (PretragaTxt.Text.ToUpper().Contains("ordinacija".ToUpper()))
                    {
                        if (room.Purpose == Purpose.ordinacija)
                        {
                            filtratedRooms.Add(room);
                        }
                    }
                    else if (PretragaTxt.Text.ToUpper().Contains("sala".ToUpper()))
                    {
                        if (room.Purpose == Purpose.sala)
                        {
                            filtratedRooms.Add(room);
                        }
                    }
                }
                ListaProstorija.ItemsSource = filtratedRooms;
            }*/
        }

        public void ucitajInventar()
        {
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            foreach (Inventory inventory in storage.GetAll())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = inventory.Name;
                item.Tag = inventory.Id;
                ImeInventarTxt.Items.Add(item);
            }
        }
        private void KolicinaInventarTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
          /*  filtratedRooms.Clear();
            int quantity = -1;

            if (KolicinaInventarTxt.Text.Equals(""))
            {
                ListaProstorija.ItemsSource = loadJason();
            } else { 

                if (!KolicinaInventarTxt.Text.Equals("")) {
                    quantity = Convert.ToInt32(KolicinaInventarTxt.Text);
                }
            
                int idInventory = (Convert.ToInt32(((ComboBoxItem)ImeInventarTxt.SelectedItem).Tag));

                RoomInventoryFileStorage storage = new RoomInventoryFileStorage();

                foreach (Room room in storageRooms.GetAll())
                {
                    foreach (RoomInventory ri in storage.GetAll())
                    {
                        if (room.Id == ri.IdRoom && ri.IdInventory == idInventory && ri.Quantity == quantity)
                        {
                            filtratedRooms.Add(room);
                        }

                    }
                }
                ListaProstorija.ItemsSource = filtratedRooms;
            }*/
        } 

        private void zakaziRenoviranje(object sender, RoutedEventArgs e)
        {
            if (ListaProstorija.SelectedItem == null)
            {
                SobeFrame.NavigationService.Navigate(new BelsekaMagacin());
            } else {
                SobeFrame.NavigationService.Navigate(new RenoviranjeSobe(SobeFrame, (Room)ListaProstorija.SelectedItem));
            }
        }

        private void RenoviranjePrikaz(object sender, RoutedEventArgs e)
        {
            frameMagacin.NavigationService.Navigate(new PrikazSobaRenoviranje(Rooms,frameMagacin));
        }

        
    }
}
