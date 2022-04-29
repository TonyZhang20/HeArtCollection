using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public PlayerStats_SO playerStats;
    public float maxHealth { get => playerStats?.maxHealth ?? 0; set => playerStats.maxHealth = value; }
    public float currentHealth { get => playerStats?.health ?? 0; set => playerStats.health = value; }
    public float Money { get => playerStats?.Money ?? 0; set => playerStats.Money = value; }

    // public string GUID => GetComponent<DataGUID>().guid;

    private void Start()
    {
        // ISaveable saveable = this;
        // saveable.RegisterSaveable();
    }
    // public GameSaveData GenerateSaveData()
    // {
    //     GameSaveData saveData = new GameSaveData();
    //     saveData.playerStats = playerStats;
        
    //     return saveData;
    // }

    // public void RestoreData(GameSaveData saveData)
    // {
    //     playerStats = saveData.playerStats;
    // }
}
