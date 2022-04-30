using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEatController : MonoBehaviour
{
    public GameObject CatPanel;

    public void DisableCatPanel()
    {
        CatPanel.SetActive(false);
    }
}
