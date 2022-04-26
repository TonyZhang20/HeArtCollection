using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBackpack : MonoBehaviour
{
    private GameObject InventoryCanvas;
    private void OnEnable() 
    {
        EventHandler.AfterSceneLoadEvent += FindInventoryCanvas;
    }

    private void OnDisable() 
    {
        EventHandler.AfterSceneLoadEvent -= FindInventoryCanvas;
    }

    private void FindInventoryCanvas()
    {
        InventoryCanvas = GameObject.FindGameObjectWithTag("PlayerBag");
    }

    public void OpenBag()
    {
        InventoryCanvas.GetComponent<MenuControl>().menu.SetActive(true);
    }
}
