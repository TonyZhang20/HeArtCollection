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
    public bool isDone;
    public bool canRepeat = true;
    public bool hasEvent = false;
    public bool StopDialogue = false;
    public bool hasTag = false;
    public UnityEvent AfterConversation;
    public bool hasToPause = true;
    public float waitTime = 1f;
}
