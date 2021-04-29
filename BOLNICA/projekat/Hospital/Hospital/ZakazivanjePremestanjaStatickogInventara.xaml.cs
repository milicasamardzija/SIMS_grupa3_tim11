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
    /// <summary>
    /// Interaction logic for ZakazivanjePremestanjaStatickogInventara.xaml
    /// </summary>
    /// public Frame frame;
   
    public partial class ZakazivanjePremestanjaStatickogInventara : UserControl
    {
        private ObservableCollection<Inventory> listInventory;
        private int index;
        private Inventory inventory;
        private Frame frame;
        private DateTime date;
        private String time;
        private int idRoom ;
        private int quantity;
        private DateTime dateExecution;

        public ZakazivanjePremestanjaStatickogInventara(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex)
        {
            InitializeComponent();
            frame = magacinFrame;
            listInventory = list;
            index = selectedIndex;
            inventory = selecetedInventory; 
    
            ImeTxt.SelectedText = inventory.Name;
            KolicinaTxt.SelectedText = Convert.ToString(inventory.Quantity);
            TypeTxt.SelectedIndex = (int)inventory.Type;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new BelsekaMagacin());
        }

        private void doMovement()
        {
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            RoomFileStorage roomStorage = new RoomFileStorage();
            RoomInventoryFileStorage roomInventoryStorage = new RoomInventoryFileStorage();

            //ako ne postoji inventar u toj sobi, odnosno pravi se novi RoomInventory objekat
            Boolean nadjen = true;

            //liste
            List<RoomInventory> all = roomInventoryStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

                foreach (RoomInventory roomInv in all)
                {
                        //ako vec postoji zeljeni inventar u unetoj sobi
                        if (roomInv.idInventory == inventory.InventoryId && roomInv.idRoom == idRoom)
                        {
                            roomInv.Quantity += quantity;   //povecava se kolicina inventara u sobi
                            nadjen = false;
                            roomInventoryStorage.SaveAll(all);           //kompletna izmenja lista se serijalizuje
                            break;
                        }
                    
                }

                //ako ne postoji izabrani inventar u unetoj sobi
                if (nadjen)
                {
                    Room room = new Room();
                    Inventory invent = new Inventory();

                    foreach (Room r in roomStorage.GetAll())
                    {
                        if (r.RoomId == idRoom)
                        {
                            room.RoomId = r.RoomId;
                            room.Floor = r.Floor;
                            room.Occupancy = r.Occupancy;
                            room.Purpose = r.Purpose;
                            break;
                        }
                    }

                    foreach (Inventory i in inventoryStorage.GetAll())
                    {
                        if (i.InventoryId == inventory.InventoryId)
                        {
                            invent.InventoryId = i.InventoryId;
                            invent.Name = i.Name;
                            invent.Quantity = i.Quantity;
                            invent.Type = i.Type;
                            break;
                        }
                    }

                    RoomInventory newInventory = new RoomInventory(room.RoomId,room,invent.InventoryId,invent,quantity);
                    roomInventoryStorage.Save(newInventory);
        
                }

                foreach (Inventory i in inventories)
                {
                    if (i.InventoryId == inventory.InventoryId)
                    {
                        i.Quantity -= quantity;
                        inventoryStorage.SaveAll(inventories);
 //                       listInventory[index] = new Inventory(inventory.InventoryId, inventory.Name, i.Quantity, inventory.Type);
                        break;
                    }
                }

            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.DeleteByIds(idRoom,-1,inventory.InventoryId);
        }

        public void doWork()
        {
            TimeSpan t = dateExecution.Subtract(DateTime.Now);
            Thread.Sleep(t);
            doMovement();
        }

        private void premesti(object sender, RoutedEventArgs e)
        {
            //argumenti
            idRoom = Convert.ToInt32(IdSobeTxt.Text);
            quantity = Convert.ToInt32(KolicinaTxt.Text);
            date = (DateTime)DatumTxt.SelectedDate;
            time = VremeTxt.Text;

            TimeSpan t = TimeSpan.ParseExact(time,"c",null);

            dateExecution = date.Add(t); 

            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom,-1,inventory.InventoryId,quantity,dateExecution);
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.Save(newMovement);
            
            Task task = new Task(doWork);
            task.Start();
            frame.NavigationService.Navigate(this);
        }
    }
}
