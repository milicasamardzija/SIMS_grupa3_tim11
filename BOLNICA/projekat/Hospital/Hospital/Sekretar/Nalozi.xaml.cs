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
    /// Interaction logic for Nalozi.xaml
    /// </summary>
    public partial class Nalozi : Window
    {

      //  public Page blogg;

        public Nalozi() //(Page blogGlavni)
        {
            InitializeComponent();
            // blogg = blogGlavni;
            //Pacijenti pacijenti = new Pacijenti();
           // frameS.Navigate(pacijenti);

        }

        private void pacijenti(object sender, RoutedEventArgs e)
        {
            Pacijenti p = new Pacijenti();
            frameS.Navigate(p);

        }

        private void blog(object sender, RoutedEventArgs e)
        {
            Blog b = new Blog();
            frameS.Navigate(b);
        }
       
       
      /*  private void blog(object sender, RoutedEventArgs e)
        {
            UredjivanjeBloga blog = new UredjivanjeBloga();
            blog.ShowDialog();
        } */
    }
}
