using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelControl : MonoBehaviour
{
    public GameObject playerBag;
    public GameObject musicPage;
    public GameObject SaveLoadPage;
    public GameObject Buttons;

    public void ShowBag()
    {
        playerBag.SetActive(true);
        InventoryManager.Instance.UpdateUI();
        Buttons.SetActive(true);
        musicPage.SetActive(false);
        SaveLoadPage.SetActive(false);
    }

    public void ShowMusic()
    {
        Buttons.SetActive(true);
        musicPage.SetActive(true);
        playerBag.SetActive(false);
        SaveLoadPage.SetActive(false);
    }

    public void ShowSaveLoad()
    {
        SaveLoadPage.SetActive(true);
        Buttons.SetActive(true);
        musicPage.SetActive(false);
        playerBag.SetActive(false);
    }

    public void Close()
    {
        playerBag.SetActive(false);
        Buttons.SetActive(false);
        musicPage.SetActive(false);
        SaveLoadPage.SetActive(false);
    }
}
