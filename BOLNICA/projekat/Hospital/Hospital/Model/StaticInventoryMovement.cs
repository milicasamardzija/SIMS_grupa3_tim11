﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class StaticInventoryMovement
    {
        private int roomInId;
        private int roomOutId;
        private int inventoryId;
        private int quantity;
        private DateTime date;

        public StaticInventoryMovement (int idIn, int idOut, int idInv, int q, DateTime d)
        {
            roomInId = idIn;
            roomOutId = idOut;
            inventoryId = idInv;
            quantity = q;
            date = d;
        }

        public int RoomInId
        {
            get
            { 
                return roomInId; 
            }
            set {
                roomInId = value; 
            }
        }

        public int RoomOutId
        {
            get
            {
                return roomOutId;
            }
            set
            {
                roomOutId = value;
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
                inventoryId = value;
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

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
    }
}