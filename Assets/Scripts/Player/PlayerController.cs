using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour,ISaveable
{
    private Rigidbody2D rb;

    private float inputX;
    private float inputY;

    public float speed;
    private Vector2 movementInput;

    public bool inputDisable;
    private Animator anim;

    public string GUID => GetComponent<DataGUID>().guid;

    private void Start() 
    {
        ISaveable saveable = this;
        saveable.RegisterSaveable();    
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            PlayerInput();

        SetAnimation();

    }

    void FixedUpdate()
    {
        if(inputDisable == false)
            Movement();
    }

    private void SetAnimation()
    {
        anim.SetFloat("InputX",inputX);
        anim.SetFloat("InputY",inputY);
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

    public GameSaveData GenerateSaveData()
    {
        GameSaveData saveData = new GameSaveData();

        saveData.characterPosDict = new Dictionary<string, SerializableVector3>();

        saveData.characterPosDict.Add(this.name, new SerializableVector3(transform.position));

        var playerStats = GetComponent<PlayerStats>();

        saveData.currentHealth = playerStats.currentHealth;
        saveData.Money = playerStats.Money;

        return saveData;
    }

    public void RestoreData(GameSaveData saveData)
    {
        transform.position = saveData.characterPosDict[this.name].ToVector3();
        var playerStats = GetComponent<PlayerStats>();

        //Debug.Log(saveData.Money.ToString());

        playerStats.Money = saveData.Money;
        playerStats.currentHealth = saveData.currentHealth;

        HealthBar.Instance.RefershCoin();
    }
}
