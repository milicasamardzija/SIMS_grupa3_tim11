// File:    Inventory.cs
// Author:  Milica
// Created: Thursday, March 25, 2021 5:41:04 PM
// Purpose: Definition of Class Inventory

using System;
using System.ComponentModel;

public class Inventory : INotifyPropertChanged
{
    public int inventoryId;
    public String name;
    public int quantity;
    public InventoryType type;

    public System.Collections.Generic.List<RoomInventory> roomInventory;

   // public Inventory() { }

    public Inventory(int id, String n, int q, InventoryType t)
    {
        inventoryId = id;
        name = n;
        quantity = q;
        type = t;

    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnProperychanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public int InventoryId
    {
        get
        {
            return inventoryId;
        }
        set
        {
            if (value != inventoryId)
            {
                inventoryId = value;
                OnProperychanged("InventoryId");
            }
        }
    }

    public String Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value != name)
            {
                name = value;
                OnProperychanged("Name");
            }
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
            if (value != quantity)
            {
                quantity = value;
                OnProperychanged("Quantity");
            }
        }
    }

    public InventoryType Type
    {
        get
        {
            return type;
        }
        set
        {
            if (value != type)
            {
                type = value;
                OnProperychanged("Type");
            }
        }
    }

    /*/// <summary>
    /// Property for collection of RoomInventory
    /// </summary>
    /// <pdGenerated>Default opposite class collection property</pdGenerated>
    public System.Collections.Generic.List<RoomInventory> RoomInventory
    {
       get
       {
          if (roomInventory == null)
             roomInventory = new System.Collections.Generic.List<RoomInventory>();
          return roomInventory;
       }
       set
       {
          RemoveAllRoomInventory();
          if (value != null)
          {
             foreach (RoomInventory oRoomInventory in value)
                AddRoomInventory(oRoomInventory);
          }
       }
    }

    /// <summary>
    /// Add a new RoomInventory in the collection
    /// </summary>
    /// <pdGenerated>Default Add</pdGenerated>
    public void AddRoomInventory(RoomInventory newRoomInventory)
    {
       if (newRoomInventory == null)
          return;
       if (this.roomInventory == null)
          this.roomInventory = new System.Collections.Generic.List<RoomInventory>();
       if (!this.roomInventory.Contains(newRoomInventory))
          this.roomInventory.Add(newRoomInventory);
    }

    /// <summary>
    /// Remove an existing RoomInventory from the collection
    /// </summary>
    /// <pdGenerated>Default Remove</pdGenerated>
    public void RemoveRoomInventory(RoomInventory oldRoomInventory)
    {
       if (oldRoomInventory == null)
          return;
       if (this.roomInventory != null)
          if (this.roomInventory.Contains(oldRoomInventory))
             this.roomInventory.Remove(oldRoomInventory);
    }

    /// <summary>
    /// Remove all instances of RoomInventory from the collection
    /// </summary>
    /// <pdGenerated>Default removeAll</pdGenerated>
    public void RemoveAllRoomInventory()
    {
       if (roomInventory != null)
          roomInventory.Clear();
    }*/

}