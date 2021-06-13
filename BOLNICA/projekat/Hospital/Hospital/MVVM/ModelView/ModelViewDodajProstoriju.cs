using Hospital.Controller;
using Hospital.DTO;
using Hospital.MVVM.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.MVVM.ModelView
{
    public class ModelViewDodajProstoriju
    {
        private RoomsController controller = new RoomsController();
        private RoomDTO room = new RoomDTO();
        public RoomDTO Room { get { return room; } set { room = value; } }
        public DataGrid ListaProstorija { get; }
        public ObservableCollection<RoomDTO> Rooms { get; }
        public Frame frame { get; }
        public RelayCommand dodajProstoriju { get; set; }
        public RelayCommand odustani { get; set; }
        public IEnumerable<Purpose> Purpose { get { return Enum.GetValues(typeof(Purpose)).Cast<Purpose>(); } }
        public ModelViewDodajProstoriju(DataGrid listaProstorija, ObservableCollection<RoomDTO> rooms, Frame sobeFrame)
        {
            ListaProstorija = listaProstorija;
            Rooms = rooms;
            frame = sobeFrame;
            dodajProstoriju = new RelayCommand(dodaj);
            odustani = new RelayCommand(odustanak);
        }

        private void dodaj(object obj)
        {
            controller.save(Room);
            ListaProstorija.ItemsSource = controller.getAll();
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }
        private void odustanak(object obj)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }
    }
}
