using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Inventory : Entity, INotifyPropertyChanged
{
    private String name;
    private int quantity;
    private InventoryType type;

    public Inventory() { }

    public Inventory(int id, String n, int q, InventoryType t) : base(id)
    {
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