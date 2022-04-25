using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Item item = other.GetComponent<Item>();

        //如果这是一个可以被捡起来的物体
        if (item != null && other.CompareTag("Player"))
        {
            if (item.itemDetails.canPickup && Input.GetKeyDown(KeyCode.E))
            {
                //pick up items
                InventoryManager.Instance.AddItem(item);
            }
        }
    }
}
