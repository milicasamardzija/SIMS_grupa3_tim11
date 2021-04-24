using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Inventory : INotifyPropertyChanged
{
    private int inventoryId;
    private String name;
    private int quantity;
    private InventoryType type;

    public Inventory() { }

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
}