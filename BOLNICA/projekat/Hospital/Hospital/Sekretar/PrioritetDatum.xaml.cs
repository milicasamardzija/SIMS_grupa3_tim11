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
   
    public partial class PrioritetDatum : Window
    {
        ObservableCollection<Patient> listPatients
        {
            get; set;
        }
        public PrioritetDatum(ObservableCollection<Patient> list)
        {
            InitializeComponent();
            listPatients = list;

        }

        private void FindBtn(object sender, RoutedEventArgs e)
        {
            SacuvajDatum findByDate = new SacuvajDatum();
            findByDate.Show();
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
