using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool canPickup = false;
    public bool hasEvent = false;
    private void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Item item = GetComponent<Item>();
            if(GetComponent<GoDWorld>() != null && GetComponent<GoDWorld>().CheckItem() == true)
            {
                GetComponent<GoDWorld>().Transfrom();
            }
            InventoryManager.Instance.AddItem(item);
        }
        //Debug.Log(InventoryManager.Instance.GetItemDetails(1004).canPickup);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果这是一个可以被捡起来的物体
        if (other.CompareTag("Player") && hasEvent == false)
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }

}
