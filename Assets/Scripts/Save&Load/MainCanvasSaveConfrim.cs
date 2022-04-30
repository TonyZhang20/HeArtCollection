using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvasSaveConfrim : MonoBehaviour
{
    
    public int index;
    public void No()
    {
        gameObject.SetActive(false);
    }

    public void Yes()
    {
        SaveloadManager.Instance.Save(index);
        gameObject.SetActive(false);
    }
}
