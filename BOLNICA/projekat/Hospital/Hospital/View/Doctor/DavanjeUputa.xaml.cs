using Hospital.View.Doctor;
using System;
using System.Collections.Generic;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for DavanjeUputa.xaml
    /// </summary>
    public partial class DavanjeUputa : Window
    {
        public DavanjeUputa()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UputZaAmbulantnoSpecijalistickiPregled instruction = new UputZaAmbulantnoSpecijalistickiPregled();
            instruction.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            BolnickoLecenje medicalCare = new BolnickoLecenje();
            medicalCare.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
