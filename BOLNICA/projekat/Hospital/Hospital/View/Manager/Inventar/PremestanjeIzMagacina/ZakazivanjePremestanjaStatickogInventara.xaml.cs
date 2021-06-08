using Hospital.Controller;
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
using Hospital.DTO;

namespace Hospital
{
    public partial class ZakazivanjePremestanjaStatickogInventara : UserControl
    {
        private ObservableCollection<Inventory> listInventory;
        private Inventory inventory;
        private Frame frame;
        private DateTime date;
        private int idRoom ;
        private int quantity;
        private DateTime dateExecution;
        private String time;
        private DataGrid tabelaPrikaz;
        private RoomsService serviceRoom = new RoomsService();
        private RoomsController roomController = new RoomsController();
        public ZakazivanjePremestanjaStatickogInventara(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, DataGrid inventarTabela)
        {
            InitializeComponent();
            frame = magacinFrame;
            listInventory = list;
            inventory = selecetedInventory;
            tabelaPrikaz = inventarTabela;
    
            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
            addRooms();
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            DatumTxt.BlackoutDates.Add(kalendar);
        }
        private void addRooms()
        {
            SobeComboBox.Items.Clear();
            foreach (RoomDTO room in roomController.getAll())
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
            tabelaPrikaz.ItemsSource = loadJason();
         }

        public async Task doWork()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            TimeSpan t = dateExecution.Subtract(DateTime.Now);

            if (dateExecution < DateTime.Now)
            {
                storage.moveInventoryStatic(inventory, idRoom,-1, quantity);
                prikaz();
            }
            else
            {
                await Task.Delay(t);
                storage.moveInventoryStatic(inventory, idRoom, -1, quantity);
                prikaz();
            }
        }


        private async void premesti(object sender, RoutedEventArgs e)
        {
            //argumenti
            idRoom = Convert.ToInt32(((ComboBoxItem)SobeComboBox.SelectedItem).Tag);
            quantity = Convert.ToInt32(KolicinaTxt.Text);
            date = (DateTime)DatumTxt.SelectedDate;
            time = VremeTxt.Text;

            TimeSpan t = TimeSpan.ParseExact(time,"c",null);
            dateExecution = date.Add(t);

            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom, -1, inventory.Id, quantity, dateExecution);

            if (serviceRoom.isRoomAvailableInventoryMovement(newMovement))
            {
                saveNewMovement();
            }
            else
            {
                PremestanjeOdbijeno odbijeno = new PremestanjeOdbijeno();
                odbijeno.Show();
            }

            doWork();

            frame.NavigationService.Navigate(new BelsekaMagacin(0));
        }

        private void saveNewMovement()
        {
            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom, -1, inventory.Id, quantity, dateExecution);
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.Save(newMovement);
        }

        public ObservableCollection<Inventory> loadJason()
        {
            InventoryFileStorage storage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>(storage.GetAll());
            return ret;
        }
    }
}
