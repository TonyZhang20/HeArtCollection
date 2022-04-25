using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject LuminancePanel;
    public GameObject SoundPanel;

<<<<<<< Updated upstream
    /// <summary>
    /// 设置面板
    /// </summary>
    public void OpenSettingsPanel()
    {
        //打开
=======
    public void OpenSettingsPanel()
    {
>>>>>>> Stashed changes
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
<<<<<<< Updated upstream
        //关闭
        SettingsPanel.SetActive(false);
    }

    ///<summary>
    ///亮度设置面板
    ///<summary>
    public void OpenLuminanceSettingPanel()
    {
        //打开
=======
        SettingsPanel.SetActive(false);
    }

    public void OpenLuminanceSettingPanel()
    {
>>>>>>> Stashed changes
        LuminancePanel.SetActive(true);
    }
    public void CloseLuminanceSettingPanel()
    {
<<<<<<< Updated upstream
        //关闭
        LuminancePanel.SetActive(false);
    }

    /// <summary>
    /// 声音设置面板
    /// </summary>
    public void OpenSoundSettingPanel()
    {
        //打开
=======
        LuminancePanel.SetActive(false);
    }
    public void OpenSoundSettingPanel()
    {
>>>>>>> Stashed changes
        SoundPanel.SetActive(true);
    }
    public void CloseSoundSettingPanel()
    {
<<<<<<< Updated upstream
        //打开
        SoundPanel.SetActive(false);
    }

    /// <summary>
    /// 存档面板
    /// </summary>
=======
        SoundPanel.SetActive(false);
    }

>>>>>>> Stashed changes
    public void SaveSettingPanel()
    {
       
    }

<<<<<<< Updated upstream
    /// <summary>
    /// 返回主菜单
    /// </summary>
=======
>>>>>>> Stashed changes
    public void returnMainMenu()
    {
        SceneManager.LoadScene("Start_UI");
    }
}
