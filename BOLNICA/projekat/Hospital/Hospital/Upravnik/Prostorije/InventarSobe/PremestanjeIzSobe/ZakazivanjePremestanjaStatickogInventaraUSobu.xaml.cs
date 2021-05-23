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
        private DataGrid tabelaPrikaz;
        private RoomsService serviceRoom = new RoomsService();
        public ZakazivanjePremestanjaStatickogInventaraUSobu(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex, Room room, DataGrid inventarTabela)
        {
            InitializeComponent();
            frame = magacinFrame;
            listInventory = list;
            inventory = selecetedInventory;
            roomOut = room;
            tabelaPrikaz = inventarTabela;

            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void prikaz()
        {
            tabelaPrikaz.ItemsSource = loadJason();
        }

        public ObservableCollection<Inventory> loadJason()
        {
            RoomInventoryFileStorage storage = new RoomInventoryFileStorage();
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();

            ObservableCollection<Inventory> ret = new ObservableCollection<Inventory>();

            foreach (RoomInventory r in storage.GetAll())
            {
                if (r.IdRoom.Equals(roomOut.Id))
                {
                    Inventory i = inventoryStorage.FindById(r.IdInventory);
                    if (i != null)
                        ret.Add(new Inventory(i.InventoryId, i.Name, r.Quantity, i.Type));
                    else
                        break;
                }

            }

            return ret;
        }

        public async Task doWork()
        {
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            TimeSpan t = dateExecution.Subtract(DateTime.Now); //ovo racuna vreme koje je potrebno da nit spava

            if (dateExecution < DateTime.Now) //ovo je slucaj kada je vreme premestanja proslo dok je aplikacija bila iskljucena,
                                              //pa cim se ukljuci dolazi do premestanja
            {
                storage.moveInventoryStatic(inventory, idRoom, roomOut.Id, quantity);
                prikaz();
            }
            else
            {
                await Task.Delay(t);
                storage.moveInventoryStatic(inventory, idRoom, roomOut.Id, quantity);
                prikaz();
            }
        }

        private async void premesti(object sender, RoutedEventArgs e)
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

            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom, roomOut.Id, inventory.InventoryId, quantity, dateExecution);

            if (serviceRoom.isRoomAvailableInventoryMovement(newMovement))
            {
                saveNewMovement();
            } else
            {
                PremestanjeOdbijeno odbijeno = new PremestanjeOdbijeno();
                odbijeno.Show();
            }

            doWork();

            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void saveNewMovement()
        {
            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom, roomOut.Id, inventory.InventoryId, quantity, dateExecution);
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.Save(newMovement);
        }

    }
}
