using Hospital.FileStorage.Interfaces;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application = System.Windows.Application;
using HelpProvider = Hospital.View.Manager.Help.HelpProvider;
using MessageBox = System.Windows.MessageBox;

namespace Hospital
{
    public partial class ManagerView : Window
    {
        private DateTime dateExecution;
        private Inventory inventory;
        private int idRoomIn;
        private int idRoomOut;
        private int quantity;
        public static Boolean isToolTipVisible = true;
        public ManagerView()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new Magacin(frame));
            getTasks();
        }

      private void getTasks()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            InventoryFileStorage storageInventory = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");

            foreach (StaticInventoryMovement task in storage.GetAll())
            {
                dateExecution = task.Date;
                idRoomIn = task.RoomInId;
                idRoomOut = task.RoomOutId;
                quantity = task.Quantity;

                foreach (Inventory i in storageInventory.GetAll())
                {
                    if (i.Id == task.InventoryId)
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
            frame.NavigationService.Navigate(new Magacin(frame),isToolTipVisible);
        }

        private void sobe(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Sobe(frame),isToolTipVisible);
        }

        private void lekovi(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void obavestenja(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ObavestenjaUpravnik());
        }

        private void ukljuci(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rsltMessageBox = MessageBox.Show("Are you sure you want to disable tooltips?", "Tooltips",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    isToolTipVisible = true;
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void iskljuci(object sender, RoutedEventArgs e)
        {
            isToolTipVisible = false;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[2]);
            MessageBox.Show("Ovde sam" +
                            "");
            if (focusedControl is DependencyObject)
            {
                MessageBox.Show("Boze pomozi");
                string str = View.Manager.Help.HelpProvider.GetHelpKey((DependencyObject) focusedControl);
                MessageBox.Show(str);
                View.Manager.Help.HelpProvider.ShowHelp(str, this);
            }
        }
    }
}
