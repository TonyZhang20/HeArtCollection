using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : SingleTon<TransitionManager>
{
    public string startSceneName = string.Empty;
    private CanvasGroup fadeCanvasGroup;
    private bool isFade;

    private void Start()
    {
<<<<<<< Updated upstream
=======
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
>>>>>>> Stashed changes
        StartCoroutine(loadSceneSetActive(startSceneName));
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnEnable()
    {
        EventHandler.TransitionEvent += OnTransitionEvent;
<<<<<<< Updated upstream
=======
        EventHandler.AfterSceneLoadEvent += findCanvasGroup;
>>>>>>> Stashed changes
    }

    private void OnDisable()
    {
        EventHandler.TransitionEvent -= OnTransitionEvent;
<<<<<<< Updated upstream
=======
        EventHandler.AfterSceneLoadEvent -= findCanvasGroup;
    }
    
    private void findCanvasGroup()
    {
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
>>>>>>> Stashed changes
    }

    private void OnTransitionEvent(string sceneName, Vector3 targetPosition)
    {
<<<<<<< Updated upstream
=======
        //Debug.Log(targetPosition);
>>>>>>> Stashed changes
        if(!isFade)
        {
            StartCoroutine(ChangeScene(sceneName, targetPosition));
        }
    }

<<<<<<< Updated upstream
    /// <summary>
    /// 加载场景并设置为激活
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
=======
>>>>>>> Stashed changes
    private IEnumerator loadSceneSetActive(string sceneName)
    {
        //yield return FadeLoadingPage(0);

        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newScene);
<<<<<<< Updated upstream
        //执行所有卸载场景后的function
=======

>>>>>>> Stashed changes
        EventHandler.CallAfterSceneLoadedEvent();

    }

<<<<<<< Updated upstream
    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
=======
>>>>>>> Stashed changes
    public IEnumerator ChangeScene(string sceneName, Vector3 targetPosition)
    {
        yield return FadeLoadingPage(1);

<<<<<<< Updated upstream
        //执行所有卸载场景前的function
        EventHandler.CallBeforeSceneLoadEvent();

        //卸载场景
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        //加载场景
        yield return loadSceneSetActive(sceneName);

        //移动人物
=======
        EventHandler.CallBeforeSceneLoadEvent();

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return loadSceneSetActive(sceneName);

>>>>>>> Stashed changes
        EventHandler.CallMoveToPosition(targetPosition);

        yield return FadeLoadingPage(0);
    }

    IEnumerator FadeLoadingPage(float alpha)
    {
        isFade = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - alpha) / Settings.loadingCanvasDuration * Time.deltaTime;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, alpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, alpha, speed);
            yield return null;
        }

        isFade = false;
    }
}
