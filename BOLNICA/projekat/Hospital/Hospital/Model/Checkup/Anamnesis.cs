// File:    Anamnesis.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:57:29
// Purpose: Definition of Class Anamnesis

using Hospital.Model;
using System;
using System.Collections.Generic;

public class Anamnesis : Entity
{
    public String nameS { get; set; }
    public String gender { get; set; }
    public String datePlace { get; set; }
    public String adress { get; set; }
    public String status { get; set; }
    public String job { get; set; }
    public String summary { get; set; }

    public Anamnesis(int id, String ns, String g, String dP, String adr, String stat, String j, String sm) : base(id)
    {
        nameS = ns;
        gender = g;
        datePlace = dP;
        adress = adr;
        status = stat;
        job = j;
        summary = sm;
    }
}