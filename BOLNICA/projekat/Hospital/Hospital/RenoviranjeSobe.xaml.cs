using Hospital.Controller;
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
    /// <summary>
    /// Interaction logic for RenoviranjeSobe.xaml
    /// </summary>
    public partial class RenoviranjeSobe : UserControl
    {
        private Frame sobeFrame;
        private RoomsController controller;
     
        public RenoviranjeSobe(Frame frame, Room room)
        {
            InitializeComponent();
            sobeFrame = frame;
            controller = new RoomsController();
            brojProstorijeTxt.SelectedText = Convert.ToString(room.RoomId);
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            sobeFrame.NavigationService.Navigate(new BelsekaMagacin()); 
        }

        private void renoviraj(object sender, RoutedEventArgs e)
        {
            RoomRenovation newRenovation = new RoomRenovation(Convert.ToInt32(brojProstorijeTxt.Text),(DateTime)BeginDate.SelectedDate,(DateTime)EndDate.SelectedDate,opisRadova.Text);

            controller.zakaziRenoviranje(newRenovation);

            sobeFrame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
