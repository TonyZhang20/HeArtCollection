using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private GameObject shopCanvas;
    private bool canShopping = false;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += loadShopCanvas;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= loadShopCanvas;
    }

    private void loadShopCanvas()
    {
        shopCanvas = GameObject.FindGameObjectWithTag("Canteen");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canShopping = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canShopping = false;
        }
    }

    private void Update()
    {
        //Open and Close Shop Canvas
        if (canShopping)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                shopCanvas.transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = true;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                shopCanvas.transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = false;
            }

        }
    }

}
