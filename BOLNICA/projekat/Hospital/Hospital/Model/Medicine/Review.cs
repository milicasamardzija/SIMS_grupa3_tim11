using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Prikaz
{
    public class Review
    {
        private String name;
        private String medicineType;
        private ReviewType reviewType;
        private Boolean done;
        private int idMedicine;
        private int idMedicineReviw;


        public Review(String name, String typeMedicine, ReviewType typeReview, Boolean done, int idMedicine, int idReview)
        {
            this.name = name;
            this.reviewType = typeReview;
            this.medicineType = typeMedicine;
            this.done = done;
            this.idMedicine = idMedicine;
            this.idMedicineReviw = idReview;
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                }
            }
        }
        public String MedicineType
        {
            get
            {
                return medicineType;
            }
            set
            {
                if (value != medicineType)
                {
                    medicineType = value;
                }
            }
        }

        public ReviewType ReviewType
        {
            get
            {
                return reviewType;
            }
            set
            {
                if (value != reviewType)
                {
                    reviewType = value;
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
                }
            }
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
                }
            }
        }

        public int IdMedicineReview
        {
            get
            {
                return idMedicineReviw;
            }
            set
            {
                if (value != idMedicineReviw)
                {
                    idMedicineReviw = value;
                }
            }
        }
    }
}
