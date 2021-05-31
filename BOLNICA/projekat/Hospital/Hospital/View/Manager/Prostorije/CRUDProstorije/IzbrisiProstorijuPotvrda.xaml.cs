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
using System.Windows.Shapes;

namespace Hospital.View.Manager.Prostorije.CRUDProstorije
{
    public partial class IzbrisiProstorijuPotvrda : Window
    {
        private ObservableCollection<RoomDTO> rooms = new ObservableCollection<RoomDTO>();
        private int index;
        private int id;
        private RoomsController controller = new RoomsController();
        public IzbrisiProstorijuPotvrda(int id, System.Collections.ObjectModel.ObservableCollection<DTO.RoomDTO> rooms, int index)
        {
            InitializeComponent();
            this.id = id;
            this.rooms = rooms;
            this.index = index;
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            rooms.RemoveAt(index);
            controller.deleteById(id);
            this.Close();
        }
    }
}
