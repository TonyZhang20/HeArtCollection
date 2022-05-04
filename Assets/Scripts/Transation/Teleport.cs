using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DataGUID))]
public class Teleport : MonoBehaviour
//, ISaveable
{
    public string sceneToGo;
    public Vector3 positionToGo;
    public bool CanTravel = true;
    public string GUID => GetComponent<DataGUID>().guid;
    private void Start()
    {
        // ISaveable saveable = this;
        // saveable.RegisterSaveable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && CanTravel)
        {
            EventHandler.CallTransitionEvent(sceneToGo, positionToGo);
        }
    }

    public void CanNotTravel()
    {
        CanTravel = false;
    }

    public void CanTeleport()
    {
        CanTravel = true;
    }

    // public GameSaveData GenerateSaveData()
    // {
    //     GameSaveData gameSave = new GameSaveData();
    //     gameSave.CanTravel = CanTravel;
    //     return gameSave;
    // }

    // public void RestoreData(GameSaveData saveData)
    // {
    //     CanTravel = saveData.CanTravel;
    // }
}
