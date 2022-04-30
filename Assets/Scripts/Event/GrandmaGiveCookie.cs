using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaGiveCookie : MonoBehaviour
{

    public int itemID;
    private Item item;
    public void GiveCookie()
    {

        foreach(var item in FindObjectsOfType<Item>())
        {
            if(item.itemID == itemID)
            {
                this.item = item;
            }
        }

        if(item != null)
        {
            InventoryManager.Instance.AddItem(item);
            InventoryManager.Instance.UpdateUI();
            Debug.Log("添加曲奇成功");
        }
        GameObject.FindGameObjectWithTag("DialoageCanvas").GetComponent<DialogueUI>().ShowPanel("你获得了一个香喷喷的曲奇");
    }

    public void DestoryItSelf()
    {
        Destroy(gameObject);
    }


}
