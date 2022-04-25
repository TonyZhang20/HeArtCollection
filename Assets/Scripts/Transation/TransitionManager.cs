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
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        StartCoroutine(loadSceneSetActive(startSceneName));
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnEnable()
    {
        EventHandler.TransitionEvent += OnTransitionEvent;
        EventHandler.AfterSceneLoadEvent += findCanvasGroup;
    }

    private void OnDisable()
    {
        EventHandler.TransitionEvent -= OnTransitionEvent;
        EventHandler.AfterSceneLoadEvent -= findCanvasGroup;
    }
    
    private void findCanvasGroup()
    {
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnTransitionEvent(string sceneName, Vector3 targetPosition)
    {
        //Debug.Log(targetPosition);
        if(!isFade)
        {
            StartCoroutine(ChangeScene(sceneName, targetPosition));
        }
    }

    private IEnumerator loadSceneSetActive(string sceneName)
    {
        //yield return FadeLoadingPage(0);

        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newScene);
        EventHandler.CallAfterSceneLoadedEvent();

    }

    public IEnumerator ChangeScene(string sceneName, Vector3 targetPosition)
    {
        yield return FadeLoadingPage(1);

        EventHandler.CallBeforeSceneLoadEvent();

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return loadSceneSetActive(sceneName);

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
