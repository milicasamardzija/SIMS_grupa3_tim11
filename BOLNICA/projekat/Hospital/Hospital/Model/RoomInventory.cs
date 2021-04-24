using System;

public class RoomInventory
{
    private Room room;
    private Inventory inventory;
    private int quantity;

    public Room Room
    {
        get
        {
            return room;
        }
        set
        {
            room = value;
        }
    }

    public Inventory Inventory
    {
        get
        {
            return inventory;
        }
        set
        {
            inventory = value;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            quantity = value;
        }
    }

    public RoomInventory() { }

    public RoomInventory(Room r, Inventory i, int q)
    {
        room = r;
        inventory = i;
        quantity = q;
    }

}