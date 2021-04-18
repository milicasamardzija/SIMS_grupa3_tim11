// File:    RoomInventory.cs
// Author:  Milica
// Created: Tuesday, April 13, 2021 3:17:07 PM
// Purpose: Definition of Class RoomInventory

using System;

public class RoomInventory
{
   public int roomId;
   public int inventoryId;
   public int quantity;

    public RoomInventory()
    {
    }

    public RoomInventory(int roomId, int inventoryId, int quantity)
    {
        this.roomId = roomId;
        this.inventoryId = inventoryId;
        this.quantity = quantity;
    }
}