using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// 按任意键唤醒主菜单
    /// </summary>
    public void UIAnyBottonDown()
    {
        //GameObject.Find("Canvas/BG/AnyBottons").SetActive(false);
        //GameObject.Find("Canvas/BG/MenuBottons").SetActive(true);
    }

    /// <summary>
    /// 开始新游戏(进入新手关)
    /// </summary>
    public void StartNewGame()
    {
        SceneManager.LoadScene("PlayerScenes");
    }

    /// <summary>
    /// 继续游戏
    /// </summary>
    public void ContinueGame()
    {
        
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void QuitGame()
    {
        /// <summary>
        /// 单个Application.Quit()好像不起作用，用了下面的方法
        /// </summary>
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
