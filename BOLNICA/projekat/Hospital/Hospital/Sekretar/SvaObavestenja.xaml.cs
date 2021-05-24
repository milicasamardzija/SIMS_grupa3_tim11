using Hospital.Model;
using Hospital.Sekretar;
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
  
    public partial class SvaObavestenja : Page
    {
        public ObservableCollection<Notifications> listNotification { get; set; }
        public SvaObavestenja()
        {
            InitializeComponent();
            this.DataContext = this;
            listNotification = loadMyNotifications("Sekretar");
          
        }
  
 
      private ObservableCollection<Notifications> loadMyNotifications(String person)
        {
            NotificationsFileStorage nfs = new NotificationsFileStorage("./../../../../Hospital/files/notifications.json");
            ObservableCollection<Notifications> notes = new ObservableCollection<Notifications>(nfs.FindByPerson(person));
            return notes;
        }



        private void newNotification(object sender, RoutedEventArgs e)
        {
            KreirajObavestenje obavestenje = new KreirajObavestenje(listNotification);
            obavestenje.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaBlog blog = new ObavestenjaBlog();
            blog.Show();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (mojaObavestenja.SelectedIndex != -1)
            {
                ObrisiObavestenje nepotrebno = new ObrisiObavestenje(listNotification, (Notifications)mojaObavestenja.SelectedItem, mojaObavestenja.SelectedIndex);
                nepotrebno.Show();
            } else
            {
                MessageBox.Show("Niste izabrali obavestenje koje je potrebno obrisati!");
            }

        }
    }
}
