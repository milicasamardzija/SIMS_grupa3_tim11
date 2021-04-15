using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public ObservableCollection<Room> RoomList
        {
            get;
            set;
        }

        public Rooms()
        {
            InitializeComponent();
            this.DataContext = this;
            RoomList = loadJason();
        }

  
        public ObservableCollection<Room> loadJason()
        {
            RoomFileStorage fs = new RoomFileStorage();
            ObservableCollection<Room> rs = new ObservableCollection<Room>(fs.GetAll());
            return rs;
        }

        private void dodavanje(object sender, RoutedEventArgs e)
        {
            DodajProstorijuDijalog  dp = new DodajProstorijuDijalog(RoomList);
            dp.Show(); 
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            IzbrisiProstorijuDijalog ip = new IzbrisiProstorijuDijalog(RoomList,(Room)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex);
            ip.Show();
        }
        //parametri i za brisanje i za izmenu:
        //1. lista soba iz ovog fajla
        //2. soba iz reda koji je selektovan
        //3. indeks reda koji je selektovan
        private void izmeni(object sender, RoutedEventArgs e)
        {
            IzmeniProstorijuDijalog izmeniP = new IzmeniProstorijuDijalog(RoomList,(Room)ListaProstorija.SelectedItem, ListaProstorija.SelectedIndex);
            izmeniP.Show();
        }

        private void prikazInventara(object sender, RoutedEventArgs e)
        {
            Inventar i = new Inventar((Room)ListaProstorija.SelectedItem);
            i.Show();
        }
    }
}
