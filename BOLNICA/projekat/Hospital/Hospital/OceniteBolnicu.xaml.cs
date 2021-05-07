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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for OceniteBolnicu.xaml
    /// </summary>
    public partial class OceniteBolnicu : Window
    {
      
        public OceniteBolnicu()
        {
            InitializeComponent();
        }

       


         

        private void posalji(object sender, RoutedEventArgs e)
        {
            SacuvanaAnketa poslato = new SacuvanaAnketa();
            poslato.Show();
            this.Close();
         
            SurveyFileStorage sveAnkete = new SurveyFileStorage();

         
            int ocenjeno = ocena.SelectedIndex;
            string komentarisano = komentar.Text;
            int id = sveAnkete.GetAll().Count() + 1;

            Survey novaAnketa = new Survey(id, komentarisano, ocenjeno, null);

            sveAnkete.Save(novaAnketa);

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
