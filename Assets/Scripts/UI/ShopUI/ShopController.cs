using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Text description;
    private Item item;
    [TextArea]
    [SerializeField] private string mText;

    [SerializeField] private Button buttonY;
    [SerializeField] private Button buttonN;
    public void ItemClicked()
    {
        DisableButton();
        item = GetComponent<Item>();
        StartCoroutine(showText(mText));
        if (item != null)
        {
            showButton();
        }
    }

    private IEnumerator showText(string text)
    {
        description.text = string.Empty;
        //todo getItem detail
        yield return description.DOText(text, 0.8f).WaitForCompletion();
    }

    private void showButton()
    {
        buttonY.gameObject.SetActive(true);
        buttonN.gameObject.SetActive(true);

        buttonY.onClick.AddListener(() =>
        {
            BuyItems();
        });

        buttonN.onClick.AddListener(() =>
        {
            ClearText();
        });
    }

    private void RemoveOnClick()
    {
        buttonY.onClick.RemoveListener(() =>
        {
            BuyItems();
        });

        buttonY.onClick.RemoveListener(() =>
        {
            ClearText();
        });
    }

    private void BuyItems()
    {
        var PlayerMoney = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (PlayerMoney.Money >= item.itemDetails.itemPrice && item.itemDetails.canPickup)
        {
            Debug.Log(item.itemDetails.itemPrice.ToString() + PlayerMoney.Money);
            
            //加入物品到背包，不摧毁UI
            InventoryManager.Instance.AddItem(item, false);
            PlayerMoney.Money -= item.itemDetails.itemPrice;
            HealthBar.Instance.RefershCoin();
            DisableButton();
            StartCoroutine(showText("谢谢惠顾"));
        }
        else
        {
            if (!item.itemDetails.canPickup)
            {
                StartCoroutine(showText("小孩子不准吸烟！"));
                DisableButton();
            }
            else
            {
                StartCoroutine(showText("小朋友你的钱不够哦！"));
                DisableButton();
            }
        }
    }

    private void DisableButton()
    {
        buttonY.gameObject.SetActive(false);
        buttonN.gameObject.SetActive(false);
    }

    private void ClearText()
    {
        StartCoroutine(showText(string.Empty));
        DisableButton();
    }
}
