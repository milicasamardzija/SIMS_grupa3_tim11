using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Manager.Inventar.PremestanjeIzMagacina
{
    public partial class PremestanjeNoveSObe : UserControl
    {
        private ObservableCollection<InventoryDTO> inventories;
        private InventoryDTO inventory;
        private Frame frame;
        private DataGrid tabelaPrikaz;
        private StaticInventoryMovement movement;
        private InventoryController inventoryController = new InventoryController();
        private RoomsController roomController = new RoomsController();
        private StaticInventoryMovementController staticController = new StaticInventoryMovementController();
        public PremestanjeNoveSObe(Frame frame, ObservableCollection<InventoryDTO> inventories, InventoryDTO selecetedInventory, int selectedIndex, DataGrid inventarTabela)
        {
            InitializeComponent();
            this.frame = frame;
            this.inventories = inventories;
            this.inventory = selecetedInventory;
            this.tabelaPrikaz = inventarTabela;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
            addRooms();
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            DatumTxt.BlackoutDates.Add(kalendar);
            potvrdiBtn.IsEnabled = false;
        }
        private void addRooms()
        {
            SobeComboBox.Items.Clear();
            foreach (RoomDTO room in roomController.getNewRooms())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = Convert.ToString(room.Purpose) + " broj " + Convert.ToString(room.Id);
                item.Tag = room.Id;
                SobeComboBox.Items.Add(item);  
            }
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        public void prikaz()
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
            TimeSpan t = TimeSpan.ParseExact(VremeTxt.Text, "c", null);
            DateTime dateExecution = ((DateTime)DatumTxt.SelectedDate).Add(t);
            movement = new StaticInventoryMovement(Convert.ToInt32(((ComboBoxItem)SobeComboBox.SelectedItem).Tag), -1, inventory.Id, Convert.ToInt32(KolicinaTxt.Text), dateExecution);

            if (roomController.isRoomAvailableInventoryMovement(movement))
            {
                staticController.saveNewMovement(movement);
            }
            else
            {
                PremestanjeOdbijeno odbijeno = new PremestanjeOdbijeno();
                odbijeno.Show();
            }
            doWork();

            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void VremeTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!ImeTxt.Text.Equals("") && !KolicinaTxt.Text.Equals("") && SobeComboBox.SelectedIndex != -1 && DatumTxt.SelectedDate != null && !VremeTxt.Text.Equals(""))
            {
                potvrdiBtn.IsEnabled = true;
            }
        }
    }
}
