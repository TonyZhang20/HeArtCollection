using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour, ISaveable
{
    public Item itemPrefab;
    private Transform itemParent;
    private Dictionary<string, List<SceneItem>> sceneItemDict = new Dictionary<string, List<SceneItem>>();

    public string GUID => GetComponent<DataGUID>().guid;

    private void Start() 
    {
        ISaveable saveable = this;
        saveable.RegisterSaveable();
    }

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadedEvent;
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadedEvent;
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnBeforeSceneUnloadedEvent()
    {
        GetAllSceneItems();
    }

    private void OnAfterSceneLoadedEvent()
    {
        itemParent = GameObject.FindWithTag("ItemParent")?.transform;
        RecreateAllItem();
    }   

    private void onInstantiateItemInScene(int ID, Vector3 position)
    {
        if(itemParent == null) return;

        var item = Instantiate(itemPrefab, position, Quaternion.identity, itemParent);
        item.itemID = ID;
    }

    private void GetAllSceneItems()
    {
        List<SceneItem> currentSceneItems = new List<SceneItem>();
        foreach (var item in FindObjectsOfType<Item>())
        {
            SceneItem sceneItem = new SceneItem { itemID = item.itemID, position = new SerializableVector3(item.transform.position) };
            currentSceneItems.Add(sceneItem);
        }
        if (sceneItemDict.ContainsKey(SceneManager.GetActiveScene().name))
        {
            sceneItemDict[SceneManager.GetActiveScene().name] = currentSceneItems;
        }
        else
        {
            sceneItemDict.Add(SceneManager.GetActiveScene().name, currentSceneItems);
        }
    }

    private void RecreateAllItem()
    {
        List<SceneItem> currentSceneItems = new List<SceneItem>();

        if(itemParent == null) return;

        if(sceneItemDict.TryGetValue(SceneManager.GetActiveScene().name, out currentSceneItems))
        {
            if(currentSceneItems != null)
            {
                foreach(var item in FindObjectsOfType<Item>())
                {
                    Destroy(item.gameObject);
                }
                
                foreach (var item in currentSceneItems)
                {
                    Item newItem = Instantiate(itemPrefab, item.position.ToVector3(), Quaternion.identity, itemParent);
                    newItem.Init(item.itemID);
                }
            }
        }
    }

    public GameSaveData GenerateSaveData()
    {
        GetAllSceneItems();

        GameSaveData saveData = new GameSaveData();
        saveData.sceneItemDict = this.sceneItemDict;

        return saveData;
    }

    public void RestoreData(GameSaveData saveData)
    {
        this.sceneItemDict = saveData.sceneItemDict;
        RecreateAllItem();
    }
}
