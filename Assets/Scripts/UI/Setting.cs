using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject LuminancePanel;
    public GameObject SoundPanel;

    /// <summary>
    /// 设置面板
    /// </summary>
    public void OpenSettingsPanel()
    {
        //打开
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
        //关闭
        SettingsPanel.SetActive(false);
    }

    ///<summary>
    ///亮度设置面板
    ///<summary>
    public void OpenLuminanceSettingPanel()
    {
        //打开
        LuminancePanel.SetActive(true);
    }
    public void CloseLuminanceSettingPanel()
    {
        //关闭
        LuminancePanel.SetActive(false);
    }

    /// <summary>
    /// 声音设置面板
    /// </summary>
    public void OpenSoundSettingPanel()
    {
        //打开
        SoundPanel.SetActive(true);
    }
    public void CloseSoundSettingPanel()
    {
        //打开
        SoundPanel.SetActive(false);
    }

    /// <summary>
    /// 存档面板
    /// </summary>
    public void SaveSettingPanel()
    {
       
    }

    /// <summary>
    /// 返回主菜单
    /// </summary>
    public void returnMainMenu()
    {
        SceneManager.LoadScene("Start_UI");
    }
}
