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
        private ManagerNote notes = new ManagerNote();
        private StaticInventoryMovement movement = new StaticInventoryMovement();
        private List<ManagerNote> note = new List<ManagerNote>();
        private MergeRoomController renovationControler = new MergeRoomController();
        private RoomSeparateController renovationSeparateController = new RoomSeparateController();
        private RoomMergeService renovationS = new RoomMergeService();
        private StaticInventoryMovementController movementController = new StaticInventoryMovementController();
        private InventoryController inventoryController = new InventoryController();
        public ManagerView()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new ProfilUpravnik(this,frame));
            getTasks();
            mergeRooms();
            separateRooms();
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
            if (renovation.DateBegin < DateTime.Now)
            {
                renovationControler.mergeRooms(renovation);
            }
            else
            {
                Thread.Sleep(renovation.DateEnd.Subtract(DateTime.Now));
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
            if (renovation.DateEnd < DateTime.Now)
            {
                renovationSeparateController.separateRooms(renovation);
            }
            else
            {
                Thread.Sleep(renovation.DateEnd.Subtract(DateTime.Now));
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
            foreach (StaticInventoryMovement task in movementController.getAll())
            {
                movement = task;
                Task t = new Task(doWork);
                t.Start();
            }
        }

        private void doWork()
        {
            if (dateExecution < DateTime.Now)
            {
                movementController.moveInventoryStatic(movement);
            }
            else
            {
                Thread.Sleep(dateExecution.Subtract(DateTime.Now));
                movementController.moveInventoryStatic(movement);
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
            frame.NavigationService.Navigate(new ObavestenjaUpravnik(new MVVM.ModelView.ModelViewObavestenja()));
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
            frame.NavigationService.Navigate(new ProfilUpravnik(this,frame));
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
