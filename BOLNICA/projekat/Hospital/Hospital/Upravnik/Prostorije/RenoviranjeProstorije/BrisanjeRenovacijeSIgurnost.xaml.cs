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
        private RoomRenovation room;
        private RenovationIFileStorage storage = new RenovationFileStorage("./../../../../Hospital/files/storageRenovationRooms.json");
        private StaticInvnetoryMovementFileStorage storageInventory = new StaticInvnetoryMovementFileStorage();
        private ObservableCollection<RoomRenovation> renovations = new ObservableCollection<RoomRenovation>();
        public BrisanjeRenovacijeSIgurnost(RoomRenovation selectedRoom,ObservableCollection<RoomRenovation> renovation)
        {
            InitializeComponent();
            room = selectedRoom;
            renovations = renovation;
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            foreach (StaticInventoryMovement inventory in storageInventory.GetAll()) {
                if (inventory.RoomInId == room.Id && inventory.RoomOutId == -1 && inventory.Date == room.DateEnd)
                {
                    storageInventory.DeleteByRoomsAndDate(room.Id, -1, room.DateEnd);
                }
            }
            foreach (StaticInventoryMovement inventory in storageInventory.GetAll())
            {
                if (inventory.RoomInId == -1 && inventory.RoomOutId == room.Id && inventory.Date == room.DateBegin)
                {
                    storageInventory.DeleteByRoomsAndDate(-1, room.Id, room.DateBegin);
                }
            }

            storage.DeleteById(room.IdRenovation);
            renovations.Remove(room);
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
