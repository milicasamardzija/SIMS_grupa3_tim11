// File:    Anamnesis.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:57:29
// Purpose: Definition of Class Anamnesis

using System;
using System.Collections.Generic;

public class Anamnesis
{
    //public int idAnam;
    //public String summary;
    public int idAnam { get; set; }
    public String nameS { get; set; }
    public String gender { get; set; }
    public String datePlace { get; set; }
    // public Adress adress;
    public String adress { get; set; }
    public String status { get; set; }
    public String job { get; set; }
    public String summary { get; set; }

    public Anamnesis(int i, String ns, String g, String dP, String adr, String stat, String j, String sm)
    {
        idAnam = i;
        nameS = ns;
        gender = g;
        datePlace = dP;
        adress = adr;
        status = stat;
        job = j;
        summary = sm;
    }
}