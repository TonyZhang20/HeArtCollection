using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// ��������������˵�
    /// </summary>
    public void UIAnyBottonDown()
    {
        //GameObject.Find("Canvas/BG/AnyBottons").SetActive(false);
        //GameObject.Find("Canvas/BG/MenuBottons").SetActive(true);
    }

    /// <summary>
    /// ��ʼ����Ϸ(�������ֹ�)
    /// </summary>
    public void StartNewGame()
    {
        SceneManager.LoadScene("PlayerScenes");
    }

    /// <summary>
    /// ������Ϸ
    /// </summary>
    public void ContinueGame()
    {
        
    }

    /// <summary>
    /// �˳���Ϸ
    /// </summary>
    public void QuitGame()
    {
        /// <summary>
        /// ����Application.Quit()���������ã���������ķ���
        /// </summary>
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
