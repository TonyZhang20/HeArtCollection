using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(SlotUI))]
public class ShowItems : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SlotUI slotUI;
    private Button button;
    private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();
    public bool showPanel = false;

    private void Start()
    {
        slotUI = GetComponent<SlotUI>();
        button = transform.GetChild(0).GetComponent<Button>();
        button.onClick.AddListener(CallParentToShowPanel);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (slotUI.itemAmount != 0)
        {
            inventoryUI.itemTip.gameObject.SetActive(true);
            inventoryUI.itemTip.SetupTip(slotUI.itemDetails);

            inventoryUI.itemTip.transform.position = transform.position + Vector3.down * 5;
        }
        else
        {
            inventoryUI.itemTip.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (inventoryUI != null)
        {
            inventoryUI.itemTip.gameObject.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryUI.itemTip.gameObject.SetActive(false);
    }

    public void CallParentToShowPanel()
    {
        Debug.Log("Run");
        inventoryUI.showPanel(slotUI.itemDetails.itemID);
    }

}
