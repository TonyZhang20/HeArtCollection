using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear : MonoBehaviour
{
    private Collider2D bearCollider;
    private Animator bearAnim;
    // Start is called before the first frame update
    void Start()
    {
        bearCollider = GetComponent<Collider2D>();
        bearAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bearAnim.SetBool("int", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bearAnim.SetBool("int", false);
        }
    }
}
