using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class MedicineReviewDTO : INotifyPropertyChanged
    {
        private int idMedicine;
        private int idMedicineReview;
        private int idDoctor;
        private Doctor doctor;
        private ReviewType typeReview;
        private String review;
        private Boolean done;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public MedicineReviewDTO(int id, int medicineId, int doctorId, ReviewType tReview, String reviewTxt, Boolean reviewDone)
        {
            idMedicineReview = id;
            idMedicine = medicineId;
            idDoctor = doctorId;
            typeReview = tReview;
            review = reviewTxt;
            done = reviewDone;
        }

        public int IdMedicine
        {
            get
            {
                return idMedicine;
            }
            set
            {
                if (value != idMedicine)
                {
                    idMedicine = value;
                    OnProperychanged("IdMedicine");
                }
            }
        }

        public int IdMedicineReview
        {
            get
            {
                return idMedicineReview;
            }
            set
            {
                if (value != idMedicineReview)
                {
                    idMedicineReview = value;
                    OnProperychanged("IdMedicineReview");
                }
            }
        }

        public int IdDoctor
        {
            get
            {
                return idDoctor;
            }
            set
            {
                if (value != idDoctor)
                {
                    idDoctor = value;
                    OnProperychanged("IdDoctor");
                }
            }
        }

        public ReviewType TypeReview
        {
            get
            {
                return typeReview;
            }
            set
            {
                if (value != typeReview)
                {
                    typeReview = value;
                    OnProperychanged("TypeReview");
                }
            }
        }

        public String Review
        {
            get
            {
                return review;
            }
            set
            {
                if (value != review)
                {
                    review = value;
                    OnProperychanged("Review");
                }
            }
        }

        public Boolean Done
        {
            get
            {
                return done;
            }
            set
            {
                if (value != done)
                {
                    done = value;
                    OnProperychanged("Done");
                }
            }
        }
    }
}
