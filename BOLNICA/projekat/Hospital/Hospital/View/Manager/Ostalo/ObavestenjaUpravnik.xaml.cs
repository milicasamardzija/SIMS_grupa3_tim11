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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    public partial class ObavestenjaUpravnik : UserControl
    {
        private NotificationsFileStorage storage = new NotificationsFileStorage("./../../../../Hospital/files/notifications.json");
        public ObavestenjaUpravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            Obavestenja.ItemsSource = storage.FindByPerson("Upravnik");
        }
    }
}
