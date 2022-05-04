using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Inventory/InventoryBag_SO")]
public class InventoryBag_SO : ScriptableObject
{
    public List<InventoryItem> itemList;

    public bool hasItem(int itemID)
    {
        foreach (var item in itemList)
        {
            if (item.itemID == itemID)
                return true;
        }
        return false;
    }
}
