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
  
    public partial class Blog : Page
    {
        public ObservableCollection<Notifications> listNotifications { get; set; }
        public Blog()
        {
            InitializeComponent();
            this.DataContext = this;
            listNotifications = loadMyNotifications();
            
        }
  
 
      private ObservableCollection<Notifications> loadMyNotifications()
        {
            NotificationsFileStorage nfs = new NotificationsFileStorage();
            ObservableCollection<Notifications> notes = new ObservableCollection<Notifications>(nfs.GetAll());
            return notes;
        }



        private void newNotification(object sender, RoutedEventArgs e)
        {
            KreirajObavestenje obavestenje = new KreirajObavestenje();
            obavestenje.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjaBlog blog = new ObavestenjaBlog();
            blog.Show();
        }
    }
}
