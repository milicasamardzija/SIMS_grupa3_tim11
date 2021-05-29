using Hospital.Controller;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
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
    public partial class RenoviranjeSobe : UserControl
    {
        private Frame sobeFrame;
        private RoomsController controller;
     
        public RenoviranjeSobe(Frame frame, Room room)
        {
            InitializeComponent();
            sobeFrame = frame;
            controller = new RoomsController();
            brojProstorijeTxt.SelectedText = Convert.ToString(room.Id);
        }

        public int generisiId()
        {
            int ret = 0;

            RenovationIFileStorage storage = new RenovationFileStorage("./../../../../Hospital/files/storageRenovationRooms.json");
            List<RoomRenovation> allRooms = storage.GetAll();

            foreach (RoomRenovation roomBig in allRooms)
            {
                foreach (RoomRenovation room in allRooms)
                {
                    if (ret == room.IdRenovation)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            sobeFrame.NavigationService.Navigate(new BelsekaMagacin()); 
        }

        private void renoviraj(object sender, RoutedEventArgs e)
        {
            RoomRenovation newRenovation = new RoomRenovation(generisiId(),Convert.ToInt32(brojProstorijeTxt.Text),(DateTime)BeginDate.SelectedDate,(DateTime)EndDate.SelectedDate,opisRadova.Text);

            controller.zakaziRenoviranje(newRenovation);

            sobeFrame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
