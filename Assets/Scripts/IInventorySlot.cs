using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class IInventorySlot : MonoBehaviour, IDropHandler

{
    public Image iconImage;
    public TMP_Text titleTxt;
    public TMP_Text descriptionTxt;
    public TMP_Text costTxt;
    public TMP_Text quantityTxt;

    private ShopItemSO currentItem;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }

    public void UpdateIInventorySlot(ShopItemSO item)
    {
        currentItem = item;
        iconImage.sprite = item.icon;
        titleTxt.text = item.title;
        descriptionTxt.text = item.description;
        quantityTxt.text = "x1";

        Debug.Log("Updating inventory slot: " + item.title);
    }


}
