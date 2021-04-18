// File:    Room.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 2:37:12 PM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Room : INotifyPropertChanged
{
   private int roomId;
   private int floor;
   private Boolean occupancy;
   private Purpose purpose;
   private int capacity;
   
   public System.Collections.Generic.List<RoomInventory> roomInventory;

   public Room() { }

    public Room(int id, int f, bool o, Purpose p, int c)
    {
        roomId = id;
        floor = f;
        occupancy = o;
        purpose = p;
        capacity = c;
        roomInventory = new List<RoomInventory>();
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnProperychanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
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
                OnProperychanged("RoomId");
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
