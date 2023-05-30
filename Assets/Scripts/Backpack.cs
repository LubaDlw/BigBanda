using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public GameObject backpackPanel;
    public int maxBackpackSize;
    public List<ShopItemSO> backpackItems;
    public int coins;
    

  
    public void AddItem(ShopItemSO item)
    {
        if(backpackItems.Count < maxBackpackSize)
        {
            backpackItems.Add(item);
            Debug.Log("Added item to backpack: : " + item.title);
        }
        else
        {
            Debug.Log("Backpack is full");
        }
    }

    public void SellItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < backpackItems.Count)
        {
            ShopItemSO soldItem = backpackItems[slotIndex];
            int itemCost = CalculateItemValue(soldItem);
            coins += itemCost;

            backpackItems.RemoveAt(slotIndex);
            for (int i = slotIndex; i < backpackItems.Count - 1; i++)
            {
                backpackItems[i] = backpackItems[i + 1];
            }
            backpackItems[backpackItems.Count - 1] = null;

            Debug.Log("Sold Item: " + soldItem.title  + "for" + itemCost + "coins");
        }
        else
        {
            Debug.LogError("Invalid slot index");
        }

      }
    

    private int CalculateItemValue(ShopItemSO item)
    {
        return item.itemCost;
    }
    public void RemoveItem(int itemIndex)
    {
        backpackItems.RemoveAt(itemIndex);
        Debug.Log("Removed Item from backpack");
    }

  
}
