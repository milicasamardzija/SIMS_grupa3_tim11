using Hospital.DTO;
using Hospital.View.Manager.Inventar.PremestanjeIzMagacina;
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

namespace Hospital
{
    public partial class PremestanjeInventara : UserControl
    {
        private Frame frame;
        private ObservableCollection<InventoryDTO> inventories;
        private int index;
        private int idInventory;
        private InventoryDTO inventory;
        private DataGrid inventarTabela;
        private Boolean magacin;
        private RoomDTO roomOut;
        private DataGrid tableInventara;
        public PremestanjeInventara(Frame magacinFrame, ObservableCollection<InventoryDTO> inventories, DataGrid listaInventara,Boolean IzMagacina,RoomDTO outRoom, DataGrid listaInventara1)
        {
            InitializeComponent();
            this.frame = magacinFrame;
            this.inventories = inventories;
            this.inventarTabela = listaInventara;
            this. magacin = IzMagacina;
            this.roomOut = outRoom;
            this.tableInventara = listaInventara1;
        }

        private void premestiMomentalno(object sender, RoutedEventArgs e)
        {
            if (magacin)
            {
                frame.NavigationService.Navigate(new PremestiInventarUSobu(frame, inventories, (InventoryDTO)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,inventarTabela));
            }
            else
            {
                frame.NavigationService.Navigate(new PremestanjeInventaraDijalog(frame, inventories, (InventoryDTO)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,roomOut,inventarTabela));
            }
            
        }

        private void zakaziPremestanje(object sender, RoutedEventArgs e)
        {
            if (magacin)
            {
                frame.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventara(frame, inventories, (InventoryDTO)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,inventarTabela));
            } else
            {
                frame.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventaraUSobu(frame, inventories, (InventoryDTO)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,roomOut, inventarTabela));
            }
        }

        private void premestanje(object sender, RoutedEventArgs e)
        {
            if (magacin)
            {
                frame.NavigationService.Navigate(new PremestanjeNoveSObe(frame, inventories, (InventoryDTO)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,inventarTabela));
            } else
            {
                frame.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventaraUSobu(frame, inventories, (InventoryDTO)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,roomOut, inventarTabela));
            }
        }
    }
}
