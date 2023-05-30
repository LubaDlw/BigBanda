using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackSlot : MonoBehaviour
 {    public Backpack backpack;
    public int slotIndex;

    public Button sellButton;
    // Start is called before the first frame update
    private void Start()
    {
        sellButton = GetComponent<Button>();
        sellButton.onClick.AddListener(SellItem);
    }

    public void SellItem()
    {
        backpack.SellItem(slotIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
    