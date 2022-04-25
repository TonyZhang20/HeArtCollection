using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject LuminancePanel;
    public GameObject SoundPanel;

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
        SettingsPanel.SetActive(false);
    }

    public void OpenLuminanceSettingPanel()
    {
        LuminancePanel.SetActive(true);
    }
    public void CloseLuminanceSettingPanel()
    {
        LuminancePanel.SetActive(false);
    }
    public void OpenSoundSettingPanel()
    {
        SoundPanel.SetActive(true);
    }
    public void CloseSoundSettingPanel()
    {
        SoundPanel.SetActive(false);
    }

    public void SaveSettingPanel()
    {
       
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("Start_UI");
    }
}
