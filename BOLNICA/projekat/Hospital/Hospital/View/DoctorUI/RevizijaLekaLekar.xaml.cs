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
using System.Collections.ObjectModel;
using System.IO;
using Hospital.Model;
using Hospital.Prikaz;
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for RevizijaLekaLekar.xaml
    /// </summary>
    public partial class RevizijaLekaLekar : Window
    {
        public ObservableCollection<ReviewDTO> reviewList;
        public ReviewDTO medicineReview;
        public int indexReview;
        public MedicineReviewController controller = new MedicineReviewController();

        public RevizijaLekaLekar(ObservableCollection<ReviewDTO> list, ReviewDTO selectedReview, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            reviewList = list;
            medicineReview = selectedReview;
            indexReview = selectedIndex;

            textNaziv.SelectedText = Convert.ToString(medicineReview.Name);
            textTipLeka.SelectedText = Convert.ToString(medicineReview.MedicineType);
            textTipRevizije.SelectedText = Convert.ToString(medicineReview.ReviewType);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            controller.makeRecension(medicineReview);
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
