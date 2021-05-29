using Hospital.Controller;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class PrikazSobaRenoviranje : UserControl
    {
        public ObservableCollection<RoomRenovationDTO> Renovations
        {
            get;
            set;
        }
        private Frame frame;
        private RoomRenovationController controller;
        public PrikazSobaRenoviranje(Frame frame)
        {
            InitializeComponent();
            this.controller = new RoomRenovationController();
            Renovations = new ObservableCollection<RoomRenovationDTO>(controller.getAll());
            this.DataContext = this;
            this.frame = frame;
        }
     
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            BrisanjeRenovacijeSIgurnost brisanje = new BrisanjeRenovacijeSIgurnost((RoomRenovationDTO)ProstorijeRenoviranje.SelectedItem, Renovations);
            brisanje.Show();
        }

        private void unazad(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Sobe(frame));
        }
    }
}
