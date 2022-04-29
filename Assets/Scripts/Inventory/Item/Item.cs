using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    private SpriteRenderer spriteRenderer;
    public ItemDetails itemDetails;
    private BoxCollider2D coll;
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        Init(itemID);
    }

    protected void OnDisable()
    {
    }

    private void CallItemID()
    {
        if (itemID == 0)
        {
            Debug.Log("未设置" + this.gameObject.name + "的物品ID");
        }
        Init(itemID);
    }

    /// <summary>
    /// 初始化item在地图或者背包
    /// </summary>
    /// <param name="ID"></param>
    public void Init(int ID)
    {
        itemDetails = InventoryManager.Instance.GetItemDetails(ID);

        if (itemDetails == null)
        {
            Debug.Log("背包" + gameObject.name + "物品序号错误 ，储存库中并未有该物品，请添加或者检查ID");
            return;
        }

        if (spriteRenderer == null) return;

        spriteRenderer.sprite = itemDetails.itemOnWorldSprite != null ? itemDetails.itemOnWorldSprite : itemDetails.itemIcon;

        if(coll == null) return;
        
        //修改collider尺寸
        Vector2 newSize = new Vector2(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y);
        coll.size = newSize;
        coll.offset = new Vector2(0, spriteRenderer.sprite.bounds.center.y);
    }

}
