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
    /// Interaction logic for ProblemUnchecked.xaml
    /// </summary>
    public partial class ProblemUnchecked : UserControl
    {
        public Feedback feedback;
        
       public FeedbackController controller;

        public ProblemUnchecked()
        {
            InitializeComponent();

            controller = new FeedbackController();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!komentar.Text.Equals("") || !ocena.Value.Equals(""))
            {

                feedback = new Feedback(0, FeedbackType.utisak, ocena.Value, komentar.Text);
                controller.createFeedbackUtisak(feedback);
                MessageBox.Show("Uspesno ste uneli feedback!");
             
            }
            else
            {

                MessageBox.Show("Morate uneti ocenu i komentar!");
            }
            
               
            
        }
    }
}
