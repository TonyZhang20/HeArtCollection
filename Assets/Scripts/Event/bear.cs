using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear : MonoBehaviour
{
    private Collider2D bearCollider;
    private Animator bearAnim;
    // Start is called before the first frame update
    private void OnEnable() {
        EventHandler.AfterSceneLoadEvent += FindAnimator;
    }

    private void OnDisable() {
        EventHandler.AfterSceneLoadEvent -= FindAnimator;
    }

    private void FindAnimator()
    {
        bearAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void giveAnim()
    {
        bearAnim.SetBool("give", true);
    }

    public void stopAnim()
    {
        bearAnim.SetBool("give", false);
    }
}
