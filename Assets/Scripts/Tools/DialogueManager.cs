using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
//ISaveable
{
    public List<DialogKey> DialogKey = new List<DialogKey>();
    private Dictionary<string, List<DialoguePrefabInfo>> DialogueDict = new Dictionary<string, List<DialoguePrefabInfo>>();
    private Transform DialogueParent;

    public string GUID => GetComponent<DataGUID>().guid;

    private void Start()
    {
        // ISaveable saveable = this;
        // saveable.RegisterSaveable();
    }

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnload;
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoad;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnload;
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoad;
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
            DialoguePrefabInfo dialoguePrefabInfo = new DialoguePrefabInfo { position = new SerializableVector3(dialogue.transform.position), dialogueController = dialogue };
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
            if (currentSceneDialogue != null)
            {
                foreach (var dialogue in FindObjectsOfType<DialogueController>())
                {
                    Destroy(dialogue.gameObject);
                }

                foreach (var dialogue in currentSceneDialogue)
                {
                    Instantiate(dialogue.dialogueController, dialogue.position.ToVector3(), Quaternion.identity, DialogueParent);
                }
            }
        }
    }

    // public GameSaveData GenerateSaveData()
    // {
    //     GetAllSceneDialogue();

    //     GameSaveData saveData = new GameSaveData();
    //     saveData.DialogueDict = this.DialogueDict;

    //     return saveData;
    // }

    // public void RestoreData(GameSaveData saveData)
    // {
    //     this.DialogueDict = saveData.DialogueDict;

    //     RecreateAllDialogue();
    // }
}

[System.Serializable]
public class DialoguePrefabInfo
{
    public SerializableVector3 position;
    public DialogueController dialogueController;
}

[System.Serializable]
public class DialogKey
{
    public DialogueController dialogueController;
    public string SceneName;
}


