// File:    Room.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 2:37:12 PM
// Purpose: Definition of Class Room

using System;

public class Room
{
   public int roomId { get; set; }
   public int floor { get; set; }
   public Boolean occupancy { get; set; }
   public Purpose purpose { get; set; }
   public int capacity { get; set; }
   

    public Room(int v1, int v2, bool v3, Purpose p, int v4)
    {
        this.roomId = v1;
        this.floor = v2;
        this.occupancy = v3;
        this.purpose = p;
        this.capacity = v4;
    }
}