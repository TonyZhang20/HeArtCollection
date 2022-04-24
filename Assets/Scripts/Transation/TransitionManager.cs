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
        StartCoroutine(loadSceneSetActive(startSceneName));
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();
    }

    private void OnEnable()
    {
        EventHandler.TransitionEvent += OnTransitionEvent;
    }

    private void OnDisable()
    {
        EventHandler.TransitionEvent -= OnTransitionEvent;
    }

    private void OnTransitionEvent(string sceneName, Vector3 targetPosition)
    {
        if(!isFade)
        {
            StartCoroutine(ChangeScene(sceneName, targetPosition));
        }
    }

    /// <summary>
    /// ���س���������Ϊ����
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator loadSceneSetActive(string sceneName)
    {
        //yield return FadeLoadingPage(0);

        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newScene);
        //ִ������ж�س������function
        EventHandler.CallAfterSceneLoadedEvent();

    }

    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public IEnumerator ChangeScene(string sceneName, Vector3 targetPosition)
    {
        yield return FadeLoadingPage(1);

        //ִ������ж�س���ǰ��function
        EventHandler.CallBeforeSceneLoadEvent();

        //ж�س���
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        //���س���
        yield return loadSceneSetActive(sceneName);

        //�ƶ�����
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
