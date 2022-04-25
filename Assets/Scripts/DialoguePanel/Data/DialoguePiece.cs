using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialoguePiece
{
    [Header("对话详情")]
    public Sprite faceImage;
    public bool onLeft;
    public string Name;
    [TextArea]
    public string dialogueText;
    [HideInInspector]
    public bool isDone;
    public UnityEvent AfterConversation;
}