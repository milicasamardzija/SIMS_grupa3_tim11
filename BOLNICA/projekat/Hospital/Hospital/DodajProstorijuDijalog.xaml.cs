﻿using System;
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
    /// Interaction logic for DodajProstorijuDijalog.xaml
    /// </summary>
    public partial class DodajProstorijuDijalog : Window
    {
        public ObservableCollection<Room> listRoom;

        public DodajProstorijuDijalog(ObservableCollection<Room> list)
        {
            InitializeComponent();
            listRoom = list;
        }

        public int generisiId()
        {
            int ret = 0;

            RoomFileStorage storage = new RoomFileStorage();
            List<Room> allRooms = storage.GetAll();

            foreach (Room roomBig in allRooms) {
                foreach (Room room in allRooms)
                {
                    if (ret == room.roomId)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void dodavanjeProstorije(object sender, RoutedEventArgs e)
        {
            RoomFileStorage storage = new RoomFileStorage();

            Room newRoom = new Room(generisiId(), Convert.ToInt16(SpratText.Text), false, (Purpose)NamenaText.SelectedIndex, Convert.ToInt16(KapacitetText.Text));

            storage.Save(newRoom);
            listRoom.Add(newRoom);

            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
