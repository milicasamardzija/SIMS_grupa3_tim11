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

namespace Hospital.View.Manager.FeedbackM
{
    public partial class FeedbackGood : UserControl
    {
        public FeedbackGood()
        {
            InitializeComponent();
            Open();

        }

        private void Open()
        {
            if ((bool)utisakBtn.IsChecked)
            {
                FeedbackFirst up = new FeedbackFirst();
                frame.Navigate(up);
            }
        }

        private void utisakBtn_Checked(object sender, RoutedEventArgs e)
        {
            FeedbackFirst up = new FeedbackFirst();
            frame.Navigate(up);
        }

        private void problemBtn_Checked(object sender, RoutedEventArgs e)
        {
            Problem p = new Problem();
            frame.Navigate(p);
        }
    }
}
