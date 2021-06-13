// File:    Anamnesis.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:57:29
// Purpose: Definition of Class Anamnesis

using Hospital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Anamnesis : Entity
{
    private String nameS;
    private String gender;
    private List<Note> NotesForAnamnesis;
    private String datePlace;
    private int idPatient;
    private Patient patients;
    private String adress;
    private String status;
    private String job;
    private String summary;


    public Anamnesis() { }
    public Anamnesis(int id, String ns, String g, String d, int p, String adr, String stat, String j, String sm) : base(id)
    {
        this.nameS = ns;
        this.gender = g;
        this.datePlace = d;
        this.idPatient = p;
        this.adress = adr;
        this.status = stat;
        this.job = j;
        this.summary = sm;
    }

    public Anamnesis(int id, String dp, List<Note> notesForAnamnesis, String ns, String g, int idP, String adr, String stat, String j, String sm) : base(id)
    {
        this.datePlace = dp;
        this.NotesForAnamnesis = notesForAnamnesis;
        this.nameS = ns;
        this.gender = g;
        this.idPatient = idP;
        this.adress = adr;
        this.status = stat;
        this.job = j;
        this.summary = sm;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public String NameS
    {
        get
        {
            return nameS;
        }
        set
        {
            if (value != nameS)
            {
                nameS = value;
                OnPropertyChanged("NameS");
            }
        }
    }
    public String Gender
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
                OnPropertyChanged("Gender");
            }
        }
    }

    public String DatePlace
    {
        get
        {
            return datePlace;
        }
        set
        {
            if (value != datePlace)
            {
                datePlace = value;
                OnPropertyChanged("DatePlace");
            }
        }
    }

    public List<Note> NotesForAnamnesis1
    {
        get
        {
            return NotesForAnamnesis;
        }
        set
        {
            if (value != NotesForAnamnesis)
            {
                NotesForAnamnesis = value;
                OnPropertyChanged("NotesForAnamnesis1");
            }
        }
    }
    public int IdPatient
    {
        get
        {
            return idPatient;
        }
        set
        {
            if (value != idPatient)
            {
                idPatient = value;
                OnPropertyChanged("IdPatient");
            }
        }
    }
    [JsonIgnore]
    public Patient Patients
    {
        get
        {
            return patients;
        }
        set
        {
            if (value != patients)
            {
                patients = value;
                OnPropertyChanged("Patients");
            }
        }
    }
    public String Adress
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
                OnPropertyChanged("Adress");
            }
        }
    }
    public String Status
    {
        get
        {
            return status;
        }
        set
        {
            if (value != status)
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
    }
    public String Job
    {
        get
        {
            return job;
        }
        set
        {
            if (value != job)
            {
                job = value;
                OnPropertyChanged("Job");
            }
        }
    }
    public String Summary
    {
        get
        {
            return summary;
        }
        set
        {
            if (value != summary)
            {
                summary = value;
                OnPropertyChanged("Summary");
            }
        }
    }

}