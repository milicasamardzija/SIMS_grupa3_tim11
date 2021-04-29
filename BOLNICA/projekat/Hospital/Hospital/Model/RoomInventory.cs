using Newtonsoft.Json;
using System;

public class RoomInventory
{
    private Room room;
    public int idRoom { get; set; }
    private Inventory inventory;
    public int idInventory { get; set; }
    private int quantity;
    public DateTime date { get; set; }

    [JsonIgnore]
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

   [JsonIgnore]
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

    public RoomInventory(int idR, Room r, int idI, Inventory i, int q)
    {   
        idRoom = idR;
        room = r;
        idInventory = idI;
        inventory = i;
        quantity = q;
    }

}