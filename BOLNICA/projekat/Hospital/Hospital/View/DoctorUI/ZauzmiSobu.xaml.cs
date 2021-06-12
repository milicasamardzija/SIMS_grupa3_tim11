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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for ZauzmiSobu.xaml
    /// </summary>
    public partial class ZauzmiSobu : Window
    {
        private ObservableCollection<RoomDTO> LookInRooms = new ObservableCollection<RoomDTO>();
        private RoomDTO room = new RoomDTO();
        public RoomDTO Room
        {
            get { return room; }
            set { room = value; }
        }
        private int indexRoom;
        public int maxValue = 10;

        public ZauzmiSobu(ObservableCollection<RoomDTO> list, RoomDTO selectedRoom, int selectedIndex)
        {
            InitializeComponent();
            LookInRooms = list;
            room = selectedRoom;
            indexRoom = selectedIndex;
            spratText.SelectedText = Convert.ToString(room.Floor);
            vrstaText.SelectedText = Convert.ToString(room.Purpose);
            kapacitetText.SelectedText = Convert.ToString(room.Capacity);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            room.Capacity = room.Capacity + 1;
            if(room.Capacity == maxValue)
            {
                MessageBox.Show("Soba je zauzeta!");
            }
            LookInRooms[indexRoom] = room;
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
