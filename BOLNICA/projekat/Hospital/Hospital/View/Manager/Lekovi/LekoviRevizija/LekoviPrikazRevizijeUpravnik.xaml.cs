using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Prikaz;
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
using Hospital.Controller;

namespace Hospital
{
    public partial class LekoviPrikazRevizijeUpravnik : UserControl
    {
        private ReviewDTO revision;
        private MedicineReviewController reviewController;
        public LekoviPrikazRevizijeUpravnik(ReviewDTO revision)
        {
            InitializeComponent();
            this.revision = revision;
            this.reviewController = new MedicineReviewController();

            NazivTxt.SelectedText = revision.Name;
            TipTxt.SelectedText = revision.MedicineType;
            VrstaTxt.SelectedText = Convert.ToString(revision.ReviewType);
            LekarTxt.SelectedText = reviewController.getDoctor(revision);
            RecenzijaTxt.SelectedText = reviewController.getRezension(revision);
        }
    }
}
