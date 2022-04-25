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

<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.CompareTag("Player"))
=======
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetComponent<Item>() == null)
>>>>>>> Stashed changes
        {
            image.gameObject.SetActive(true);
            pickCanvas.GetComponent<RectTransform>().position = new Vector3(transform.position.x, transform.position.y + Settings.pickupCanvasYvalue, transform.position.z);
        }
<<<<<<< Updated upstream
=======
        else if (other.gameObject.CompareTag("Player") && other.GetComponent<Item>() != null)
        {
            if (other.gameObject.GetComponent<DialogueController>().canTalk)
            {
                image.gameObject.SetActive(other.gameObject.GetComponent<DialogueController>().canTalk);
                pickCanvas.GetComponent<RectTransform>().position = new Vector3(transform.position.x, transform.position.y + Settings.pickupCanvasYvalue, transform.position.z);
            }
        }
>>>>>>> Stashed changes
    }

    private void OnTriggerStay(Collider other)
    {
        Item item = other.GetComponent<Item>();

<<<<<<< Updated upstream
        //说明这是一个可以被捡起来的物品
        if (item != null)
=======
        //濡傛灉杩欐槸涓�涓彲浠ヨ鎹¤捣鏉ョ殑鐗╀綋
        if (item != null && other.CompareTag("Player"))
>>>>>>> Stashed changes
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
