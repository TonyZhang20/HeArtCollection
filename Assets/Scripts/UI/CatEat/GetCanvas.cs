using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanvas : MonoBehaviour
{
    private CatEatController CatCanvas;
    private bool NeedCheck = true;
    private bool CheckNext = false;
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

    public void StopSister()
    {
        var Sister = GameObject.FindObjectOfType<SisterFollow>();
        Sister.StopChasing();
    }

    public void StartSister()
    {
        var Sister = GameObject.FindObjectOfType<SisterFollow>();
        Sister.ChaseAtStart();
    }

    private void Update() 
    {
        var ItemList = InventoryManager.Instance.playerBag;
        if(ItemList.hasItem(1004) && NeedCheck)
        {
            var DialogueController = GetComponent<DialogueController>();
            foreach(var dialogue in DialogueController.dialogueStack)
            {
                if(CheckNext)
                {
                    CheckNext = false;
                    dialogue.hasTag = false;
                    dialogue.StopDialogue = false;
                    DialogueController.FillStack();
                    return;
                }

                if(dialogue.hasTag == true)
                {
                    dialogue.hasTag = false;
                    dialogue.isDone = true;
                    dialogue.canRepeat = false;
                    dialogue.StopDialogue = false;
                    DialogueController.FillStack();
                    NeedCheck = false;
                    CheckNext = true;
                }
            }
        }
    }

    public void TransLate()
    {
        EventHandler.CallTransitionEvent("town", new Vector3(-11.5f, -8f,0f));
    }
}
