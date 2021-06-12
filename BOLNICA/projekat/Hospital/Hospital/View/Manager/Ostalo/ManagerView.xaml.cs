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
using Hospital.View.Manager.Ostalo;
using Hospital.View.Manager.WIzard;
using Hospital.View.Manager.Zaposleni;
using Application = System.Windows.Application;
using HelpProvider = Hospital.View.Manager.Help.HelpProvider;
using MessageBox = System.Windows.MessageBox;
using Hospital.Controller;
using Hospital.Model.Rooms;
using Hospital.Service;

namespace Hospital
{
    public partial class ManagerView : Window
    {
        private DateTime dateExecution;
        private Inventory inventory;
        private int idRoomIn;
        private int idRoomOut;
        private int quantity;
        private ManagerNote notes = new ManagerNote();
        private List<ManagerNote> note = new List<ManagerNote>();
        private MergeRoomController renovationControler = new MergeRoomController();
        private RoomSeparateController renovationSeparateController = new RoomSeparateController();
        private RoomMergeService renovationS = new RoomMergeService();
        public ManagerView()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new ProfilUpravnik(this));
            getTasks();
            //mergeRooms();
            //separateRooms();
            note = notes.GetAll();
            if (note[4].note.Equals("da"))
            {
                Wizard w = new Wizard();
                w.Show();
                note[4].note = "ne";
                notes.SaveAll(note);
            }
           
        }
        private void doMerge(RoomMerge renovation)
        {
            TimeSpan t = renovation.DateEnd.Subtract(DateTime.Now);

            if (renovation.DateBegin < DateTime.Now)
            {
                renovationControler.mergeRooms(renovation);
            }
            else
            {
                Thread.Sleep(t);
                renovationControler.mergeRooms(renovation);
            }
        }
        private void mergeRooms()
        {
            foreach(RoomMerge renovation in renovationS.getAllMergeRenovations())
            {
                Task t = new Task(() => doMerge(renovation));
                t.Start();
            }
        }

        private void doSeparate(RoomSeparate renovation)
        {
            TimeSpan t = renovation.DateEnd.Subtract(DateTime.Now);

            if (renovation.DateBegin < DateTime.Now)
            {
                renovationSeparateController.separateRooms(renovation);
            }
            else
            {
                Thread.Sleep(t);
                renovationSeparateController.separateRooms(renovation);
            }
        }
        private void separateRooms()
        {
            foreach (RoomSeparate renovation in renovationSeparateController.getAll())
            {
                Task t = new Task(() => doSeparate(renovation));
                t.Start();
            }
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

                if(storageInventory.GetAll() != null)
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
            frame.NavigationService.Navigate(new Magacin(frame), ProfilUpravnik.isToolTipVisible);
        }

        private void sobe(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Sobe(frame),ProfilUpravnik.isToolTipVisible);
        }

        private void lekovi(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new LekoviPrikazUpravnik(frame));
        }

        private void obavestenja(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ObavestenjaUpravnik());
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[2]);
           
            if (focusedControl is DependencyObject)
            {
                string str = View.Manager.Help.HelpProvider.GetHelpKey((DependencyObject) focusedControl);
                View.Manager.Help.HelpProvider.ShowHelp(str, this);
            }
        }

        private void zaposleni(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ZaposleniPrikaz());
        }

        private void profil(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new ProfilUpravnik(this));
        }

        private void klinika(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new O_klinici());
        }

        private void odjava(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
