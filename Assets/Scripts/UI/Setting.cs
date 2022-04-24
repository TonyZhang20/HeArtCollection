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
    /// �������
    /// </summary>
    public void OpenSettingsPanel()
    {
        //��
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
        //�ر�
        SettingsPanel.SetActive(false);
    }

    ///<summary>
    ///�����������
    ///<summary>
    public void OpenLuminanceSettingPanel()
    {
        //��
        LuminancePanel.SetActive(true);
    }
    public void CloseLuminanceSettingPanel()
    {
        //�ر�
        LuminancePanel.SetActive(false);
    }

    /// <summary>
    /// �����������
    /// </summary>
    public void OpenSoundSettingPanel()
    {
        //��
        SoundPanel.SetActive(true);
    }
    public void CloseSoundSettingPanel()
    {
        //��
        SoundPanel.SetActive(false);
    }

    /// <summary>
    /// �浵���
    /// </summary>
    public void SaveSettingPanel()
    {
       
    }

    /// <summary>
    /// �������˵�
    /// </summary>
    public void returnMainMenu()
    {
        SceneManager.LoadScene("Start_UI");
    }
}
