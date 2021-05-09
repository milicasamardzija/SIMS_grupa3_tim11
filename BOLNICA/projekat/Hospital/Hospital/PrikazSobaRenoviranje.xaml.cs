using Hospital.Model;
using Hospital.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    public partial class PrikazSobaRenoviranje : UserControl
    {
        public ObservableCollection<RoomRenovation> Renovations
        {
            get;
            set;
        }
        private RenovationFileStorage storage = new RenovationFileStorage();
        private Frame back = new Frame();
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public PrikazSobaRenoviranje(ObservableCollection<Room> roomList, Frame roomss)
        {
            InitializeComponent();
            Renovations = loadJason();
            this.DataContext = this;
            back = roomss;
            rooms = roomList;
        }
        public ObservableCollection<RoomRenovation> loadJason()
        {
            RenovationFileStorage storage = new RenovationFileStorage();
            ObservableCollection<RoomRenovation> all = new ObservableCollection<RoomRenovation>(storage.GetAll());
            ObservableCollection<RoomRenovation> ret = new ObservableCollection<RoomRenovation>();

            foreach (RoomRenovation r in all)
            {
                ret.Add(r);
            }

            return all;
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            BrisanjeRenovacijeSIgurnost brisanje = new BrisanjeRenovacijeSIgurnost((RoomRenovation)ProstorijeRenoviranje.SelectedItem, Renovations);
            brisanje.Show();
        }

        private void unazad(object sender, RoutedEventArgs e)
        {
            back.NavigationService.Navigate(new Sobe(rooms, back));
        }
    }
}
