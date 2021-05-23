
using Hospital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Appointment : Entity, INotifyPropertyChanged
{



    private DateTime date;
    private String time;
    private double duration;
  
    private Patient patient;
    private Doctor doctor;
    private Room room;
    private int idRoom;

    private DateTime dateTime;

    public Appointment() { }

    public Appointment(int id, DateTime dateTime, double v2, Doctor doctor, Patient patient) : base(id)
    {
       
        this.dateTime = dateTime;

        this.duration = v2;
        this.doctor = doctor;
        this.patient = patient;
    }

    public Appointment(int id, DateTime dateTime1, String tm, double v2, Doctor doctor, Patient patient) : base(id)
    {
        
        this.date = dateTime1;
        this.time = tm;
        this.duration = v2;
        this.doctor = doctor;
        this.patient = patient;
        

    }

    public Appointment(int id, DateTime dateTime, double v2, Doctor doctor, Patient patient, int roomId) : base(id)
    {
       
        this.dateTime = dateTime;

        this.duration = v2;
        this.doctor = doctor;
        this.patient = patient;
        this.idRoom = roomId;
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