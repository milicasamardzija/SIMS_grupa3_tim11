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
using Hospital.Model;
using Hospital.Prikaz;
using Hospital.FileStorage.Interfaces;
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for LekoviCekajuReviziju.xaml
    /// </summary>
    public partial class LekoviCekajuReviziju : Window
    {
        public ObservableCollection<ReviewDTO> ListMedicineReview { get; set; }
        public MedicineReviewController controllerReview = new MedicineReviewController();

        public LekoviCekajuReviziju()
        {
            InitializeComponent();
            this.DataContext = this;
            ListMedicineReview = new ObservableCollection<ReviewDTO>(controllerReview.getAll());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RevizijaLekaLekar reviewMedicine = new RevizijaLekaLekar(ListMedicineReview, (ReviewDTO)ReviewMedicineList.SelectedItem, ReviewMedicineList.SelectedIndex);
            reviewMedicine.Show();
        }
    }
}
