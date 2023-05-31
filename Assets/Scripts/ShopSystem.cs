using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public BackpackInventory backpackInventory;
    public ChestInventory chestInventory;
    public ShopInventory shopInventory; 
    // Define the conditions and requirements for upgrading the backpack
    public int requiredItemsForBackpackUpgrade = 5;
    public int requiredMoneyForBackpackUpgrade = 100;

    // Define the conditions and requirements for upgrading the chest
    public int requiredItemsForChestUpgrade = 10;
    public int requiredMoneyForChestUpgrade = 200;

    //...

    // Function to check if the backpack upgrade can be purchased
    public bool CanPurchaseBackpackUpgrade()
    {
        // Check if the player meets the requirements
        bool hasEnoughItems = backpackInventory.backpackItems.Count >= requiredItemsForBackpackUpgrade;
        bool hasEnoughMoney = shopInventory.currentCurrency >= requiredMoneyForBackpackUpgrade;

        return hasEnoughItems && hasEnoughMoney;
    }

    // Function to check if the chest upgrade can be purchased
    public bool CanPurchaseChestUpgrade()
    {
        // Check if the player meets the requirements
        bool hasEnoughItems = backpackInventory.backpackItems.Count >= requiredItemsForChestUpgrade;
        bool hasEnoughMoney = shopInventory.currentCurrency >= requiredMoneyForChestUpgrade;

        return hasEnoughItems && hasEnoughMoney;
    }

    // Function to upgrade the backpack capacity
    public void UpgradeBackpackCapacity()
    {
        if (CanPurchaseBackpackUpgrade())
        {
            backpackInventory.UpgradeBackpackCapacity(20); // Example: Increase backpack capacity to 20
            shopInventory.currentCurrency -= requiredMoneyForBackpackUpgrade;

            
            // Update UI or perform any other necessary actions after the upgrade
        }
        else
        {
            Debug.Log("Cannot purchase backpack upgrade. Insufficient items or money.");
        }
    }

    // Function to upgrade the chest capacity
    public void UpgradeChestCapacity()
    {
        if (CanPurchaseChestUpgrade())
        {
            chestInventory.UpgradeChestCapacity(90); // Example: Upgrade chest to infinite capacity
            shopInventory.currentCurrency -= requiredMoneyForChestUpgrade;
            // Update UI or perform any other necessary actions after the upgrade
        }
        else
        {
            Debug.Log("Cannot purchase chest upgrade. Insufficient items or money.");
        }
    }

    //...
}
