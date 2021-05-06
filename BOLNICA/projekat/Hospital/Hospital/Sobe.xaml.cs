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
        public ObservableCollection<Room> RoomList
        {
            get;
            set;
        }

        private Frame frameMagacin { get; set; }
        private RoomFileStorage storageRooms = new RoomFileStorage();
        public Sobe(ObservableCollection<Room> roomList, Frame magacin)
        {
            InitializeComponent();
            this.DataContext = this;
            SobeFrame.NavigationService.Navigate(new BelsekaMagacin());
            RoomList = roomList;
            frameMagacin = magacin;
            ListaProstorija.ItemsSource = RoomList;
            ucitajNamene();
            ucitajInventar();
        }

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            SobeFrame.NavigationService.Navigate(new DodajProstoriju(RoomList, frameMagacin));
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            SobeFrame.NavigationService.Navigate(new IzbrisiProstoriju(RoomList, (Room)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex, frameMagacin));
        }
     
        private void izmeni(object sender, RoutedEventArgs e)
        {
            SobeFrame.NavigationService.Navigate(new IzmeniProstoriju(RoomList, (Room)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex,frameMagacin));
        }

        private void prikazInventara(object sender, RoutedEventArgs e)
        {
           frameMagacin.NavigationService.Navigate(new PrikazInventaraUSobi((Room)ListaProstorija.SelectedItem));
        }

        public ObservableCollection<Room> loadJason()
        {
            RoomFileStorage fs = new RoomFileStorage();
            ObservableCollection<Room> rs = new ObservableCollection<Room>(fs.GetAll());
            return rs;
        }

        private List<Room> filtratedRooms = new List<Room>();
        private void PretragaSobe(object sender, TextChangedEventArgs e)
        {
            List<Room> all = storageRooms.GetAll();
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
                }
                ListaProstorija.ItemsSource = filtratedRooms;
            }
        }

        public void ucitajInventar()
        {
            InventoryFileStorage storage = new InventoryFileStorage();
            foreach (Inventory inventory in storage.GetAll())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = inventory.Name;
                item.Tag = inventory.InventoryId;
                ImeInventarTxt.Items.Add(item);
            }
        }
        public void ucitajNamene()
        {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "";
                NamenaTxt.Items.Add(item);
                ComboBoxItem itemSala = new ComboBoxItem();
                itemSala.Content = "sala";
                itemSala.Tag = "sala";
                NamenaTxt.Items.Add(itemSala);
                ComboBoxItem itemSoba = new ComboBoxItem();
                itemSoba.Content = "soba";
                itemSoba.Tag = "soba";
                NamenaTxt.Items.Add(itemSoba);
                ComboBoxItem itemOrdinacija= new ComboBoxItem();
                itemOrdinacija.Content = "ordinacija";
                itemOrdinacija.Tag = "ordinacija";
                NamenaTxt.Items.Add(itemOrdinacija);
        }


        private void NamenaTxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Room> all = storageRooms.GetAll();
            filtratedRooms.Clear();

            if (Convert.ToString(((ComboBoxItem)NamenaTxt.SelectedItem).Tag).Equals(""))
            {
                ListaProstorija.ItemsSource = loadJason();
            }
            else
            {

                foreach (Room room in all)
                {
                    if (Convert.ToString(((ComboBoxItem)NamenaTxt.SelectedItem).Tag).Equals("soba"))
                    {
                        if (room.Purpose == Purpose.soba)
                        {
                            filtratedRooms.Add(room);
                        }

                    }
                    else if (Convert.ToString(((ComboBoxItem)NamenaTxt.SelectedItem).Tag).Equals("sala"))
                    {
                        if (room.Purpose == Purpose.sala)
                        {
                            filtratedRooms.Add(room);
                        };
                    }
                    else if (Convert.ToString(((ComboBoxItem)NamenaTxt.SelectedItem).Tag).Equals("ordinacija"))
                    {
                        if (room.Purpose == Purpose.ordinacija)
                        {
                            filtratedRooms.Add(room);
                        }
                    }
                }
                ListaProstorija.ItemsSource = filtratedRooms;
            }
        }

        private void KolicinaInventarTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            filtratedRooms.Clear();
            String name = (Convert.ToString(((ComboBoxItem)ImeInventarTxt.SelectedItem).Content));
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
                        if (room.RoomId == ri.idRoom && ri.idInventory == idInventory && ri.Quantity == quantity)
                        {
                            filtratedRooms.Add(room);
                        }

                    }
                }
                ListaProstorija.ItemsSource = filtratedRooms;
            }
        }
    }  
}
