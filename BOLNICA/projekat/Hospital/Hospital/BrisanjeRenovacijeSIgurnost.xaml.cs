using Hospital.Model;
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
using System.Windows.Shapes;

namespace Hospital
{
    public partial class BrisanjeRenovacijeSIgurnost : Window
    {
        private RoomRenovation room;
        private RenovationFileStorage storage = new RenovationFileStorage();
        private ObservableCollection<RoomRenovation> renovations = new ObservableCollection<RoomRenovation>();
        public BrisanjeRenovacijeSIgurnost(RoomRenovation selectedRoom,ObservableCollection<RoomRenovation> renovation)
        {
            InitializeComponent();
            room = selectedRoom;
            renovations = renovation;
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            storage.DeleteById(room.IdRenovation);
            renovations.Remove(room);
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
