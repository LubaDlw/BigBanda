using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour
{
    public int maxItems = 20; // Maximum number of items in the chest
    //public int maxChestCapity = 99;


    private List<ShopInventory.ShopItem> chestItems = new List<ShopInventory.ShopItem>(); // List to store the items in the chest

    // Function to add an item to the chest inventory
    public bool AddItem(ShopInventory.ShopItem item)
    {
        if (chestItems.Count < maxItems)
        {
            chestItems.Add(item);
            return true;
        }
        else
        {
            Debug.Log("Chest is full. Cannot add " + item.itemName + " to the chest inventory.");
            return false;
        }
    }

    // Function to remove an item from the chest inventory
    public void RemoveItem(ShopInventory.ShopItem item)
    {
        if (chestItems.Contains(item))
        {
            chestItems.Remove(item);
        }
        else
        {
            Debug.Log("Item " + item.itemName + " not found in the chest inventory.");
        }
    }

    // Function to check if the chest inventory is full
    public bool IsFull()
    {
        return chestItems.Count >= maxItems;
    }

    // Function to get the list of items in the chest
    public List<ShopInventory.ShopItem> GetChestItems()
    {
        return chestItems;
    }

    public void UpgradeChestCapacity(int newCapacity)
    {
        maxItems = newCapacity;
        Debug.Log("Upgraded chest capacity to: " + newCapacity);
    }
}


