// File:    Doctor.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:07 PM
// Purpose: Definition of Class Doctor

using System;

public class Doctor : User
{
    public int doctorId;
   public String specialization;
   public int freeDays = 25;


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
}