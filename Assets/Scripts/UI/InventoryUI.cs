using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public ItemTip itemTip;
>>>>>>> Stashed changes
    [SerializeField] private SlotUI[] playerSlots;

    private void OnEnable()
    {
        EventHandler.UpdateInventoryUI += OnUpdateInventoryUI;
    }

    private void OnDisable()
    {
        EventHandler.UpdateInventoryUI -= OnUpdateInventoryUI;
    }

    void Start()
    {
        //给每个slot一个index，按照背包顺序摆放
        for (int i = 0; i < playerSlots.Length; i++)
        {
            playerSlots[i].slotIndex = i;
        }
<<<<<<< Updated upstream


=======
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
    {
        switch(location)
        {
            case InventoryLocation.Player:
            for(int i = 0; i < playerSlots.Length; i++)
            {
                if(list[i].itemAmount > 0)
                {
                    var item = InventoryManager.Instance.GetItemDetails(list[i].itemID);
                    if(item == null)
                    {
                        Debug.LogError("ID错误，获取物品失败，请检查背包数据");
                    }
                    playerSlots[i].UpdateSlot(item, list[i].itemAmount);
                }
                else
                {
                    playerSlots[i].UpdateEmptySlot();
                }
            }
                break;
        }
    }

}
