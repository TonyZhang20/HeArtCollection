using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    private GameObject pickCanvas;
    private Transform image;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += GetPickupCanvas;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= GetPickupCanvas;
    }

    private void GetPickupCanvas()
    {
        pickCanvas = GameObject.FindGameObjectWithTag("PickupCanvas");
        image = pickCanvas.transform.Find("PressE");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.CompareTag("Player"))
        {
            image.gameObject.SetActive(true);
            pickCanvas.GetComponent<RectTransform>().position = new Vector3(transform.position.x, transform.position.y + Settings.pickupCanvasYvalue, transform.position.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Item item = other.GetComponent<Item>();

        //说明这是一个可以被捡起来的物品
        if (item != null)
        {
            if (item.itemDetails.canPickup && Input.GetKeyDown(KeyCode.E))
            {
                //pick up items
                InventoryManager.Instance.AddItem(item);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            image.gameObject.SetActive(false);
            pickCanvas.GetComponent<RectTransform>().position = new Vector3(transform.position.x, transform.position.y + Settings.pickupCanvasYvalue, transform.position.z);
        }
    }


}
