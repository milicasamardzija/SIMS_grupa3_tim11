// File:    Room.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 2:37:12 PM
// Purpose: Definition of Class Room

using System;
using System.ComponentModel;

public class Room : INotifyPropertyChanged
{
    public int roomId;
    public int floor;
    public Boolean occupancy;
    public Purpose purpose;
    public int capacity;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public Room() { }

    public Room(int v1, int v2, bool v3, Purpose p, int v4)
    {
        this.roomId = v1;
        this.floor = v2;
        this.occupancy = v3;
        this.purpose = p;
        this.capacity = v4;
    }

    public int RoomId
    {
        get
        {
            return roomId;
        }
        set
        {
            if (value != roomId)
            {
                roomId = value;
                OnPropertyChanged("RoomId");
            }
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
            if (value != floor)
            {
                floor = value;
                OnPropertyChanged("Floor");
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
                OnPropertyChanged("Purpose");
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
            if (value != capacity)
            {
                capacity = value;
                OnPropertyChanged("Capacity");
            }
        }
    }
}