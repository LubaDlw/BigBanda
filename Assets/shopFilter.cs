using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopFilter : MonoBehaviour
{
   public TMP_Dropdown filterDropdown;
    public ShopManager shopManager;

    private void Start()
    {
        filterDropdown.onValueChanged.AddListener(OnFilterChanged);
    }

    private void OnFilterChanged(int filterIndex)
    {
        // Get the selected filter option from the dropdown
        string selectedFilter = filterDropdown.options[filterIndex].text;

        // Call the filtering function in the ShopManager script
        shopManager.FilterShopItems(selectedFilter);
    }
}