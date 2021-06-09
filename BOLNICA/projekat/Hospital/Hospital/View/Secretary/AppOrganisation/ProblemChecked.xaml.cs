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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Secretary.AppOrganisation
{
    /// <summary>
    /// Interaction logic for ProblemChecked.xaml
    /// </summary>
    public partial class ProblemChecked : UserControl
    {
        public Feedback feedback;
        public FeedbackController controller;

        public ProblemChecked()
        {
            InitializeComponent();
            controller = new FeedbackController();
        }

        private void posalji(object sender, RoutedEventArgs e)
        {

            
            if(problem.Text != null && email.Text != null )
            {

                feedback = new Feedback(0, FeedbackType.prijava_problema, ocena.Value, komentar.Text, problem.Text, email.Text);
                controller.createFeedbackProblem(feedback);


                MessageBox.Show("Uspesno ste uneli feedback!");
            
             
            } else
            {
                MessageBox.Show("Morate popuniti polje za opis problema i email");

            }
           
        }
    }
}
