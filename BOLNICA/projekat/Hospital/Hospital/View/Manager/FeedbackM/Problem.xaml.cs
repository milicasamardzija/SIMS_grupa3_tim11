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

namespace Hospital.View.Manager.FeedbackM
{
    public partial class Problem : UserControl
    {
        public Feedback feedback;
        public FeedbackController controller;
        public Problem()
        {
            InitializeComponent();
            controller = new FeedbackController();
        }
        private void posalji(object sender, RoutedEventArgs e)
        {


            if (!problem.Text.Equals("") && !email.Text.Equals(""))
            {

                feedback = new Feedback(0, FeedbackType.prijava_problema, -1, "", problem.Text, email.Text);
                controller.createFeedbackProblem(feedback);


                MessageBox.Show("Uspesno ste uneli feedback!");


            }
            else
            {
                MessageBox.Show("Morate popuniti polje za opis problema i email");

            }

        }
    }
}
