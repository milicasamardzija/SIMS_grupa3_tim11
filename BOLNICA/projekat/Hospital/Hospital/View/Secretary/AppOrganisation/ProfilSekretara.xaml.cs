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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Secretary.AppOrganisation
{
    /// <summary>
    /// Interaction logic for ProfilSekretara.xaml
    /// </summary>
    public partial class ProfilSekretara : Page
    {
        private Nalozi glavniProzor;
        public ProfilSekretara(Nalozi prozor)
        {
            InitializeComponent();
            glavniProzor = prozor;
        }

        private void odjavise(object sender, RoutedEventArgs e)
        {
            glavniProzor.Close();
        }
    }
}
