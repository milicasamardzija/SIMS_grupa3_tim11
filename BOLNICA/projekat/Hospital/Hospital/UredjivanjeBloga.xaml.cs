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
    /// Interaction logic for UredjivanjeBloga.xaml
    /// </summary>
    public partial class UredjivanjeBloga : Window
    {
        public UredjivanjeBloga()//String bg)
        {

            InitializeComponent();
           // textBlog.Text= bg;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
