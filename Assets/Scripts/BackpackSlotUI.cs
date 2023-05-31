using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ShopInventory;
using static UnityEditor.Progress;


public class BackpackSlotUI : MonoBehaviour

{
    public BackpackInventory backpackInventory;
    public ShopInventory shopInventory;
    public ShopItem item;

    public Text nameText;
    public Text amountText;
    public Image itemImage;
    public Button sellButton;
    public Button chestButton;

    public void MoveToParent(Transform newParent)
    {
        transform.SetParent(newParent);
    }

    public void MoveToChest()
    {
        backpackInventory.MoveToChest(item);
    }


}
