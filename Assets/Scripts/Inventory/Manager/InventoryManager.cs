using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : SingleTon<InventoryManager>
{
    [Header("物品数据")]
    public ItemDataList_SO itemDataList_SO;

    [Header("背包数据")]
    public InventoryBag_SO playerBag;
    private Dictionary<string, List<SceneItem>> sceneItemDict = new Dictionary<string, List<SceneItem>>();

    private void OnEnable() 
    {
        EventHandler.AfterSceneLoadEvent += UpdateUI;
    }

    private void OnDisable() 
    {
        EventHandler.AfterSceneLoadEvent -= UpdateUI;
    }

    public void UpdateUI()
    {
        EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
    }
    
    public ItemDetails GetItemDetails(int ID)
    {
        return itemDataList_SO.itemDetails.Find(i => i.itemID == ID);
    }

    /// <summary>
    /// 添加物品到背包,背包已经预先设计好格子数量
    /// </summary>
    /// <param name="item">物体身上的Item脚本</param>
    /// <param name="toDestory">是否销毁物品，默认为true可以不填</param>
    /// <param name="amount">添加多少物品，默认为1，可以不填</param>
    public void AddItem(Item item, bool toDestory = true, int amount = 1)
    {
        //检查是否有该物体
        int itemIndex = CheckBagRepeat(item.itemID);
        AddItemAtIndex(item.itemID, itemIndex);

        if (toDestory)
        {
            if(!item.gameObject.CompareTag("NPC"))
                Destroy(item.gameObject);
        }

        //Update UI
        EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
    }

    private bool CheckBagEmpty()
    {
        foreach (var item in playerBag.itemList)
        {
            if (item.itemID == 0)
                return true;
        }
        //如果背包满了
        //TODO: 添加UI-你的背包已经满了
        return false;
    }

    private int CheckBagRepeat(int itemID)
    {
        for (int i = 0; i < playerBag.itemList.Count; i++)
        {
            if (playerBag.itemList[i].itemID == itemID)
            {
                return i;
            }
        }
        return -1;
    }

    private void AddItemAtIndex(int ID, int index, int amount = 1)
    {

        if (index == -1 && CheckBagEmpty())    //没有重复物体，添加
        {
            var item = new InventoryItem { itemID = ID, itemAmount = amount };
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == 0)
                {
                    playerBag.itemList[i] = item;
                    return;
                }
            }
        }
        else
        {
            int currentAmount = playerBag.itemList[index].itemAmount + amount;
            var item = new InventoryItem { itemID = ID, itemAmount = currentAmount };
            playerBag.itemList[index] = item;
        }
    }

}
