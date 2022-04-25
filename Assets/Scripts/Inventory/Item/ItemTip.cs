using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void SetupTip(ItemDetails itemDetails)
    {
        nameText.text = itemDetails.itemName;
        descriptionText.text = itemDetails.itemDescription;
    }
}
