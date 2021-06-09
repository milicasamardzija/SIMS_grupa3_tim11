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
    /// Interaction logic for FeedbackSekretar.xaml
    /// </summary>
    public partial class FeedbackSekretar : Page
    {
        public FeedbackSekretar()
        {
            InitializeComponent();
            ProblemUnchecked p = new ProblemUnchecked();

            frame.Navigate(p);

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if((bool)problemCh.IsChecked)
            {
                ProblemChecked p = new ProblemChecked();
                frame.Navigate(p);
            }
            else if ((bool)utisakCh.IsChecked)
            {
                ProblemUnchecked up = new ProblemUnchecked();
                frame.Navigate(up);
            }
            else
            {
                ProblemUnchecked pu = new ProblemUnchecked();
                frame.Navigate(pu);
            }
        }

       
    }
}
