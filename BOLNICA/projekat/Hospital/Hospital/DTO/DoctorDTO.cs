using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
   public class DoctorDTO : INotifyPropertyChanged
    {
        private int id;
        private String name;
        private String surname;
        private String telephoneNumber;
        private String jmbg;
        private Gender gender;
        private DateTime birthdayDate;
        private String username;
        private String password;
        private Adress adress;
        private int freeDays = 25;
        private SpecializationType type;
        private Shift shift;
        private Vacation vacation; 


        public DoctorDTO() { }

        public DoctorDTO(int id, String name, String surname, String telephone, String jmbg, Gender gender, DateTime date, Adress address,SpecializationType type )
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.telephoneNumber = telephone;
            this.jmbg = jmbg;
            this.gender = gender;
            this.birthdayDate = date;
            this.adress = address;
            this.type = type;

        }

        public DoctorDTO(int id, String name, String surname, String telephone, String jmbg, Gender gender, DateTime date, Adress address, SpecializationType type, Shift shift, Vacation vacation)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.telephoneNumber = telephone;
            this.jmbg = jmbg;
            this.gender = gender;
            this.birthdayDate = date;
            this.adress = address;
            this.type = type;
            this.Shift = shift;
            this.vacation = vacation;

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

        public int FreeDays
        {
            get
            {
                return freeDays;
            }
            set
            {
                if (value != freeDays)
                {
                    freeDays = value;
                    OnProperychanged("FreeDays");
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ime ne moze biti prazno!");
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Prezime ne moze biti prazno!");

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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Jmbg ne ne moze biti prazan!");
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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Kontakt telefon je obavezan!");

                if (value != telephoneNumber)
                {
                    telephoneNumber = value;
                    OnProperychanged("TelephoneNumber");
                }
            }
        }

        public SpecializationType Type
        {
            get
            {
                return type;
            }
            set
            {

                if (value != type)
                {
                    type = value;
                    OnProperychanged("Type");
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

        public Shift Shift
        {
            get
            {
                return shift;
            }
            set
            {
                if (value != shift)
                {
                    shift = value;
                    OnProperychanged("Shift");
                }
            }
        }
        public Vacation Vacation

        {
            get
            {
                return vacation;
            }
            set
            {
                if (value != vacation)
                {
                    vacation = value;
                    OnProperychanged("Vacation");
                }
            }
        }
    }
}
