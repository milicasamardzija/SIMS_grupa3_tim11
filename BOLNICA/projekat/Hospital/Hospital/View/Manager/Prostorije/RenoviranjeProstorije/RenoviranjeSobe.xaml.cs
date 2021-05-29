﻿using Hospital.Controller;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
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

namespace Hospital
{
    public partial class RenoviranjeSobe : UserControl
    {
        private Frame frame;
        private RoomsController controller;
        private RoomRenovationDTO roomRenovation = new RoomRenovationDTO();
        private RoomDTO room;
        public RoomRenovationDTO RoomRenovation
        {
            get { return roomRenovation; }
            set { roomRenovation = value; }
        }
        public RenoviranjeSobe(Frame frame, RoomDTO room)
        {
            InitializeComponent();
            this.DataContext = this;
            this.frame = frame;
            this.room = room;
            controller = new RoomsController();
            brojProstorijeTxt.SelectedText = Convert.ToString(room.Id);
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin()); 
        }

        private void renoviraj(object sender, RoutedEventArgs e)
        {
            RoomRenovation.IdRoom = room.Id;
            controller.scheduleRenovation(RoomRenovation);
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }
    }
}
