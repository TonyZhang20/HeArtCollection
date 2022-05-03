using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemTip : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;

    public void SetupTip(ItemDetails itemDetails)
    {
        nameText.text = itemDetails.itemName;
        descriptionText.text = itemDetails.itemDescription;
    }
}
