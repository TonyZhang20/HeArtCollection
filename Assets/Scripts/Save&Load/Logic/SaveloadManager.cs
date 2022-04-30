using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveloadManager : SingleTon<SaveloadManager>
{
    private List<ISaveable> saveableList = new List<ISaveable>();
    public List<DataSlot> dataSlots = new List<DataSlot>(new DataSlot[3]);

    private string jsonFolder;
    private int currentDataIndex;

    protected override void Awake()
    {
        base.Awake();
        jsonFolder = Application.persistentDataPath + "/SAVE DATA/";
        ReadSaveData();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     Save(currentDataIndex);
        // }

        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     Load(currentDataIndex);
        // }
    }

    private void OnEnable()
    {
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        EventHandler.EndGameEvent += OnEndGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        EventHandler.EndGameEvent -= OnEndGameEvent;
    }

    private void OnEndGameEvent()
    {
        Save(currentDataIndex);
    }

    private void OnStartNewGameEvent(int index)
    {
        currentDataIndex = index;
    }

    private void ReadSaveData()
    {
        if (Directory.Exists(jsonFolder))
        {
            for (int i = 0; i < dataSlots.Count; i++)
            {
                var resultPath = jsonFolder + "data" + i + ".json";
                if (File.Exists(resultPath))
                {
                    var stringData = File.ReadAllText(resultPath);
                    var jsonData = JsonConvert.DeserializeObject<DataSlot>(stringData);
                    dataSlots[i] = jsonData;
                }
            }
        }
    }

    public void RegisterSaveable(ISaveable saveable)
    {
        if (!saveableList.Contains(saveable))
        {
            saveableList.Add(saveable);
        }
    }

    public void Save(int index)
    {
        DataSlot data = new DataSlot();

        foreach (var saveable in saveableList)
        {
            data.dataDic.Add(saveable.GUID, saveable.GenerateSaveData());
        }

        dataSlots[index] = data;

        var resultPath = jsonFolder + "data" + index + ".json";

        var jsonData = JsonConvert.SerializeObject(dataSlots[index], Formatting.Indented);

        if (!File.Exists(resultPath))
        {
            Directory.CreateDirectory(jsonFolder);
        }
        
        Debug.Log("Data" + index + "Save!");

        File.WriteAllText(resultPath, jsonData);
    }

    public void Load(int index)
    {
        currentDataIndex = index;

        var resultPath = jsonFolder + "data" + index + ".json";

        var stringData = File.ReadAllText(resultPath);

        var jsonData = JsonConvert.DeserializeObject<DataSlot>(stringData);

        foreach (var saveable in saveableList)
        {
            saveable.RestoreData(jsonData.dataDic[saveable.GUID]);
        }
    }
}
