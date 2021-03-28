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
    /// Interaction logic for IzmeniProstorijuDijalog.xaml
    /// </summary>
    public partial class IzmeniProstorijuDijalog : Window
    {
        public ObservableCollection<Room> listRoom;
        public Room room;
        public int index;
        public IzmeniProstorijuDijalog(ObservableCollection<Room> list,Room selectedRoom,int selectedIndex)
        {
            InitializeComponent();

            listRoom = list;
            room = selectedRoom;
            index = selectedIndex;

            brojProstorijeTxt.SelectedText = Convert.ToString(selectedRoom.roomId);
            spratTxt.SelectedText = Convert.ToString(selectedRoom.floor);
            namenaTxt.SelectedIndex = (int)selectedRoom.purpose;
            kapacitetTxt.SelectedText = Convert.ToString(selectedRoom.capacity);  
        }

        private void izmenaProstorije(object sender, RoutedEventArgs e)
        {
            RoomFileStorage storage = new RoomFileStorage();

            room.roomId = Convert.ToInt16(brojProstorijeTxt.Text);
            room.floor = Convert.ToInt16(spratTxt.Text);
            room.purpose = (Purpose)namenaTxt.SelectedIndex;
            room.capacity = Convert.ToInt16(kapacitetTxt.Text);

            storage.DeleteById(Convert.ToInt16(brojProstorijeTxt.Text));
            storage.Save(room);

            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
