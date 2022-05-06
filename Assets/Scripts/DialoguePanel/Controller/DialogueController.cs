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
            CheckIsFinshed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isFinishDialogue && !isTrigger)
        {
            canTalk = false;
        }

        if (other.CompareTag("Player") && isTrigger)
        {
            StartCoroutine(DialogueRoutine());
            canTalk = true;
        }
    }

    public void SkipConverSation()
    {
        StartCoroutine(DialogueRoutine());
    }

    public void FillStack()
    {
        dialogueStack = new Stack<DialoguePiece>();
        for (int i = dialogueList.Count - 1; i > -1; i--)
        {
            if (dialogueList[i].canRepeat)
            {
                dialogueList[i].isDone = false;
            }

            if (dialogueList[i].isDone == false)
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
        DialoguePiece result;
        if (dialogueStack.TryPop(out result) && !result.StopDialogue)
        {
            //Debug.Log(result.isDone);
            if (result.isDone == false)
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
            if (result != null && !result.hasTag)
            {
                result.StopDialogue = false;
            }

            EventHandler.CallShowDialogueEvent(null);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = false;
            FillStack();
            canTalk = false;
            isTalking = false;
            OnFinishEvent?.Invoke();
        }
    }

    public void CanNotTalk_ExitTriggerOnly()
    {
        canTalk = false;
    }

    public void CanTalk()
    {
        canTalk = true;
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void CheckIsFinshed()
    {
        if (isFinishDialogue)
        {
            // if (dialogueStack.TryPop(out DialoguePiece result))
            // {
            //     result.isDone = true;
            // }

            foreach (var result in dialogueStack)
            {
                result.isDone = true;
            }

            showPressE = gameObject.GetComponent<ShowPressE>();
            if (showPressE != null)
            {
                showPressE.show = false;
            }
            canTalk = false;
        }

    }

    public void Finish()
    {
        isFinishDialogue = true;
    }
}
