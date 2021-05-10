using Hospital.Model;
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

namespace Hospital.Sekretar
{
    /// <summary>
    /// Interaction logic for ObrisiObavestenje.xaml
    /// </summary>
    public partial class ObrisiObavestenje : Window
    {
       public ObservableCollection<Notifications> listN { get; set; }
        public Notifications delete;
        public int index;
        public int id;
        public ObrisiObavestenje(ObservableCollection<Notifications> list, Notifications notification, int sel)
        {
            InitializeComponent();
            listN = list;
            index = sel;
            delete = notification;
          
        }

        private void Yes(object sender, RoutedEventArgs e)
        {
            NotificationsFileStorage nfs = new NotificationsFileStorage();
            nfs.Delete(delete);
            listN.RemoveAt(index);
            this.Close();
        }
        public void No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
