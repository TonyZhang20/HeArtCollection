using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]
public class DialogueController : MonoBehaviour
{
    public UnityEvent OnFinishEvent;
    public List<DialoguePiece> dialogueList = new List<DialoguePiece>();
    public Stack<DialoguePiece> dialogueStack;
    public  bool canTalk = true;
    private bool isTalking = false;

    private void Awake()
    {
        FillStack();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
        }
    }

    private void FillStack()
    {
        dialogueStack = new Stack<DialoguePiece>();
        for (int i = dialogueList.Count - 1; i > -1; i--)
        {
            if(dialogueList[i].canRepeat)
            {
                dialogueList[i].isDone = false;
            }
            dialogueStack.Push(dialogueList[i]);
        }
    }

    private void Update() 
    {
        if(canTalk && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            StartCoroutine(DialogueRoutine());
        }
    }

    private IEnumerator DialogueRoutine()
    {
        isTalking = true;
        if(dialogueStack.TryPop(out DialoguePiece result) && !result.isDone)
        {
            EventHandler.CallShowDialogueEvent(result);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = true;
            yield return new WaitUntil(() => result.isDone);
            isTalking = false;
            if(result.hasEvent)
            {
                result.AfterConversation?.Invoke();
            }
        }
        else
        {
            EventHandler.CallShowDialogueEvent(null);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = false;
            FillStack();
            isTalking = false;
            OnFinishEvent?.Invoke();
        }
    }
}
