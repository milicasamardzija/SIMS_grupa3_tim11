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

namespace Hospital.View.DoctorUI
{
    /// <summary>
    /// Interaction logic for PovratneInformacijeLekar.xaml
    /// </summary>
    public partial class PovratneInformacijeLekar : Window
    {
        public PovratneInformacijeLekar()
        {
            InitializeComponent();
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            Problem p = new Problem();
            p.Show();
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            Utisak u = new Utisak();
            u.Show();
        }
    }
}
