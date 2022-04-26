using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveloadManager : SingleTon<SaveloadManager>
{
    private List<ISaveable> saveableList = new List<ISaveable>();
    public void RegisterSaveable(ISaveable saveable)
    {
        if(!saveableList.Contains(saveable))
        {
            saveableList.Add(saveable);
        }
    }
}
