using Newtonsoft.Json;
using System;
using Hospital.Model;

public class RoomInventory : Entity
{
    private int idRoom;
    private int idInventory;
    private int quantity;
    private Room room;
    private Inventory inventory;

    public RoomInventory() { }

    public RoomInventory(int id, int idRoom, Room room, int idInventory, Inventory inventory, int quantity) : base(id)
    {
        this.idRoom = idRoom;
        this.room = room;
        this.idInventory = idInventory;
        this.inventory = inventory;
        this.quantity = quantity;
    }

    public RoomInventory(int id, int idRoomIn, int inventoryId, int quantity) : base(id)
    {
        this.IdRoom = idRoomIn;
        this.IdInventory = inventoryId;
        this.Quantity = quantity;
    }

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
}