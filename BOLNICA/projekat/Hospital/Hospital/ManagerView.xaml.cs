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
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ObservableCollection<Room> RoomList
        {
            get;
            set;
        }
        public ManagerView()
        {
            InitializeComponent();
            RoomList = loadJason();
            frame.NavigationService.Navigate(new Magacin(RoomList));
        }

        private void magacin(object sender, RoutedEventArgs e)
        {

            frame.NavigationService.Navigate(new Magacin(RoomList));
        }

        private void sobe(object sender, RoutedEventArgs e)
        {
            Rooms r = new Rooms(RoomList);
            r.Show();
        }

        public ObservableCollection<Room> loadJason()
        {
            RoomFileStorage fs = new RoomFileStorage();
            ObservableCollection<Room> rs = new ObservableCollection<Room>(fs.GetAll());
            return rs;
        }
    }
}
