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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmeniProstoriju.xaml
    /// </summary>
    public partial class IzmeniProstoriju : UserControl
    {
        public ObservableCollection<Room> listRoom; //tabela
        public Room room; //soba koja je selektovana u tabeli
        public int index; //index selekovanog reda u tablei
        public Frame frame;
        public IzmeniProstoriju(ObservableCollection<Room> list, Room selectedRoom, int selectedIndex, Frame f)
        {
            InitializeComponent();

            listRoom = list;
            index = selectedIndex;
            room = selectedRoom;
            frame = f;

            //ovo se popunjavaju textBox-evi da bi kada se otvori dijalog bilo uneto ono sto se nalazi u tabeli
            brojProstorijeTxt.SelectedText = Convert.ToString(room.RoomId);
            spratTxt.SelectedText = Convert.ToString(room.Floor);
            namenaTxt.SelectedIndex = (int)room.Purpose;
            kapacitetTxt.SelectedText = Convert.ToString(room.Capacity);
        }

        private void izmenaProstorije(object sender, RoutedEventArgs e)
        {
            RoomFileStorage storage = new RoomFileStorage();
            List<Room> allRooms = storage.GetAll();

            int id = Convert.ToInt16(brojProstorijeTxt.Text);

            foreach (Room r in allRooms)
            {
                if (r.RoomId == id)
                {
                    //menjam sobu
                    r.RoomId = Convert.ToInt16(brojProstorijeTxt.Text);
                    r.Floor = Convert.ToInt16(spratTxt.Text);
                    r.Purpose = (Purpose)namenaTxt.SelectedIndex;
                    r.Capacity = Convert.ToInt16(kapacitetTxt.Text);
                    listRoom[index] = new Room(Convert.ToInt16(r.RoomId), Convert.ToInt16(r.Floor), false, (Purpose)r.Purpose, Convert.ToInt16(r.Capacity));
                    break;
                }
            }

            storage.SaveAll(allRooms); //cuvam novu izmenjenu sobu
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
