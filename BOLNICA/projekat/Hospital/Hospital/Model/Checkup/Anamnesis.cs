// File:    Anamnesis.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:57:29
// Purpose: Definition of Class Anamnesis

using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Anamnesis : Entity
{
    public String nameS { get; set; }
    public String gender { get; set; }
    public List<Note> NotesForAnamnesis { get; set; }
    public int idPatient { get; set; }
    public Patient patients;
    public String adress { get; set; }
    public String status { get; set; }
    public String job { get; set; }
    public String summary { get; set; }


    public Anamnesis() { }
    public Anamnesis(int id, String ns, String g, int p, String adr, String stat, String j, String sm) : base(id)
    {
        nameS = ns;
        gender = g;
        idPatient = p;
        adress = adr;
        status = stat;
        job = j;
        summary = sm;
    }

    public Anamnesis(int id, List<Note> notesForAnamnesis,String ns, String g, int idP, String adr, String stat, String j, String sm) : base(id)
    {
        NotesForAnamnesis = notesForAnamnesis;
        nameS = ns;
        gender = g;
        idPatient = idP;
        adress = adr;
        status = stat;
        job = j;
        summary = sm;
    }

}