
using Hospital;
using Hospital.Model;
using System;


    public class Doctor : User
    {

        // public String specialization;
        public int freeDays = 25;
        private SpecializationType specializationType;
        private Shift shift;
        private Vacation vacation;
    private SpecializationType type;

    public Doctor(int id, string name, string surname, string telephoneNumber, string jmbg, Gender gender, DateTime birthdayDate, Adress adress, SpecializationType type, Shift shift, Vacation vacation)
    {
        Id = id;
        this.Name = name;
        this.Surname = surname;
        this.TelephoneNumber = telephoneNumber;
        this.Jmbg = jmbg;
        this.Gender = gender;
        this.BirthdayDate = birthdayDate;
        this.Adress = adress;
        this.type = type;
        this.shift = shift;
        this.vacation = vacation;
    }




    // private int doctorId;




    /*
        public int DoctorId
        {
            get
            {
                return doctorId;
            }
            set
            {
                if (value != doctorId)
                {
                    doctorId = value;
                    OnProperychanged("DoctorId");
                }
            }
        }*/

    public SpecializationType SpecializationType
        {
            get
            {
                return specializationType;
            }
            set
            {
                if (value != specializationType)
                {
                    specializationType = value;
                  
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
                
            }
        }
    }
}
