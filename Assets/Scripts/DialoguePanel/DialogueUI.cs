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

    private void OnShowDialogueEvent(DialoguePiece dialoguePiece)
    {
        StartCoroutine(ShowDialogue(dialoguePiece));
    }

    private IEnumerator ShowDialogue(DialoguePiece dialoguePiece)
    {
        if (dialoguePiece != null)
        {
            dialoguePiece.isDone = false;

            dialogueBox.SetActive(true);
            dialogueText.text = string.Empty;

            if (dialoguePiece.onLeft)
            {
                faceRight.gameObject.SetActive(false);
                faceLeft.gameObject.SetActive(true);
                faceLeft.sprite = dialoguePiece.faceImage;
                nameLeft.text = dialoguePiece.Name;
            }
            else
            {
                faceRight.gameObject.SetActive(true);
                faceLeft.gameObject.SetActive(false);
                faceRight.sprite = dialoguePiece.faceImage;
                nameRight.text = dialoguePiece.Name;
            }
            yield return dialogueText.DOText(dialoguePiece.dialogueText, 1f).WaitForCompletion();

            dialoguePiece.isDone = true;
        }
        else
        {
            dialogueBox.SetActive(false);
            yield break;
        }
    }

}
