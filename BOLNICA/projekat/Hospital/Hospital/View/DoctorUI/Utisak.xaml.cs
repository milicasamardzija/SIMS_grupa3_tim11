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
    /// Interaction logic for Utisak.xaml
    /// </summary>
    public partial class Utisak : Window
    {
        public Feedback feedback;
        public FeedbackController feedbackController;

        public Utisak()
        {
            InitializeComponent();
            feedbackController = new FeedbackController();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (komentarText.Text.Equals("") || ocenaPerformansi.Value.Equals(""))
            {
                MessageBox.Show("Morate uneti ocenu i komentar!");
            }
            else
            {
                feedback = new Feedback(0, FeedbackType.utisak, ocenaPerformansi.Value, komentarText.Text);
                feedbackController.createFeedbackUtisak(feedback);
                MessageBox.Show("Uspesno ste uneli feedback!");
            }
        }
    }
}
