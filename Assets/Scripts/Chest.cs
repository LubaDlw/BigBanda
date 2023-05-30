using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<ShopItemSO> chestItems;

    public void AddItem(ShopItemSO item)
    {
        chestItems.Add(item);
        Debug.Log("Added item to chest: " + item.title);
    }

    public void RemoveItem(int itemIndex)
    {
        chestItems.RemoveAt(itemIndex);
        Debug.Log(" Removed Item from chest. ");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
