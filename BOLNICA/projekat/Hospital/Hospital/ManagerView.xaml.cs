using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ObservableCollection<Room> RoomList
        {
            get;
            set;
        }
        private DateTime dateExecution;
        private Inventory inventory;
        private int idRoomIn;
        private int idRoomOut;
        private int quantity;
        public ManagerView()
        {
            InitializeComponent();
            RoomList = loadJason();
            frame.NavigationService.Navigate(new Magacin(RoomList));
            getTasks();
        }

      private void getTasks()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            InventoryFileStorage storageInventory = new InventoryFileStorage();

            foreach (StaticInventoryMovement task in storage.GetAll())
            {
                dateExecution = task.Date;
                idRoomIn = task.RoomInId;
                idRoomOut = task.RoomOutId;
                quantity = task.Quantity;

                foreach (Inventory i in storageInventory.GetAll())
                {
                    if (i.InventoryId == task.InventoryId)
                    {
                        inventory = i;
                        break;
                    }
                }

                Task t = new Task(doWork);
                t.Start();
            }

        }

        private void doWork()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            TimeSpan t = dateExecution.Subtract(DateTime.Now);
            
            if (dateExecution < DateTime.Now)
            {
                storage.moveInventoryStatic(inventory, idRoomIn, idRoomOut, quantity);
            }
            else
            {
                Thread.Sleep(t);
                storage.moveInventoryStatic(inventory, idRoomIn, idRoomOut, quantity);
            }

        }

        private void magacin(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Magacin(RoomList));
        }

        private void sobe(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Sobe(RoomList,frame));
        }

        public ObservableCollection<Room> loadJason()
        {
            RoomFileStorage fs = new RoomFileStorage();
            ObservableCollection<Room> rs = new ObservableCollection<Room>(fs.GetAll());
            return rs;
        }
    }
}
