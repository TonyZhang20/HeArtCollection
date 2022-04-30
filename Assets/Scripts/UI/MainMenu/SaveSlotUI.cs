using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SaveSlotUI : MonoBehaviour
{
    public TextMeshProUGUI SaveData;
    private Button currentButton;
    private DataSlot currentData;
    public int index;
    private void Awake()
    {
        currentButton = GetComponent<Button>();

        SetupSlotUI();
        
        currentButton.onClick.AddListener(LoadGameData);
    }

    private void SetupSlotUI()
    {
        currentData = SaveloadManager.Instance.dataSlots[index];
    }

    private void LoadGameData()
    {
        if(currentData != null)
        {
            SaveloadManager.Instance.Load(index);
        }
        else
        {
            Debug.Log("空游戏进度");
            EventHandler.CallStartNewGameEvent(index);
        }
    }
}
