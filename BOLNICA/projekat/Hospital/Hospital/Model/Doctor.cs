
using System;

public class Doctor : User
{
   private int doctorId;
   private String specialization;
   private int freeDays = 25;



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
    }

    public String Specialization
    {
        get
        {
            return specialization;
        }
        set
        {
            if (value != specialization)
            {
                specialization = value;
                OnProperychanged("Specialization");
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
                freeDays= value;
                OnProperychanged("FreeDays");
            }
        }
    }
}