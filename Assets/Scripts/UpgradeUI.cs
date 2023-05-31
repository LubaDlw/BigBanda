using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public ShopSystem shopSystem;

    public Button backpackUpgradeButton;
    public Button chestUpgradeButton;
    int newCapacity, upgradeCost;

    private void Start()
    {

         

        // Add click listeners to the upgrade buttons
        backpackUpgradeButton.onClick.AddListener(UpgradeBackpack);
        chestUpgradeButton.onClick.AddListener(UpgradeChest);
    }

    private void Update()
    {
        // Update the button interactability based on the upgrade conditions
        backpackUpgradeButton.interactable = shopSystem.CanPurchaseBackpackUpgrade();
        chestUpgradeButton.interactable = shopSystem.CanPurchaseChestUpgrade();
    }

    private void UpgradeBackpack()
    {
        shopSystem.UpgradeBackpackCapacity();
    }

    private void UpgradeChest()
    {
        shopSystem.UpgradeChestCapacity();
    }
}
