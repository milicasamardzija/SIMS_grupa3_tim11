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
    /// <summary>
    /// Interaction logic for PremestanjeInventara.xaml
    /// </summary>
    public partial class PremestanjeInventara : UserControl
    {
        public Frame frame;
        public ObservableCollection<Inventory> listInventory;
        public int index;
        public int idInventory;
        public Inventory inventory;
        private DataGrid inventarTabela;
        private Boolean magacin;
        private Room roomOut;
        public PremestanjeInventara(Frame magacinFrame, ObservableCollection<Inventory> list, DataGrid listaInventara,Boolean IzMagacina,Room outRoom)
        {
            InitializeComponent();
            frame = magacinFrame;
            listInventory = list;
            inventarTabela = listaInventara;
            magacin = IzMagacina;
            roomOut = outRoom;
        }

        private void premestiMomentalno(object sender, RoutedEventArgs e)
        {
            if (magacin)
            {
                frame.NavigationService.Navigate(new PremestiInventarUSobu(frame, listInventory, (Inventory)inventarTabela.SelectedItem, inventarTabela.SelectedIndex));
            }
            else
            {
                frame.NavigationService.Navigate(new PremestanjeInventaraDijalog(frame, listInventory, (Inventory)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,roomOut));
            }
        }

        private void zakaziPremestanje(object sender, RoutedEventArgs e)
        {
            if (magacin)
            {
                frame.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventara(frame, listInventory, (Inventory)inventarTabela.SelectedItem, inventarTabela.SelectedIndex));
            } else
            {
                frame.NavigationService.Navigate(new ZakazivanjePremestanjaStatickogInventaraUSobu(frame, listInventory, (Inventory)inventarTabela.SelectedItem, inventarTabela.SelectedIndex,roomOut));
            }
        }
    }
}
