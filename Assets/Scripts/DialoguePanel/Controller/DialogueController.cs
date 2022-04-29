using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]
public class DialogueController : MonoBehaviour
{
    public int ID;
    public UnityEvent OnFinishEvent;
    public List<DialoguePiece> dialogueList = new List<DialoguePiece>();
    public Stack<DialoguePiece> dialogueStack;
    public bool canTalk = false;
    public bool isTrigger = false;
    public bool isFinishDialogue = false;
    private bool isTalking = false;
    private ShowPressE showPressE;

    private void Awake()
    {
        FillStack();
        CheckIsFinshed();
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += CheckIsFinshed;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= CheckIsFinshed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFinishDialogue)
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isTrigger)
        {
            StartCoroutine(DialogueRoutine());
        }
    }

    private void FillStack()
    {
        dialogueStack = new Stack<DialoguePiece>();
        for (int i = dialogueList.Count - 1; i > -1; i--)
        {
            if (dialogueList[i].canRepeat)
            {
                dialogueList[i].isDone = false;
            }
            
            if(dialogueList[i].isDone == false)
            {
                dialogueStack.Push(dialogueList[i]);
            }
        }
    }

    private void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.E) && !isTalking && !isTrigger)
        {
            StartCoroutine(DialogueRoutine());
        }
    }

    private IEnumerator DialogueRoutine()
    {
        isTrigger = false;
        isTalking = true;
        if (dialogueStack.TryPop(out DialoguePiece result))
        {
            //Debug.Log(result.isDone);
            if(result.isDone == false)
            {
                EventHandler.CallShowDialogueEvent(result);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = true;
                yield return new WaitUntil(() => result.isDone);
            }
            else
            {
                yield return null;
            }

            isTalking = false;

            if (result.hasEvent)
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
            canTalk = false;
            OnFinishEvent?.Invoke();
        }
    }

    public void CanNotTalk_ExitTriggerOnly()
    {
        canTalk = false;
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void CheckIsFinshed()
    {
        if (isFinishDialogue)
        {
            if (dialogueStack.TryPop(out DialoguePiece result))
            {
                result.isDone = true;
            }
            canTalk = false;
        }

    }

    public void Finish()
    {
        isFinishDialogue = true;
        showPressE = gameObject.GetComponent<ShowPressE>();
        showPressE.show = false;
    }
}
