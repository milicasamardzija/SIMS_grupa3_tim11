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
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital.View.Manager.Inventar.CRUDInventar
{
    public partial class BrisanjePotvrdiInventar : Window
    {
        private int id;
        private ObservableCollection<Inventory> inventories;
        private int index;
        private InventoryController controller;

        public BrisanjePotvrdiInventar(int id, System.Collections.ObjectModel.ObservableCollection<Inventory> inventories,int index)
        {
            InitializeComponent();
            this.id = id;
            this.inventories = inventories;
            this.index = index;
            this.controller = new InventoryController();
        }

        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            controller.delete(id);
            inventories.RemoveAt(index);
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
