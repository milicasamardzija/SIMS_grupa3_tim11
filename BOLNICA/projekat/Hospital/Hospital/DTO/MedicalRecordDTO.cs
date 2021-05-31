using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class MedicalRecordDTO : PatientDTO
    {
        private int medicalRecordId;
        private BloodType bloodType;
        private ObservableCollection<AlergensDTO> alergens;

        public MedicalRecordDTO() { }
        public MedicalRecordDTO(String n, String s, String j, Gender g, DateTime dr, int mid, HealthCareCategory hcc, int idhc, BloodType bt)
        {
            this.Name = n;
            this.Surname = s;
            this.Jmbg = j;
            this.Gender = g;
            this.BirthdayDate = dr;
            this.medicalRecordId = mid;  
            this.HealthCareCategory = hcc;
            this.IdHealthCard = idhc;
            this.bloodType = bt;

            //this.Alergens = null;


        }
        public MedicalRecordDTO(String ime, String prezime, String jmbgg, Gender pol, DateTime drodj, int id, HealthCareCategory hcc, int idhc, BloodType kg, ObservableCollection<AlergensDTO> alergeni)
        {
            this.Name = ime;
            this.Surname = prezime;
            this.Jmbg = jmbgg;
            this.Gender = pol;
            this.BirthdayDate = drodj;
            this.HealthCareCategory = hcc;
            this.medicalRecordId = id;   //medical record id ce biti isto sto i patientId, pa cu po tome traziti
            this.IdHealthCard = idhc;
            this.bloodType = kg;
            this.alergens = alergeni;


        }
        public int MedicalRecordId
        {
            get
            {
                return medicalRecordId;
            }
            set
            {
                if (value != medicalRecordId)
                {
                    medicalRecordId = value;
                    OnProperychanged("MedicalRecordId");
                }
            }
        }

        public BloodType BloodType
        {
            get
            {
                return bloodType;
            }
            set
            {
                if (value != bloodType)
                {
                    bloodType = value;
                    OnProperychanged("BloodType");
                }
            }
        }
        public ObservableCollection<AlergensDTO> Alergens
        {
            get
            {
                return alergens;
            }
            set
            {
                if (value != alergens)
                {
                    alergens = value;
                    OnProperychanged("Alergens");
                }
            }
        }
    }
}
