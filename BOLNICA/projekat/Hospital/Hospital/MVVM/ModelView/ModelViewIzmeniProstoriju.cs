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
    public class ModelViewIzmeniProstoriju
    {
        private ObservableCollection<RoomDTO> rooms;
        private int index;
        private Frame frame;
        private RoomsController controller;
        private RoomDTO room = new RoomDTO();
        public RoomDTO Room
        {
            get { return room; }
            set { room = value; }
        }
        public RelayCommand izmeniProstoriju { get; set; }
        public RelayCommand odustani { get; set; }
        public IEnumerable<Purpose> Purpose { get { return Enum.GetValues(typeof(Purpose)).Cast<Purpose>(); } }
        public ModelViewIzmeniProstoriju(ObservableCollection<RoomDTO> rooms, RoomDTO selectedItem, int index, Frame frame)
        {
            this.rooms = rooms;
            this.index = index;
            this.frame = frame;
            this.room = selectedItem;
            this.controller = new RoomsController();
            izmeniProstoriju = new RelayCommand(izmeni);
            odustani = new RelayCommand(odustanak);
        }
        private void izmeni(object obj)
        {
            controller.update(room);
            rooms[index] = room;
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }

        private void odustanak(object obj)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(1));
        }
    }
}
