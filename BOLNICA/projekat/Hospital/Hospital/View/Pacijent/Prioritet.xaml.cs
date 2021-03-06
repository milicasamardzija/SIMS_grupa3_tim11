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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for Prioritet.xaml
    public partial class Prioritet : Window
    {
        CheckupDTO checkup = new CheckupDTO();
        CheckupDTO Checkup
        {
            get { return checkup; }
            set { checkup = value; }
        }


        public ObservableCollection<CheckupDTO> appointmentList { get; set; }
        int id;
       
        public Prioritet(ObservableCollection<CheckupDTO> applist, int idP)
        {
            InitializeComponent();
            appointmentList = applist;
            id = idP;
        }

        private void Nazad_na_pocetnu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void doktor(object sender, RoutedEventArgs e)
        {
            PrioritetDoktor doktor = new PrioritetDoktor(appointmentList, id);
            doktor.Show();
           

        }

        private void datum(object sender, RoutedEventArgs e)
        {
            PrioritetDatum datum = new PrioritetDatum(id);
            datum.Show();
            
        }
    }
}