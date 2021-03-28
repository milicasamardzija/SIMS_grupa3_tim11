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
    /// Interaction logic for IzmeniTermin.xaml
    /// </summary>
    public partial class IzmeniTermin : Window
    {
        public ObservableCollection<Room> appointmentList;
        public IzmeniTermin(/*ObservableCollection<Appointment> list, Appointment selectedRoom*/)
        {
            InitializeComponent();
           /* appointmentList = list;
            brojProstorijeTxt.SelectedText = Convert.ToString(selectedRoom.roomId);
            spratTxt.SelectedText = Convert.ToString(selectedRoom.floor);
            namenaTxt.SelectedIndex = (int)selectedRoom.purpose;
            kapacitetTxt.SelectedText = Convert.ToString(selectedRoom.capacity);*/
        }

        private void add_appointment(object sender, RoutedEventArgs e)
        {

        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
