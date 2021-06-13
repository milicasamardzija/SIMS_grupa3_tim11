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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for FeedBackPatient.xaml
    /// </summary>
    public partial class FeedBackPatient : Window
    {
        public FeedBackPatient()
        {
            InitializeComponent();
        }

       
        private void utisakBtn_Checked(object sender, RoutedEventArgs e)
        {
            UtisakPacijent up = new UtisakPacijent();
            up.Show();
        }

        private void problemBtn_Checked(object sender, RoutedEventArgs e)
        {
            ProblemPacijent p = new ProblemPacijent();
            p.Show();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
