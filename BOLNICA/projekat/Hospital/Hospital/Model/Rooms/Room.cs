using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Room : Entity
{
   private int floor;
   private Boolean occupancy;
   private Purpose purpose;
   private int capacity;
 
    public Room() { }

    public Room(int id, int floor, bool ocuupancy, Purpose purpose, int capacity) : base(id)
    {
        this.floor = floor;
        this.occupancy = ocuupancy;
        this.purpose = purpose;
        this.capacity = capacity;
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
            }
        }
    }
}
