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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for BolnickoLecenje.xaml
    /// </summary>
    public partial class BolnickoLecenje : Window
    {
        public ObservableCollection<RoomDTO> LookInRooms { get; set; }
        private RoomsController roomsController = new RoomsController();
        public RoomDTO rooms;

        public BolnickoLecenje()
        {
            InitializeComponent();
            this.DataContext = this;
            LookInRooms = new ObservableCollection<RoomDTO>(roomsController.getAll());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ZauzmiSobu takeRoom = new ZauzmiSobu(LookInRooms, (RoomDTO)listRooms.SelectedItem, listRooms.SelectedIndex);
            takeRoom.Show();
        }
    }
}
