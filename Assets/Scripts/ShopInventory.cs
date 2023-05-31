using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventory : MonoBehaviour
{
    public int startingCurrency = 100;
    public BackpackInventory backpackInventory;
    public BackpackSlotUI backpackSlot;
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public string itemDescription;
        public int itemPrice;
        public int itemAmount;
        public Sprite itemImage;
    }

    public List<ShopItem> shopItems;
    public Text currencyText;
    public Transform shopPanel;
    public GameObject slotPrefab;

    public int currentCurrency;

    private void Start()
    {
        currentCurrency = startingCurrency;
        UpdateCurrencyText();
        CreateShopSlots();
    }

    private void Awake()
    {
        backpackInventory = FindObjectOfType<BackpackInventory>();
    }

    public void CreateShopSlots()
    {
        foreach (ShopItem item in shopItems)
        {
            GameObject slot = Instantiate(slotPrefab, shopPanel);
            Text itemNameText = slot.transform.Find("ItemName").GetComponent<Text>();
            Text itemDescription = slot.transform.Find("ItemDescription").GetComponent<Text>();
            Text itemPriceText = slot.transform.Find("ItemPrice").GetComponent<Text>();
            Text itemAmountText = slot.transform.Find("ItemAmountHolder").GetChild(0).GetComponent<Text>();
            Image itemImage = slot.transform.Find("ItemImage").GetComponent<Image>();
            Button buyButton = slot.transform.Find("BuyButton").GetComponent<Button>();
            buyButton.interactable = !backpackInventory.isFull;

            itemNameText.text = item.itemName;
            itemDescription.text = item.itemDescription;
            itemPriceText.text = "$" + item.itemPrice.ToString();
            itemAmountText.text = item.itemAmount.ToString();
            itemImage.sprite = item.itemImage;

            buyButton.onClick.AddListener(() => OnPurchaseButtonClicked(item, itemAmountText));
        }
    }

    public void UpdateCurrencyText()
    {
        currencyText.text = "$" + currentCurrency.ToString();
    }

    public void OnPurchaseButtonClicked(ShopItem item, Text itemAmountText)
    {
        if (!backpackInventory.isFull && currentCurrency >= item.itemPrice && item.itemAmount > 0)
        {
            currentCurrency -= item.itemPrice;
            item.itemAmount--;
            UpdateCurrencyText();
            itemAmountText.text = item.itemAmount.ToString();
            Debug.Log("Purchased item: " + item.itemName);

            if (backpackInventory.AddItem(item))
            {
                Debug.Log("Added " + item.itemName + " to the backpack inventory.");
            }
            else
            {
                Debug.Log("Backpack is full. Cannot add " + item.itemName + " to the backpack inventory.");
            }
        }
        else
        {
            Debug.Log("Insufficient funds or item out of stock.");
        }
    }

    public void UpdateItemAmountText(ShopItem item)
    {
        foreach (Transform slotTransform in shopPanel)
        {
            Text itemAmountText = slotTransform.Find("ItemAmountHolder").GetChild(0).GetComponent<Text>();
            if (itemAmountText != null && slotTransform.name == item.itemName)
            {
                itemAmountText.text = item.itemAmount.ToString();
                break;
            }
        }
    }

}
