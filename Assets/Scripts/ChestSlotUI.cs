using UnityEngine;
using UnityEngine.UI;

public class ChestSlotUI : MonoBehaviour
{
    public Text nameText;
    public Text amountText;
    public Image itemImage;
    public Button moveButton;

    private ShopInventory.ShopItem item;

    public void SetupItem(ShopInventory.ShopItem item, BackpackInventory backpackInventory, ChestInventory chestInventory)
    {
        this.item = item;
        nameText.text = item.itemName;
        amountText.text = item.itemAmount.ToString();
        itemImage.sprite = item.itemImage;
        moveButton.onClick.AddListener(() => MoveToBackpack(backpackInventory, chestInventory));
    }

    private void MoveToBackpack(BackpackInventory backpackInventory, ChestInventory chestInventory)
    {
        chestInventory.RemoveItem(item);
        backpackInventory.AddItem(item);
        Destroy(gameObject);
    }
}
