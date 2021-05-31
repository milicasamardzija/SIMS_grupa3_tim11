using Hospital.DTO;
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

namespace Hospital.View.Manager.Prostorije.RenoviranjeProstorije
{
    public partial class RenoviranjeRazdvajanje : UserControl
    {
        private Frame frame;
        private RoomDTO room;
        public RenoviranjeRazdvajanje(Frame frame, DTO.RoomDTO room)
        {
            InitializeComponent();
            this.frame = frame;
            this.room = room;
        }

        private void renoviraj(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
