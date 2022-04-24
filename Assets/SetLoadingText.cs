using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLoadingText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetText(string text)
    {
        textMeshPro.text = text;
    }
}
