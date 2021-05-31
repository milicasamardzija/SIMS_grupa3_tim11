using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class MedicineReview : Entity
    {
        private int idMedicine;
        private int idDoctor;
        private Doctor doctor;
        private ReviewType typeReview;
        private String review;
        private Boolean done;
        
        public MedicineReview(int id, int medicineId,int doctorId, ReviewType tReview, String reviewTxt, Boolean reviewDone) : base(id)
        {
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
                }
            }
        }

        [JsonIgnore]
        public Doctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                if (value != doctor)
                {
                    doctor = value;
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
    }
}
