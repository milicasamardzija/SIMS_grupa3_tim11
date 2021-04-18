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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for BelsekaMagacin.xaml
    /// </summary>

   
   // public String Beleska { get; set; }

    public partial class BelsekaMagacin : UserControl
    {
        public string beleska;
        public BelsekaMagacin()
        {
            InitializeComponent();
            BeleskaTxt.Text = beleska;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            beleska = BeleskaTxt.Text;
        }
    }
}
