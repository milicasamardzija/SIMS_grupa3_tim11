using Hospital.Controller;
using Hospital.Model;
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
    /// Interaction logic for Problem.xaml
    /// </summary>
    public partial class Problem : Window
    {
        public Feedback feedback;
        public FeedbackController controllerFeedback;

        public Problem()
        {
            InitializeComponent();
            controllerFeedback = new FeedbackController();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (problemText.Text != null && emailText.Text != null)
            {
                feedback = new Feedback(0, FeedbackType.prijava_problema, ocenaZvezdicama.Value, komentarText.Text, problemText.Text, emailText.Text);
                controllerFeedback.createFeedbackProblem(feedback);
                MessageBox.Show("Uspesno ste uneli povratne informacije!");
            }
            else
            {
                MessageBox.Show("Morate popuniti polje za opis problema i email adresu!");
            }
        }
    }
}
