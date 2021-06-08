using Hospital.Controller;
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
   
    public partial class SlobodniLekari : Window
    {
        public List<Doctor> listDoctors { get; set; }
        public Checkup checkup;
        public CheckupController controller;
        public int idRoom;
        public DateTime newDate;
        
        public SlobodniLekari(DateTime date, int idR, Checkup old)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new CheckupController();
            checkup = old;
            idRoom = idR;
            listDoctors = getAvailableDoctors(date);
            newDate = date;
           
        }

        public List<Doctor> getAvailableDoctors(DateTime date)
        {
            return controller.availableDoctors(date);
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            controller.changeCheckup(new Checkup(0, checkup.IdDoctor, checkup.IdPatient, newDate, idRoom, 0));
            this.Close();
        }
        private void Decline(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
