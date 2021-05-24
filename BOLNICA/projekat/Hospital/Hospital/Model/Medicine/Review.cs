using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Prikaz
{
    public class Review : INotifyPropertyChanged
    {
        private String name;
        private String medicineType;
        private ReviewType reviewType;
        private Boolean done;
        private int idMedicine;
        private int idMedicineReviw;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Review(String n, String typeMedicine, ReviewType typeReview, Boolean d, int idM, int idR)
        {
            name = n;
            reviewType = typeReview;
            medicineType = typeMedicine;
            done = d;
            idMedicine = idM;
            idMedicineReviw = idR;
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
                    OnProperychanged("Name");
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
                    OnProperychanged("MedicineType");
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
                    OnProperychanged("ReviewType");
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
                return idMedicineReviw;
            }
            set
            {
                if (value != idMedicineReviw)
                {
                    idMedicineReviw = value;
                    OnProperychanged("IdMedicineReview");
                }
            }
        }
    }
}
