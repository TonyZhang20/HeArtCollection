using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanvas : MonoBehaviour
{
    private CatEatController CatCanvas;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoad;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoad;
    }

    private void OnAfterSceneLoad()
    {
        GetCatCanvas();
    }

    private void GetCatCanvas()
    {
        CatCanvas = GameObject.FindObjectOfType<CatEatController>();
    }

    public void SetCatCanvasActive()
    {
        CatCanvas.CatPanel.SetActive(true);
    }
}
