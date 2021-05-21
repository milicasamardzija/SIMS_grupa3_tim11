using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Room : Entity, INotifyPropertyChanged
{
   private int floor;
   private Boolean occupancy;
   private Purpose purpose;
   private int capacity;
 
    public Room() { }

    public Room(int id, int f, bool o, Purpose p, int c) : base(id)
    {
        floor = f;
        occupancy = o;
        purpose = p;
        capacity = c;
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnProperychanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public int Floor
    {
        get
        {
            return floor;
        }
        set
        {
            if(value != floor)
            {
                floor = value;
                OnProperychanged("Floor");
            }
        }
    }

    public bool Occupancy
    {
        get
        {
            return occupancy;
        }
        set
        {
            if (value != occupancy)
            {
                occupancy = value;
                OnProperychanged("Occupancy");
            }
        }
    }

    public Purpose Purpose
    {
        get
        {
            return purpose;
        }
        set
        {
            if (value != purpose)
            {
                purpose = value;
                OnProperychanged("Purpose");
            }
        }
    }

    public int Capacity
    {
        get
        {
            return capacity;
        }
        set
        {
            if(value != capacity)
            {
                capacity = value;
                OnProperychanged("Capacity");
            }
        }
    }
}
