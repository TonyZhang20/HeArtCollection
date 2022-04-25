using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemID;
    public string itemName;
    public ItemType itemType;
    public Sprite itemIcon;
    public Sprite itemOnWorldSprite;
    [TextArea]
    public string itemDescription;
    public bool canPickup = true;
    public bool canDrop;
    public int itemPrice;

}

[System.Serializable]
public struct InventoryItem
{
    public int itemID;
    public int itemAmount;
}