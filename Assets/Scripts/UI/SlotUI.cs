using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [Header("组件获取")]
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private Button button;

    [Header("背包类型")]
    public SlotType slotType;
    public bool isSelected;
    //物品信息
    public ItemDetails itemDetails;
    public int itemAmount;
    public int slotIndex;
<<<<<<< Updated upstream
=======

    private InventoryUI inventoryUI => GetComponent<InventoryUI>();
    
>>>>>>> Stashed changes
    void Start() 
    {
        isSelected = false;
        if(itemDetails.itemID == 0)
        {
            UpdateEmptySlot();
        }
    }


    /// <summary>
    /// 上传背包物品
    /// </summary>
    /// <param name="item">物品信息</param>
    /// <param name="amount">数量</param>
    public void UpdateSlot(ItemDetails item, int amount)
    {
        itemDetails = item;
        slotImage.sprite = item.itemIcon;
        slotImage.enabled = true;

        itemAmount = amount;
        amountText.text = amount.ToString();
        button.interactable = true;
        //按钮可以被点按
    }

    /// <summary>
    /// 将背包格子slot更新为空
    /// </summary>
    public void UpdateEmptySlot()
    {
        if(isSelected)
        {
            isSelected = false;
        }

        slotImage.enabled = false;
        amountText.text = string.Empty;
        button.interactable = false;
    }
}
