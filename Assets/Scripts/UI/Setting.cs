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
    /// �������
    /// </summary>
    public void OpenSettingsPanel()
    {
        //��
=======
    public void OpenSettingsPanel()
    {
>>>>>>> Stashed changes
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingPanel()
    {
<<<<<<< Updated upstream
        //�ر�
        SettingsPanel.SetActive(false);
    }

    ///<summary>
    ///�����������
    ///<summary>
    public void OpenLuminanceSettingPanel()
    {
        //��
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
        //�ر�
        LuminancePanel.SetActive(false);
    }

    /// <summary>
    /// �����������
    /// </summary>
    public void OpenSoundSettingPanel()
    {
        //��
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
        //��
        SoundPanel.SetActive(false);
    }

    /// <summary>
    /// �浵���
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
    /// �������˵�
    /// </summary>
=======
>>>>>>> Stashed changes
    public void returnMainMenu()
    {
        SceneManager.LoadScene("Start_UI");
    }
}
