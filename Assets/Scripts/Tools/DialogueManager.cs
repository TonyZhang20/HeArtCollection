using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour, ISaveable
{
    private Dictionary<string, List<DialoguePrefabInfo>> DialogueDict = new Dictionary<string, List<DialoguePrefabInfo>>();
    private Transform DialogueParent;
    public string GUID => GetComponent<DataGUID>().guid;

    private void Start()
    {
        ISaveable saveable = this;
        saveable.RegisterSaveable();
    }

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnload;
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoad;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }


    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnload;
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoad;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }

    private void OnStartNewGameEvent(int obj)
    {
        DialogueDict.Clear();
    }
    private void OnAfterSceneLoad()
    {
        DialogueParent = GameObject.FindWithTag("DialogueParent")?.transform;
        RecreateAllDialogue();
    }

    private void OnBeforeSceneUnload()
    {
        GetAllSceneDialogue();
    }

    private void GetAllSceneDialogue()
    {
        var currentSceneDialogue = new List<DialoguePrefabInfo>();
        foreach (var dialogue in FindObjectsOfType<DialogueController>())
        {
            //Debug.Log("Check Finish Success, the iD is " + dialogue.ID.ToString());
            DialoguePrefabInfo dialoguePrefabInfo = new DialoguePrefabInfo { position = new SerializableVector3(dialogue.transform.position), ID = dialogue.ID, isFinish = dialogue.isFinishDialogue };
            currentSceneDialogue.Add(dialoguePrefabInfo);
        }

        if (DialogueDict.ContainsKey(SceneManager.GetActiveScene().name))
        {
            DialogueDict[SceneManager.GetActiveScene().name] = currentSceneDialogue;
        }
        else
        {
            DialogueDict.Add(SceneManager.GetActiveScene().name, currentSceneDialogue);
        }
    }

    private void RecreateAllDialogue()
    {
        var currentSceneDialogue = new List<DialoguePrefabInfo>();

        if (DialogueParent == null) return;

        if (DialogueDict.TryGetValue(SceneManager.GetActiveScene().name, out currentSceneDialogue))
        {
            //Debug.Log("Get Value Success");
            if (currentSceneDialogue != null)
            {
                foreach (var dialogue in FindObjectsOfType<DialogueController>())
                {
                    foreach (var dia in currentSceneDialogue)
                    {
                        //列表只会存储被触发的对话
                        if (dialogue.ID == dia.ID)
                        {
                            //Debug.Log("Change Finish Success");
                            dialogue.isFinishDialogue = dia.isFinish;
                            dialogue.CheckIsFinshed();
                            break;
                        }
                    }
                }
            }
        }

    }

    private bool CheckID()
    {
        return false;
    }

    public GameSaveData GenerateSaveData()
    {
        GetAllSceneDialogue();

        GameSaveData saveData = new GameSaveData();
        saveData.DialogueDict = this.DialogueDict;

        return saveData;
    }

    public void RestoreData(GameSaveData saveData)
    {
        this.DialogueDict = saveData.DialogueDict;

        RecreateAllDialogue();
    }
}

[System.Serializable]
public class DialoguePrefabInfo
{
    public SerializableVector3 position;
    public int ID;
    public bool isFinish;
}



