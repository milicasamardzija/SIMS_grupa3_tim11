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

namespace Hospital
{
    public partial class LekoviPrikazRevizijeUpravnik : UserControl
    {
        private LekRevizija revizija;
        public LekoviPrikazRevizijeUpravnik(LekRevizija selected)
        {
            InitializeComponent();
            revizija = selected;

            NazivTxt.SelectedText = selected.Name;
            TipTxt.SelectedText = selected.MedicineType;
            VrstaTxt.SelectedText = Convert.ToString(selected.ReviewType);
            LekarTxt.SelectedText = getDoctor();
            RecenzijaTxt.SelectedText = getRezension();
            
        }

        public String getDoctor()
        {
            DoctorFileStorage storage = new DoctorFileStorage();
            Doctor doctor = storage.FindById(getIdDoctor());
            return doctor.Name + " " + doctor.Surname;
        }

        public int getIdDoctor()
        {
            MedicineReviewFileStorage storage = new MedicineReviewFileStorage();
            MedicineReview review = storage.FindById(revizija.IdMedicineReview);
            return review.IdDoctor;
        }

        public String getRezension()
        {
            MedicineReviewFileStorage storage = new MedicineReviewFileStorage();
            MedicineReview review = storage.FindById(revizija.IdMedicineReview);
            return review.Review;
        }
    }
}
