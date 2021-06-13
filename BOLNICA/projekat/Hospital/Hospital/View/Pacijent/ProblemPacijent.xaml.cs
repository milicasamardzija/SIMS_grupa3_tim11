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

namespace Hospital.View.Pacijent
{
    /// <summary>
    /// Interaction logic for ProblemPacijent.xaml
    /// </summary>
    public partial class ProblemPacijent : Window
    {
          public Feedback feedback;
        public FeedbackController controller;

        public ProblemPacijent()
        {
            InitializeComponent();
            controller = new FeedbackController();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
