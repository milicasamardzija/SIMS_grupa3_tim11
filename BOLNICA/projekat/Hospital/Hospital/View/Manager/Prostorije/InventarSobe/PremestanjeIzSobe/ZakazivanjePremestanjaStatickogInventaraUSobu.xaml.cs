using Hospital.Model;
using Hospital.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;
using Hospital.Controller;

namespace Hospital
{
    public partial class ZakazivanjePremestanjaStatickogInventaraUSobu : UserControl
    {
        private ObservableCollection<InventoryDTO> inventories;
        private InventoryDTO inventory;
        private Frame frame;
        private RoomDTO roomOut;
        private DataGrid tabelaPrikaz;
        private StaticInventoryMovement movement;
        private RoomsController roomController = new RoomsController();
        private InventoryController inventoryController = new InventoryController();
        private StaticInventoryMovementController staticController = new StaticInventoryMovementController();
        public ZakazivanjePremestanjaStatickogInventaraUSobu(Frame frame, ObservableCollection<InventoryDTO> inventories, InventoryDTO inventory, int selectedIndex, RoomDTO room, DataGrid inventarTabela)
        {
            InitializeComponent();
            this.frame = frame;
            this.inventories = inventories;
            this.inventory = inventory;
            this.roomOut = room;
            this.tabelaPrikaz = inventarTabela;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            DatumTxt.BlackoutDates.Add(kalendar);
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void prikaz()
        {
            tabelaPrikaz.ItemsSource = inventoryController.getAll();
        }

        public async Task doWork()
        {
            TimeSpan t = movement.Date.Subtract(DateTime.Now);

            if (movement.Date < DateTime.Now) 
            {
                staticController.moveInventoryStatic(movement);
                prikaz();
            }
            else
            {
                await Task.Delay(t);
                staticController.moveInventoryStatic(movement);
                prikaz();
            }
        }

        private async void premesti(object sender, RoutedEventArgs e)
        {
            int idRoom;
  
            if (!IdSobeTxt.Text.Equals(""))
            {
                idRoom = Convert.ToInt32(IdSobeTxt.Text);
            } else
            {
                idRoom = -1;
            }
  
            TimeSpan t = TimeSpan.ParseExact(VremeTxt.Text, "c", null);
            DateTime dateExecution = ((DateTime)DatumTxt.SelectedDate).Add(t);
            movement = new StaticInventoryMovement(idRoom, roomOut.Id, inventory.Id, Convert.ToInt32(KolicinaTxt.Text), dateExecution);

            if (roomController.isRoomAvailableInventoryMovement(movement))
            {
                staticController.saveNewMovement(movement);
            } else
            {
                PremestanjeOdbijeno odbijeno = new PremestanjeOdbijeno();
                odbijeno.Show();
            }

            doWork();
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }
    }
}
