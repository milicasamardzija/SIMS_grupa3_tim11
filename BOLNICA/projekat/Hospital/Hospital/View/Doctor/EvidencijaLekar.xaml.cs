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
    /// Interaction logic for EvidencijaLekar.xaml
    /// </summary>
    public partial class EvidencijaLekar : Window
    {
        public EvidencijaLekar()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Evidencija record = new Evidencija();
            record.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            PotroseniMaterijal spentMaterial = new PotroseniMaterijal();
            spentMaterial.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UvidUSobe roomLook = new UvidUSobe();
            roomLook.Show();
        }
    }
}
