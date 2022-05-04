using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Image faceRight, faceLeft;
    public TextMeshProUGUI nameRight, nameLeft;
    public Text GetItemText;
    public GameObject GetItemPanel;
    private float closePanel = 0;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += OnShowDialogueEvent;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= OnShowDialogueEvent;
    }

    private void Update()
    {
        closePanel -= Time.deltaTime;
        if (closePanel < 0)
        {
            GetItemPanel.SetActive(false);
        }
    }

    private void OnShowDialogueEvent(DialoguePiece dialoguePiece)
    {
        StartCoroutine(ShowDialogue(dialoguePiece));
    }

    private IEnumerator ShowDialogue(DialoguePiece dialoguePiece)
    {
        if (dialoguePiece != null && !dialoguePiece.isDone)
        {
            if (dialoguePiece.canRepeat)
            {
                dialoguePiece.isDone = false;
            }

            dialogueBox.SetActive(true);
            dialogueText.text = string.Empty;

            if (dialoguePiece.onLeft)
            {
                faceRight.gameObject.SetActive(false);
                faceLeft.gameObject.SetActive(true);
                faceLeft.sprite = dialoguePiece.faceImage;
                nameLeft.text = dialoguePiece.Name;
            }
            else if (dialoguePiece.Name == string.Empty)
            {
                faceLeft.gameObject.SetActive(false);
                faceRight.gameObject.SetActive(false);
                nameRight.text = string.Empty;
            }
            else
            {
                faceRight.gameObject.SetActive(true);
                faceLeft.gameObject.SetActive(false);
                faceRight.sprite = dialoguePiece.faceImage;
                nameRight.text = dialoguePiece.Name;
            }

            yield return dialogueText.DOText(dialoguePiece.dialogueText, dialoguePiece.waitTime).WaitForCompletion();

            dialoguePiece.isDone = true;

            if (dialoguePiece.hasToPause == false)
            {
                dialogueBox.SetActive(false);
                yield break;
            }
        }
        else
        {
            // if(dialoguePiece != null && dialoguePiece.isDone)
            // {
            //     yield return null;
            // }
            dialogueBox.SetActive(false);
            yield break;
        }
    }

    public void ShowPanel(string describe)
    {
        GetItemPanel.SetActive(true);
        closePanel = 1.5f;
        GetItemText.text = describe;
    }

}
