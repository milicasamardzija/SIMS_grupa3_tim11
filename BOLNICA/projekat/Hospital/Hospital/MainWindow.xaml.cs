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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Prijava prijava = new Prijava(new BlogGlavni());
            frame.Navigate(prijava);
            
        }

        private void prijava(object sender, RoutedEventArgs e)
        {
            Prijava p = new Prijava(new BlogGlavni());
            frame.Navigate(p);

        }
        private void blog(object sender, RoutedEventArgs e)
        {
            BlogGlavni b = new BlogGlavni();
            frame.Navigate(b);
        }

        
    }
}