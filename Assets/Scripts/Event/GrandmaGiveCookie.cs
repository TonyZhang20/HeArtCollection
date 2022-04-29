using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaGiveCookie : MonoBehaviour
{

    public Item item;
    public void GiveCookie()
    {
        if(item != null)
        {
            InventoryManager.Instance.AddItem(item);
            //Debug.Log("添加曲奇成功");
        }
        GameObject.FindGameObjectWithTag("DialoageCanvas").GetComponent<DialogueUI>().ShowPanel("你获得了一个香喷喷的曲奇");
    }


}
