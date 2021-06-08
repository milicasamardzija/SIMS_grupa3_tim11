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
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for UvidUSobe.xaml
    /// </summary>
    public partial class UvidUSobe : Window
    {
        public ObservableCollection<RoomDTO> RoomsLook { get; set; }
        private RoomsController roomsController = new RoomsController();

        public UvidUSobe()
        {
            InitializeComponent();
            this.DataContext = this;
            RoomsLook = new ObservableCollection<RoomDTO>(roomsController.getAll());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
