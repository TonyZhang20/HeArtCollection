using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveData
{
    public string dataSceneName;
    /// <summary>
    /// Character Position Dictionnary
    /// </summary>
    public Dictionary<string, SerializableVector3> characterPosDict;

    /// <summary>
    /// InventoryData
    /// </summary>
    public Dictionary<string, List<InventoryItem>> inventoryDict;
    
    /// <summary>
    /// PlayerStats Save
    /// </summary>
    public PlayerStats_SO playerStats;
}
