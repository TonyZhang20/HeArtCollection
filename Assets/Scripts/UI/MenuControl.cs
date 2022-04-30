using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject menu;
    public PausePanelControl pausePanel;
    // Start is called before the first frame update
    void OnEnable()
    {
        ClosePause();
    }

    // Update is called once per frame
    void Update()
    {
        //if bag menu is open
        if (Input.GetKeyDown(KeyCode.Tab) && pausePanel.gameObject.activeInHierarchy)
        {
            ClosePause();
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && !pausePanel.gameObject.activeInHierarchy)
        {
            pausePanel.gameObject.SetActive(true);
            pausePanel.ShowBag();
        }
    }

    public void CallSettings()
    {
        pausePanel.gameObject.SetActive(true);
        pausePanel.ShowSaveLoad();
    }

    public void CallBag()
    {
        pausePanel.gameObject.SetActive(true);
        pausePanel.ShowBag();
    }

    public void ClosePause()
    {
        pausePanel.Close();
        pausePanel.gameObject.SetActive(false);
    }
}
