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
        public ObservableCollection<Room> listRoom; //tabela
        public Room room; //soba koja je selektovana u tabeli
        public int index; //index selekovanog reda u tablei
        public IzmeniProstorijuDijalog(ObservableCollection<Room> list,Room selectedRoom,int selectedIndex)
        {
            InitializeComponent();

            //pokusaj da pronadjem tacno sobu koja je selktovana i da sve radim nad njom
            foreach(Room r in list)
            {
                if (r.Equals(selectedRoom))
                {
                    room = r;
                    break;
                }
            }

            listRoom = list;
            index = selectedIndex;

            //ovo se popunjavaju textBox-evi da bi kada se otvori dijalog bilo uneto ono sto se nalazi u tabeli
            brojProstorijeTxt.SelectedText = Convert.ToString(room.RoomId);
            spratTxt.SelectedText = Convert.ToString(room.Floor);
            namenaTxt.SelectedIndex = (int)room.Purpose;
            kapacitetTxt.SelectedText = Convert.ToString(room.Capacity);  
        }

        private void izmenaProstorije(object sender, RoutedEventArgs e)
        {
            RoomFileStorage storage = new RoomFileStorage();

            //menjam sobu
            room.RoomId = Convert.ToInt16(brojProstorijeTxt.Text);
            room.Floor = Convert.ToInt16(spratTxt.Text);
            room.Purpose = (Purpose)namenaTxt.SelectedIndex;
            room.Capacity = Convert.ToInt16(kapacitetTxt.Text);

            listRoom[index] = new Room(Convert.ToInt16(room.RoomId), Convert.ToInt16(room.Floor), false, (Purpose)room.Purpose, Convert.ToInt16(room.Capacity));
          
            storage.DeleteById(Convert.ToInt16(brojProstorijeTxt.Text)); //brisem sobu iz postojece liste u fajlu
            storage.Save(room); //cuvam novu izmenjenu sobu

            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
