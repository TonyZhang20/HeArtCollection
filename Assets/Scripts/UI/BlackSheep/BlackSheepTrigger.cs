using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSheepTrigger : MonoBehaviour
{
    private bool isPlayed = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPlayed && Input.GetKeyDown(KeyCode.E))
        {
            isPlayed = true;
            GameObject.FindObjectOfType<SheepCanvas>().OpenBlackSheep();
            GetComponent<ShowPressE>().show = false;
        }
    }
}
