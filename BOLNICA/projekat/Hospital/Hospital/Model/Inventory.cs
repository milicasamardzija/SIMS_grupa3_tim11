// File:    Inventory.cs
// Author:  Milica
// Created: Thursday, March 25, 2021 5:41:04 PM
// Purpose: Definition of Class Inventory

using System;

public class Inventory
{
   public int id;
   public String name;
   public int quantity;
   public InventoryType type;
   
   public System.Collections.Generic.List<RoomInventory> roomInventory;
   
   /// <summary>
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
   }

}