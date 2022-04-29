using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : SingleTon<TransitionManager>, ISaveable
{
    public string startSceneName = string.Empty;
    private CanvasGroup fadeCanvasGroup;
    private bool isFade;

    public string GUID => GetComponent<DataGUID>().guid;

    //TODO: StartNewGame
    protected override void Awake()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
    private void Start()
    {
        StartCoroutine(loadSceneSetActive(startSceneName));
        fadeCanvasGroup = FindObjectOfType<CanvasGroup>();

        ISaveable saveable = this;
        saveable.RegisterSaveable();
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
        if (!isFade)
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

    private IEnumerator LoadSaveDataScene(string sceneName)
    {
        yield return FadeLoadingPage(1f);

        if (SceneManager.GetActiveScene().name != "PresistentScene")
        {
            //LoadGame in the Game
            EventHandler.CallBeforeSceneLoadEvent();
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        //New Game
        yield return loadSceneSetActive(sceneName);
        EventHandler.CallAfterSceneLoadedEvent();
        yield return FadeLoadingPage(0f);

    }

    public GameSaveData GenerateSaveData()
    {
        GameSaveData saveData = new GameSaveData();
        saveData.dataSceneName = SceneManager.GetActiveScene().name;

        return saveData;
    }

    public void RestoreData(GameSaveData saveData)
    {
        //加载游戏场景
        StartCoroutine(LoadSaveDataScene(saveData.dataSceneName));
    }


}
