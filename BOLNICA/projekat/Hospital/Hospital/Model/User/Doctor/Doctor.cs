
using Hospital.Model;
using System;


    public class Doctor : User
    {

        // public String specialization;
        public int freeDays = 25;
        private SpecializationType specializationType;

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
                    OnProperychanged("SpecializationType");
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
    }
