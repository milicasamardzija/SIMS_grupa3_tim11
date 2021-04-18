// File:    RoomInventory.cs
// Author:  Milica
// Created: Tuesday, April 13, 2021 3:17:07 PM
// Purpose: Definition of Class RoomInventory

public class RoomInventory
{
   public int roomId;
   public int inventoryId;
   public int quantity;

    public RoomInventory(int room, int inventoryId, int quantity)
    {
        this.roomId = room;
        this.inventoryId = inventoryId;
        this.quantity = quantity;
    }
}