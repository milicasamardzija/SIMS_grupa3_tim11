using Hospital.Controller;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
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
    public partial class BrisanjeRenovacijeSIgurnost : Window
    {
        private RoomRenovationDTO renovation;
        private ObservableCollection<RoomRenovationDTO> renovations;
        private RoomRenovationController controller;
        public BrisanjeRenovacijeSIgurnost(RoomRenovationDTO renovation, ObservableCollection<RoomRenovationDTO> renovations)
        {
            InitializeComponent();
            this.renovation = renovation;
            this.renovations = renovations;
            this.controller = new RoomRenovationController();
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            controller.deleteRenovation(renovation);
            renovations.Remove(renovation);
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
