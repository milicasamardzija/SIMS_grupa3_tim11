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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    public partial class ZakazivanjePremestanjaStatickogInventaraUSobu : UserControl
    {
        private ObservableCollection<Inventory> listInventory;
        private Inventory inventory;
        private Frame frame;
        private DateTime date;
        private int idRoom;
        private int quantity;
        private DateTime dateExecution;
        private String time;
        private Room roomOut;
        public ZakazivanjePremestanjaStatickogInventaraUSobu(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, Room room)
        {
            InitializeComponent();
            frame = magacinFrame;
            listInventory = list;
            inventory = selecetedInventory;
            roomOut = room;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        public void doWork()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            TimeSpan t = dateExecution.Subtract(DateTime.Now); //ovo racuna vreme koje je potrebno da nit spava

            if (dateExecution < DateTime.Now) //ovo je slucaj kada je vreme premestanja proslo dok je aplikacija bila iskljucena,
                                              //pa cim se ukljuci dolazi do premestanja
            {
                storage.moveInventoryStatic(inventory, idRoom, roomOut.RoomId, quantity);
            }
            else
            {
                Thread.Sleep(t);
                storage.moveInventoryStatic(inventory, idRoom, roomOut.RoomId, quantity);
            }
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            //argumenti
            if (!IdSobeTxt.Text.Equals(""))
            {
                idRoom = Convert.ToInt32(IdSobeTxt.Text);
            } else
            {
                idRoom = -1;
            }
            quantity = Convert.ToInt32(KolicinaTxt.Text);
            date = (DateTime)DatumTxt.SelectedDate;
            time = VremeTxt.Text;

            //ove dve linije dodaju na datum uneto vreme(datum uzimam preko DatePicker-a a vreme je String)
            TimeSpan t = TimeSpan.ParseExact(time, "c", null); 
            dateExecution = date.Add(t);

            saveNewMovement(); //ovde samo pravim novi objekat klase u kojoj imam sve informacije o premestanju

            Task task = new Task(doWork);
            task.Start();

            frame.NavigationService.Navigate(this);
        }

        private void saveNewMovement()
        {
            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom, roomOut.RoomId, inventory.InventoryId, quantity, dateExecution);
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.Save(newMovement);
        }
    }
}
