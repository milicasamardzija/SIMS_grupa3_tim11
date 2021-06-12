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
    public partial class FeedbackFirst : UserControl
    {
        public Feedback feedback;

        public FeedbackController controller;
        public FeedbackFirst()
        {
            InitializeComponent();

            controller = new FeedbackController();
        }

        private void posalji(object sender, RoutedEventArgs e)
        {
            if (komentar.Text.Equals(""))
            {

                MessageBox.Show("Morate uneti ocenu i komentar!");
            }
            else
            {
                feedback = new Feedback(0, FeedbackType.utisak, ocena.Value, komentar.Text);
                controller.createFeedbackUtisak(feedback);
                MessageBox.Show("Uspesno ste uneli feedback!");
            }
        }
    }
}
