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
using Hospital.DTO;

namespace Hospital.View.Manager.Prostorije.RenoviranjeProstorije
{
    public partial class Renoviranje : UserControl
    {
        private Frame frame;
        private RoomDTO room;
        public Renoviranje(Frame frame, RoomDTO room)
        {
            InitializeComponent();
            this.frame = frame;
            this.room = room;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TipRenoviranjaComboBox.SelectedIndex == 0) //obicno
            {
                RenoviranjeFrame.NavigationService.Navigate(new RenoviranjeSobe(frame, room));
            } else if (TipRenoviranjaComboBox.SelectedIndex == 1) //spajanje
            {
                RenoviranjeFrame.NavigationService.Navigate(new RenoviranjeSpajanje(frame, room));
            }
            else if (TipRenoviranjaComboBox.SelectedIndex == 2)//razdvajanje
            {
                RenoviranjeFrame.NavigationService.Navigate(new RenoviranjeRazdvajanje(frame, room));
            }
        }
    }
}
