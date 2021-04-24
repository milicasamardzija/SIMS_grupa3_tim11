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
    /// Interaction logic for Sobe.xaml
    /// </summary>
    public partial class Sobe : UserControl
    {
        public ObservableCollection<Room> RoomList
        {
            get;
            set;
        }

        public Frame frameMagacin { get; set; }
        public Sobe(ObservableCollection<Room> roomList, Frame magacin)
        {
            InitializeComponent();
            this.DataContext = this;
            SobeFrame.NavigationService.Navigate(new BelsekaMagacin());
            RoomList = roomList;
            frameMagacin = magacin;
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
           frameMagacin.NavigationService.Navigate(new PrikazInventaraUSobi());
        }
    }
}
