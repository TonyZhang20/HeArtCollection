using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SisterFollow : MonoBehaviour
{
    public float Speed;
    private GameObject Player;
    private bool isChasing = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //切换场景事件
        EventHandler.MoveToPosition += OnMoveToPosition;
        EventHandler.AfterSceneLoadEvent += ChaseAtStart;
    }

    private void OnDisable()
    {
        EventHandler.MoveToPosition -= OnMoveToPosition;
        EventHandler.AfterSceneLoadEvent -= ChaseAtStart;
    }

    private void OnMoveToPosition(Vector3 targetPosition)
    {
        transform.position = new Vector3(targetPosition.x, targetPosition.y - 0.2f, targetPosition.z);
    }

    private void Update()
    {
        if (isChasing)
        {
            SetupAnimation();
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed);
        }
    }

    private void ChaseAtStart()
    {
        if (Player == null && isChasing == false)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            isChasing = true;
        }
    }

    private void SetupAnimation()
    {
        var distanX = Player.transform.position.x - transform.position.x;
        var distanY = Player.transform.position.y - transform.position.y;
        //这个时候玩家在妹妹的右上方
        if (distanX > 0 && distanY > 0)
        {
            if (distanX > distanY)
            {
                WalkRight();
            }
            else
            {
                WalkUp();
            }
        }
        //玩家在妹妹的右下方
        else if (distanX > 0 && distanY < 0)
        {
            if (distanX > Mathf.Abs(distanY))
            {
                WalkRight();
            }
            else
            {
                WalkDown();
            }
        }
        //玩家在妹妹的左上方
        else if (distanX < 0 && distanY > 0)
        {
            if (Mathf.Abs(distanX) > distanY)
            {
                WalkLeft();
            }
            else
            {
                WalkUp();
            }
        }
        //在左下方
        else if (distanX < 0 && distanY < 0)
        {
            if (distanX < distanY)
            {
                WalkLeft();
            }
            else
            {
                WalkDown();
            }
        }
    }
    #region SetAnimation
    private void WalkUp()
    {
        anim.SetBool("isWalkUp", true);
        anim.SetBool("isWalkDown", false);
        anim.SetBool("isWalkLeft", false);
        anim.SetBool("isWalkRight", false);
    }

    private void WalkDown()
    {
        anim.SetBool("isWalkUp", false);
        anim.SetBool("isWalkDown", true);
        anim.SetBool("isWalkLeft", false);
        anim.SetBool("isWalkRight", false);
    }

    private void WalkRight()
    {
        anim.SetBool("isWalkUp", false);
        anim.SetBool("isWalkDown", false);
        anim.SetBool("isWalkLeft", false);
        anim.SetBool("isWalkRight", true);
    }

    private void WalkLeft()
    {
        anim.SetBool("isWalkUp", false);
        anim.SetBool("isWalkDown", false);
        anim.SetBool("isWalkLeft", true);
        anim.SetBool("isWalkRight", false);
    }

    private void StopAnimation()
    {
        anim.SetBool("isWalkUp", false);
        anim.SetBool("isWalkDown", false);
        anim.SetBool("isWalkLeft", false);
        anim.SetBool("isWalkRight", false);
    }
    #endregion

    #region Trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        //当哥哥离开了妹妹的范围之后触发跟随
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            Player = other.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAnimation();
            Player = null;
            isChasing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //进入范围后暂停跟随
        if (other.CompareTag("Player"))
        {
            StopAnimation();
            Player = null;
            isChasing = false;
        }
    }
    #endregion
}
