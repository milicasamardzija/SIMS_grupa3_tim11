// File:    Appointment.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:25:31 PM
// Purpose: Definition of Class Appointment

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Appointment : INotifyPropertyChanged
{
    // public DateTime date { get; set; }   
    //public DateTime time { get; set; }
    // public double duration { get; set; }
    // public int idA { get; set; }

    // public Patient patient { get; set; }
    // public Doctor doctor { get; set; }

    public DateTime date;
    public String time;
    public double duration;
    public int idA;
    public Patient patient;
    public Doctor doctor;
    public Room room;
    public int idRoom { get; set; }

    public DateTime dateTime { get; set; }

    public Appointment() { }

    public Appointment(int v, DateTime dateTime, double v2, Doctor doctor, Patient patient)
    {
        this.idA = v;
        this.dateTime = dateTime;

        this.duration = v2;
        this.doctor = doctor;
        this.patient = patient;
    }

    public Appointment(int v, DateTime dateTime1, String tm, double v2, Doctor doctor, Patient patient)
    {
        this.idA = v;
        this.date = dateTime1;
        this.time = tm;
        this.duration = v2;
        this.doctor = doctor;
        this.patient = patient;
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string name)
    {
        if(PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    [JsonIgnore]
    public Room Room
    {
        get
        {
            return room;
        }
        set
        {
            if (value != room)
            {
                room = value;
                OnPropertyChanged("Date");
            }
        }
    }

    public int IdRoom
    {
        get
        {
            return idRoom;
        }
        set
        {
            if (value != idRoom)
            {
                idRoom = value;
                OnPropertyChanged("Date");
            }
        }
    }
    public DateTime Date
    {
        get
        {
            return date;
        }
        set
        {
            if(value != date)
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
    }

    public DateTime DateTime
    {
        get
        {
            return dateTime;
        }
        set
        {
            if (value != dateTime)
            {
                date = value;
                OnPropertyChanged("DateTime");
            }
        }
    }
    public String Time
    {
        get
        {
            return time;
        }
        set
        {
            if (value != time)
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
    }

    public double Duration
    {
        get
        {
            return duration;
        }
        set
        {
            if(value != duration)
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }
    }

    public int IdA
    {
        get
        {
            return idA;
        }
        set
        {
            if (value != idA)
            {
                idA = value;
                OnPropertyChanged("IdA");
            }
        }
    }

    public Patient Patient
    {
        get
        {
            return patient;
        }
        set
        {
            if (value != patient)
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }
    }

    public Doctor Doctor
    {
        get
        {
            return doctor;
        }
        set
        {
            if (value != doctor)
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }
    }

}