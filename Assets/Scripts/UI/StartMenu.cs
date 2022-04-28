using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject InfoPanel;
    public void UIAnyBottonDown()
    {

    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("PlayerScenes");
    }
    public void ContinueGame()
    {

    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenInfo()
    {
        InfoPanel.SetActive(true);
    }

    public void TurnOffInfo()
    {
        InfoPanel.SetActive(false);
    }
}
