// File:    Checkup.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:29:16 PM
// Purpose: Definition of Class Checkup

using System;

public class Checkup : Appointment
{
   public CheckupType type { get; set; }
    public int idCh { get; set; }
    public string patient { get; set; }

    public Checkup(string d, string t, double dur, CheckupType ty, string p)
    {
        date = d;
        time = t;
        duration = dur;
        type = ty;
        patient = p;
    }
}