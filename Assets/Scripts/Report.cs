using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    public Item item;

    public void AddToBag()
    {
        InventoryManager.Instance.AddItem(item);
        GameObject.FindGameObjectWithTag("DialoageCanvas").GetComponent<DialogueUI>().ShowPanel("你获得了一份检查报告");
    }
}
