using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Hospital.DTO
{
    public class PatientDTO : INotifyPropertyChanged
    {
        private String name;
        private String surname;
        private String telephoneNumber;
        private String jmbg;
        private Gender gender;
        private DateTime birthdayDate;
        private int id;
        private HealthCareCategory healthCareCategory;
        private int idHealthCard;
        private String occupation;
        private String insurence;
        private Boolean guest = false;
        private Adress adress;
        private Boolean banovan = false;
        private DateTime datumBanovanja;

        public PatientDTO(String n, String s, String tel, String jmb, Gender g, DateTime b, int pId, HealthCareCategory hcc, int idhc, String oc, String ins, Adress adr, Boolean banovan) 
        {
            this.name = n;
            this.surname = s;
            this.telephoneNumber = tel;
            this.jmbg = jmb;
            this.gender = g;
            this.birthdayDate = b; 
            this.id = pId;
            this.healthCareCategory = hcc;
            this.idHealthCard = idhc; 
            this.occupation = oc;
            this.insurence = ins;
            this.adress = adr;
            this.guest = false;
            this.banovan = banovan;
           

        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

         public int Id
         {
            get
            {
               return id;
             }
            set
             {
                 if (value != id)
                 {
                    id = value;
                    OnProperychanged("Id");
                 }
             }
         } 

        public int IdHealthCard
        {
            get
            {
                return idHealthCard;
            }
            set
            {
                if (value != idHealthCard)
                {
                    idHealthCard = value;
                    OnProperychanged("IdHealthCard");
                }
            }
        }

        public HealthCareCategory HealthCareCategory
        {
            get
            {
                return healthCareCategory;
            }
            set
            {
                if (value != healthCareCategory)
                {
                    healthCareCategory = value;
                    OnProperychanged("HealthCareCategory");
                }
            }
        }

        public String Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                if (value != occupation)
                {
                    occupation = value;
                    OnProperychanged("Occupation");
                }
            }
        }

        public String Insurence
        {
            get
            {
                return insurence;
            }
            set
            {
                if (value != insurence)
                {
                    insurence = value;
                    OnProperychanged("Insurence");
                }
            }
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

        public String Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value != surname)
                {
                    surname = value;
                    OnProperychanged("Surname");
                }
            }
        }

        public String Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnProperychanged("Jmbg");
                }
            }
        }

        public String TelephoneNumber
        {
            get
            {
                return telephoneNumber;
            }
            set
            {
                if (value != telephoneNumber)
                {
                    telephoneNumber = value;
                    OnProperychanged("TelephoneNumber");
                }
            }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != gender)
                {
                    gender = value;
                    OnProperychanged("Gender");
                }
            }
        }

        public DateTime BirthdayDate
        {
            get
            {
                return birthdayDate;
            }
            set
            {
                if (value != birthdayDate)
                {
                    birthdayDate = value;
                    OnProperychanged("BirthdayDate");
                }
            }
        }

        public Boolean Guest
        {
            get
            {
                return guest;
            }
            set
            {
                if (value != guest)
                {
                    guest = value;
                    OnProperychanged("Guest");
                }
            }
        }
        public Boolean Banovan
        {
            get
            {
                return banovan;
            }
            set
            {
                if (value != banovan)
                {
                    banovan = value;
                    OnProperychanged("Banovan");
                }
            }
        }
        public DateTime DatumBanovanja
        {
            get
            {
                return datumBanovanja;
            }
            set
            {
                if (value != datumBanovanja)
                {
                    datumBanovanja = value;
                    OnProperychanged("DatumBanovanja");
                }
            }
        }
        public Adress Adress
        {
            get
            {
                return adress;
            }
            set
            {
                if (value != adress)
                {
                    adress = value;
                    OnProperychanged("Adress");
                }
            }
        }
    }
}
