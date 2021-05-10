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
    /// Interaction logic for KreirajObavestenje.xaml
    /// </summary>
    public partial class KreirajObavestenje : Window
    {
        public DateTime date { get; set; } = DateTime.Now;
        public String person;
        private NotificationsFileStorage storage;
        public ObservableCollection<Notifications> listNotification { get; set; }
        public ObservableCollection<Notifications> myTableUpdate;

        public KreirajObavestenje(ObservableCollection<Notifications> list)
        {
            InitializeComponent();
            storage = new NotificationsFileStorage();
            listNotification = loadNotifications();
            myTableUpdate = list;
        }
        public int generisiId()
        {
            int ret = 0;

            NotificationsFileStorage pfs = new NotificationsFileStorage();
            ObservableCollection<Notifications> all = pfs.GetAll();

            foreach (Notifications nId in all)
            {
                foreach (Notifications n in all)
                {
                    if (ret == n.IdNotification)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }
        public ObservableCollection<Notifications> loadNotifications()
        {
            NotificationsFileStorage nf = new NotificationsFileStorage();
            ObservableCollection<Notifications> n = new ObservableCollection<Notifications>(nf.GetAll());

            return n;

        }
        private void SendBtn(object sender, RoutedEventArgs e)
        {
            if ((bool)upravnikCh.IsChecked)
            {
                person = "Upravnik";
                Notifications notification = new Notifications(title.Text, content.Text, date, generisiId(), person);
                storage.Save(notification);

            }
           else if ((bool)lekarCh.IsChecked)
                {
                person = "Lekar";
                Notifications notification = new Notifications(title.Text, content.Text, date, generisiId(), person);
                storage.Save(notification);
            }
           else if ((bool)pacijentCh.IsChecked) {
                person = "Pacijent";
                Notifications notification = new Notifications(title.Text, content.Text, date, generisiId(), person);
                storage.Save(notification);
            }
           else if ((bool)sekretarCh.IsChecked)
            {
                person = "Sekretar";
                Notifications notification = new Notifications(title.Text, content.Text, date, generisiId(), person);
                storage.Save(notification);
                myTableUpdate.Add(notification);
            }
            else
            {
                MessageBox.Show("Oznacite kome saljete obavestenje");
            }
           
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
