using Newtonsoft.Json;
using System;

public class RoomInventory
{
    private int idRoom;
    private int idInventory;
    private int quantity;
    private Room room;
    private Inventory inventory;

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

    public int IdRoom
    {
        get
        {
            return idRoom;
        }
        set
        {
            idRoom = value;
        }
    }

    public int IdInventory
    {
        get
        {
            return idInventory;
        }
        set
        {
            idInventory = value;
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

    public RoomInventory(int idRoomIn, int inventoryId, int quantity)
    {
        this.IdRoom = idRoomIn;
        this.IdInventory = inventoryId;
        this.Quantity = quantity;
    }
}