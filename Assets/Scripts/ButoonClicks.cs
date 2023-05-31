using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShopInventory;

public class ButoonClicks : MonoBehaviour
{
    public BackpackInventory backpackInventory;
    public ShopItem shopItem;
    public void OnPurchaseButtonClicked()
    {
        if (backpackInventory.AddItem(shopItem))
        {

            Debug.Log("succesfully added");
            // Item was successfully added to the backpack inventory
            // Perform any additional logic or UI updates if needed
        }
        else
        {
            // Backpack is full, handle accordingly
        }
    }
}
