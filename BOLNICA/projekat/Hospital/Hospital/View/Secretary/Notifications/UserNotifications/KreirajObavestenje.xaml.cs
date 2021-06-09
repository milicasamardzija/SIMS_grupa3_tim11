using Hospital.Controller;
using Hospital.DTO;
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
    
    public partial class KreirajObavestenje : Window
    {
        public DateTime date { get; set; } = DateTime.Now;
        public String person;
        public NotificationsController controller;
        public ObservableCollection<NotificationsDTO> listNotification { get; set; }
        public ObservableCollection<PatientDTO> listPatients { get; set; }
        public ObservableCollection<NotificationsDTO> myTableUpdate;
        public PatientDTO selectedPatient;
        public PatientController patientController;

        public KreirajObavestenje(ObservableCollection<NotificationsDTO> list)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new NotificationsController();
            patientController = new PatientController();
            listNotification = loadNotifications();
            listPatients = loadAllPatients();
            myTableUpdate = list;
        }
  

        public ObservableCollection<PatientDTO> loadAllPatients()
        {
            ObservableCollection<PatientDTO> ret = new ObservableCollection<PatientDTO>(patientController.loadAllPatients());
            return ret;

        }
        public ObservableCollection<NotificationsDTO> loadNotifications()
        {
            ObservableCollection<NotificationsDTO> notifications = new ObservableCollection<NotificationsDTO>(controller.getAll());
            return notifications;
        }
        private void SendBtn(object sender, RoutedEventArgs e)
        {
            if ((bool)upravnikCh.IsChecked)
            {
                person = "Upravnik";
                NotificationsDTO notification = new NotificationsDTO(title.Text, content.Text, date, 0, person);
                controller.createNotification(notification);

            }
           else if ((bool)lekarCh.IsChecked)
                {
                person = "Lekar";
                NotificationsDTO notification = new NotificationsDTO(title.Text, content.Text, date, 0, person);
                controller.createNotification(notification);
            }
           else if ((bool)pacijentCh.IsChecked) {
                person = "Pacijent";
                NotificationsDTO notification = new NotificationsDTO(title.Text, content.Text, date, 0, person);
                controller.createNotification(notification);
            }
           else if ((bool)sekretarCh.IsChecked)
            {
                person = "Sekretar";
                NotificationsDTO notification = new NotificationsDTO(title.Text, content.Text, date, 0, person);
                controller.createNotification(notification);
                myTableUpdate.Add(notification);
            }else if (pacijenti.SelectedItem != null)
                {
                selectedPatient = (PatientDTO)pacijenti.SelectedItem;
                NotificationsDTO notification = new NotificationsDTO(title.Text, content.Text, date, 0, person = "Pacijent", selectedPatient.Id);
                controller.createNotificationForPatient(notification);
            }

            else
            {
                MessageBox.Show("Oznacite kome saljete obavestenje");
            }
            this.Close();
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(pretraga.Text != "") {pacijenti.ItemsSource = patientController.patientBySurname(pretraga.Text); }
            else
            {
                pacijenti.ItemsSource = patientController.getAll();
            }
            
        }
    }
}
