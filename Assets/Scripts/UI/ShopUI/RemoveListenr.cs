using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveListenr : MonoBehaviour
{
    private void OnEnable() 
    {
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void OnDisable() 
    {
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
