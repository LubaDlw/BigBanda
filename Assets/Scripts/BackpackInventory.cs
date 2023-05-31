using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class BackpackInventory : MonoBehaviour
{
    public BackpackInventory backpackInventory;
    public int maxItems = 10;
    public int maxBackpackCapacity = 20; // Maximum capacity of the backpack

    public List<ShopInventory.ShopItem> backpackItems;
    public List<ShopInventory.ShopItem> shopItems;


    public Transform backpackPanel;
    public GameObject backpackSlotPrefab;
    public ChestInventory chestInventory;
    public ShopInventory shopInventory;

    public Transform chestPanel;
    public GameObject chestSlotPrefab;

    public bool isFull;


    private void Start()
    {
        shopInventory = GetComponent<ShopInventory>();
        isFull = backpackItems.Count >= maxItems;

        CreateBackpackSlots();
    }

    private void CreateBackpackSlots()
    {
        foreach (ShopInventory.ShopItem item in backpackItems)
        {
            Debug.Log("Creating backpack Slots");
            CreateBackpackSlot(item);
        }
    }

    public bool AddItem(ShopInventory.ShopItem item)
    {
        if (backpackItems.Count < maxItems)
        {
            isFull = false;
            ShopInventory.ShopItem newItem = new ShopInventory.ShopItem
            {
                itemName = item.itemName,
                itemPrice = item.itemPrice,
                itemAmount = 1,
                itemImage = item.itemImage
            };

            backpackItems.Add(newItem);
            CreateBackpackSlot(newItem);

            return true;
        }
        else
        {
            isFull = backpackItems.Count >= maxItems; // Update the isFull flag
            Debug.Log("Backpack is full. Cannot add more items.");
            return false;
        }
    }
    // Function to remove an item from the backpack inventory
    public void RemoveItem(ShopInventory.ShopItem item)
    {
        if (backpackItems.Contains(item))
        {
            backpackItems.Remove(item);

            // Find the corresponding backpack slot and destroy it
            foreach (Transform slotTransform in backpackPanel)
            {
                BackpackSlotUI slotUI = slotTransform.GetComponent<BackpackSlotUI>();
                if (slotUI != null && slotUI.nameText.text == item.itemName)
                {
                    Destroy(slotTransform.gameObject);
                    break;
                }
            }
        }
        else
        {
            Debug.Log("Item " + item.itemName + " not found in the backpack inventory.");
        }
    }





    public void CreateBackpackSlot(ShopInventory.ShopItem item)
    {
        GameObject slot = Instantiate(backpackSlotPrefab, backpackPanel.transform);
        BackpackSlotUI slotUI = slot.GetComponent<BackpackSlotUI>();

        slotUI.nameText.text = item.itemName;
        slotUI.amountText.text = item.itemAmount.ToString();
        slotUI.itemImage.sprite = item.itemImage;
        slotUI.sellButton.onClick.AddListener(() => SellItem(item, slotUI));
        slotUI.chestButton.onClick.AddListener(() => MoveToChest(item));


        Debug.Log("Created backpack slot: " + item.itemName);
    }

    public void SellItem(ShopInventory.ShopItem item, BackpackSlotUI slotUI)
    {
        if (item.itemAmount > 0)
        {
            item.itemAmount--;
            slotUI.amountText.text = item.itemAmount.ToString();
            Debug.Log("Sold " + item.itemName);

            if (item.itemAmount == 0)
            {
                Destroy(slotUI.gameObject);
                backpackItems.Remove(item);
            }

            // Increase the item amount in the shop inventory
            ShopInventory shopInventory = GameObject.FindObjectOfType<ShopInventory>();
            ShopInventory.ShopItem shopItem = shopInventory.shopItems.Find(i => i.itemName == item.itemName);
            if (shopItem != null)
            {
                Debug.Log("adding back to shopItem");
                shopItem.itemAmount++;
                shopInventory.UpdateItemAmountText(shopItem); // Update the item amount text in the shop UI
            }

            // Increase the player's currency when an item is sold
            shopInventory.currentCurrency += item.itemPrice;
            shopInventory.UpdateCurrencyText();
            isFull = backpackItems.Count >= maxItems; // Update the isFull flag

            shopInventory = FindObjectOfType<ShopInventory>();
            if (!isFull)
            {
                foreach (Transform slotTransform in shopInventory.shopPanel)
                {
                    Button buyButton = slotTransform.Find("BuyButton").GetComponent<Button>();
                    buyButton.interactable = true;
                }
            }
        

    }
        else
        {
            Debug.Log("There is nothing to sell for " + item.itemName);
        }
    }

    // Function to move an item from the backpack to the chest
    public void MoveToChest(ShopInventory.ShopItem item)
    {
        if (backpackItems.Contains(item))
        {
            if (chestInventory.AddItem(item))
            {
                RemoveItem(item); // Remove the item from the backpack inventory

                // Create a new chest slot for the item
                GameObject slot = Instantiate(chestSlotPrefab, chestPanel.transform);
                ChestSlotUI slotUI = slot.GetComponent<ChestSlotUI>();
                slotUI.SetupItem(item, this, chestInventory);
            }
        }
        else
        {
            Debug.Log("Item " + item.itemName + " not found in the backpack inventory.");
        }
    }

    // Function to move an item from the chest to the backpack
    public void MoveToBackpack(ShopInventory.ShopItem item)
    {
        if (chestInventory.GetChestItems().Contains(item))
        {
            if (AddItem(item))
            {
                chestInventory.RemoveItem(item);
            }
        }
        else
        {
            Debug.Log("Item " + item.itemName + " not found in the chest inventory.");
        }
    }

    public void OnMoveToChestButtonClicked(ShopInventory.ShopItem item)
    {
        backpackInventory.MoveToChest(item);
        Debug.Log("Moving to Chest");
    }

    public void UpgradeBackpackCapacity(int newCapacity)
    {
        maxItems = newCapacity;
        Debug.Log("Upgraded backpack capacity to: " + newCapacity);
    }

    
}


