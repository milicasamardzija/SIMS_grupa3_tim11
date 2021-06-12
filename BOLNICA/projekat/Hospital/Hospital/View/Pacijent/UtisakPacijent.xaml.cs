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
    /// Interaction logic for UtisakPacijent.xaml
    /// </summary>
    public partial class UtisakPacijent : Window
    {
        public Feedback feedback;

        public FeedbackController controller;
        public UtisakPacijent()
        {
            InitializeComponent();
            controller = new FeedbackController();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (komentar.Text == null || ocena.Value == null)
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
