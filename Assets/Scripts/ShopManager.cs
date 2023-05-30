using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public TMP_Text TextBanner;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public int maxBackpackSize; // Capacity of backpack
    public GameObject IInventorySlot;
    public GameObject GridBackPack;

    // Additonal

    private float itemIncrementDelay = 5f; // time between new items being added to shop
    public float itemIncrementAmount = 1; // Items added each time
    private float nextItemIncrementTime;



    private List<ShopItemSO> backpackItems = new List<ShopItemSO>();

    public List<ShopItemSO> GetBackpackItems()
    {
        return backpackItems;
    }

    public int GetBackpackCount()
    {
        return backpackItems.Count;
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);

        coins = 100; // initial coin amount
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();

      //  nextItemIncrementTime = Time.time = itemIncrementDelay;



    }

    // Update is called once per frame
    void Update()
    {
       /* if (Time.time >= nextItemIncrementTime )
        {
            IncrementShopItems(itemIncrementAmount);
            nextItemIncrementTime = Time.time + itemIncrementDelay;
        }
            */
    }


    public void FilterShopItems(string filter)
    {
        List<ShopItemSO> filteredItems = new List<ShopItemSO>();

        foreach (ShopItemSO item in shopItemsSO)
        {
            if (item.description == filter)
            {
                filteredItems.Add(item);
            }
        

    }
        LoadPanels(filteredItems.ToArray());
    }

    private void LoadPanels(ShopItemSO[] shopItemSOs)
    {
        throw new NotImplementedException();
    }

    public void AddCoins()
    {

        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].itemCost) // this checks if there is money for purchase
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if
            (coins >= shopItemsSO[btnNo].itemCost)
        {
            coins -= shopItemsSO[btnNo].itemCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();

            // add items to backpack

            if (backpackItems.Count < 5) // maxBackpackSize
            {
                backpackItems.Add(shopItemsSO[btnNo]);
                Debug.Log("Purchased item: " + shopItemsSO[btnNo].title);

                // Instantiate New Slot to create slot in backpack

                GameObject newSlot = Instantiate(IInventorySlot, GridBackPack.transform);
                IInventorySlot slot = newSlot.GetComponent<IInventorySlot>();
                slot.UpdateIInventorySlot(shopItemsSO[btnNo]);
            }
            else
            {
                Debug.Log("Backpack is full. No more items can be added");


            }

            


        }
       // myPurchaseBtns[btnNo].onClick.AddListener(() => SellItemFromBackpack(btnNo));
    }

    public void SellItem(int itemIndex)
    {
        ShopItemSO item = backpackItems[itemIndex];
        coins += item.itemCost;
        coinUI.text = "Coins: " + coins.ToString();

        // remove

       Destroy(GridBackPack.transform.GetChild(itemIndex).gameObject);
        backpackItems.RemoveAt(itemIndex);


        

    }



    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)

        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].itemCost.ToString();

            shopPanels[i].sellButton.onClick.AddListener(() => SellItemFromBackpack(i));

           /* for (int i = 0; i < items.Length; i++)
            {
               
            }
           */
        }
    }

   public void SellItemFromBackpack(int itemIndex)
    {
        SellItem(itemIndex);
    }
}
   