using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float inputX;
    private float inputY;

    public float speed;
    private Vector2 movementInput;

    public bool inputDisable;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadEvent += OnAfterSceneUnloadEvent;
        EventHandler.MoveToPosition += OnMoveToPosition;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneUnloadEvent;
        EventHandler.MoveToPosition -= OnMoveToPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(inputDisable == false)
        {
            PlayerInput();
        }
    }

    void FixedUpdate()
    {
        if(inputDisable == false)
        {
            Movement();
        }
    }

    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 && inputY != 0)
        {
            inputX *= 0.7f;
            inputY *= 0.7f;
        }

        movementInput = new Vector2(inputX, inputY);
    }

    private void Movement()
    {
        //�����������ƶ���û���ٶ�
        rb.MovePosition(rb.position + movementInput * speed * Time.deltaTime);
    }
    private void OnMoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }

    private void OnAfterSceneUnloadEvent()
    {
        inputDisable = false;
    }

    private void OnBeforeSceneUnloadEvent()
    {
        inputDisable = true;
    }
}
