using Hospital.Controller;
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
        private Inventory inventory;
        private Frame frame;
        private DateTime date;
        private int idRoom ;
        private int quantity;
        private DateTime dateExecution;
        private String time;

        public ZakazivanjePremestanjaStatickogInventara(Frame magacinFrame, ObservableCollection<Inventory> list, Inventory selecetedInventory, int selectedIndex)
        {
            InitializeComponent();
            frame = magacinFrame;
            listInventory = list;
            inventory = selecetedInventory; 
    
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
            TimeSpan t = dateExecution.Subtract(DateTime.Now);

            if (dateExecution < DateTime.Now)
            {
                storage.moveInventory(inventory, idRoom, quantity);
            }
            else
            { 
                Thread.Sleep(t);
                storage.moveInventory(inventory, idRoom, quantity);
            }
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

            saveNewMovement();
            
            Task task = new Task(doWork);
            task.Start();
          
            frame.NavigationService.Navigate(this);
        }

        private void saveNewMovement()
        {
            StaticInventoryMovement newMovement = new StaticInventoryMovement(idRoom, -1, inventory.InventoryId, quantity, dateExecution);
            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.Save(newMovement);
        }
    }
}
