using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUI : MonoBehaviour
{
    private Button loadButton;

    private void Awake() 
    {
        loadButton = GetComponent<Button>();
        loadButton.onClick.AddListener(loadGameData);
    }

    private void loadGameData()
    {
        Debug.Log("Loading...");
    }
}
