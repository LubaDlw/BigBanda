using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "shopMenu", menuName = "scriptable objects/New Shop Item", order = 1)]

public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int itemCost;
    public Image image;
    public Sprite icon;

    //  public GameObject itemPrefab; // prefab of purchased item


}
