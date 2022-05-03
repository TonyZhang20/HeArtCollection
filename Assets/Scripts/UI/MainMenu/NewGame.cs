using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewGame : MonoBehaviour
{
    private Button currentButton;
    private DataSlot currentData;
    private int index = 10;
    private bool haveSpaceToSave = false;
    private void Awake()
    {
        currentButton = GetComponent<Button>();

        SetupSlotUI();

        currentButton.onClick.AddListener(LoadGameData);
    }

    private void SetupSlotUI()
    {
        for(int i = 0; i < 3; i++)
        {
            currentData = SaveloadManager.Instance.dataSlots[i];
            if(currentData == null)
            {
                haveSpaceToSave = true;
                index = i;
                break;
            }
        }
    }

    private void LoadGameData()
    {
        if(!haveSpaceToSave)
        {
            EventHandler.CallStartNewGameEvent(0);
            //Debug.Log("Have not Run");
            return;
        }

        if(currentData != null)
        {
            SaveloadManager.Instance.Load(index);
        }
        else
        {
            EventHandler.CallStartNewGameEvent(index);
        }
    }
}