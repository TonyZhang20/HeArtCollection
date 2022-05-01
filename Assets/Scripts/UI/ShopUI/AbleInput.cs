using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleInput : MonoBehaviour
{
    public void EnableInput()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputDisable = false;
    }
}
