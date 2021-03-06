using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcArtist : MonoBehaviour
{
    private Animator anim;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += GetAnim;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= GetAnim;
    }

    public void LookLeft()
    {
        anim.SetTrigger("Talk");
    }

    public void Walk()
    {
        anim.SetTrigger("Move");
    }

    public void LeaveScene()
    {
        gameObject.SetActive(false);
    }

    public void PlayDog()
    {
        var DogPanel = FindObjectOfType<DogPanel>();
        DogPanel.Panel.SetActive(true);
    }
    
    private void GetAnim()
    {
        anim = GetComponent<Animator>();
    }
}
