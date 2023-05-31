using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [System.Serializable]
    class ShopItem
    {
        public Sprite image;
        public int price;
        public bool IsPurchased = false;

    }

    [SerializeField] List<ShopItem> ShopItems;
    [SerializeField] Animator NoMoney;
    [SerializeField] Text MoneyText;

    GameObject ItemTemplate;
    GameObject g;

    [SerializeField]
    Transform ShopScrollView;
        [SerializeField] Transform inventorySlotsPanel; // Reference to the inventory slots panel


    Button Buybtn;

    List<ShopItem> purchasedItems = new List<ShopItem>();


    private void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItems.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItems[i].image;
            g.transform.GetChild(1).GetComponent<Text>().text = ShopItems[i].price.ToString();
            Buybtn = g.transform.GetChild(2).GetComponent<Button>();
            Buybtn.interactable = !ShopItems[i].IsPurchased;
            Buybtn.AddEventListener(i, OnShopItemBtnClicked);
        }

        Destroy(ItemTemplate);

        //change UI text: coins
        SetCoinsUI();
    }
    void OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins(ShopItems[itemIndex].price))
        {
            Game.Instance.UseCoins(ShopItems[itemIndex].price);
            //purchase item
            ShopItems[itemIndex].IsPurchased = true;

            //disable the button
            Buybtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            Buybtn.interactable = false;
            Buybtn.transform.GetChild(0).GetComponent<Text>().text = "Bought";

            //change UI text: coins
            SetCoinsUI();

            AddItemToInventory(ShopItems[itemIndex].image);
            purchasedItems.Add(ShopItems[itemIndex]);
        }
        else
        {
            NoMoney.SetTrigger("NoMoney");
            Debug.Log("you dont have enough coins");
        }

      

    }

    void AddItemToInventory(Sprite itemImage)
    {
        // Create a new inventory slot
        GameObject inventorySlot = new GameObject("InventorySlot");
        inventorySlot.transform.SetParent(inventorySlotsPanel, false);

        // Add an image component to the inventory slot and set its sprite
        Image image = inventorySlot.AddComponent<Image>();
        image.sprite = itemImage;

        // Create a ShopItem object and add it to the purchasedItems list
        ShopItem item = new ShopItem();
        item.image = itemImage;
        purchasedItems.Add(item);
    }

    /*_________________________shop coins UI___________________________________*/

    private void SetCoinsUI()
    {
        MoneyText.text = Game.Instance.coins.ToString();
    }

    /*_________________________open and close inventory________________________________________________*/

    public void OpenInventory()
    {
        gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }

}