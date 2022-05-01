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

    public Dictionary<string, List<SceneItem>> sceneItemDict;
    public Dictionary<string, List<DialoguePrefabInfo>> DialogueDict;
    /// <summary>
    /// InventoryData
    /// </summary>
    public Dictionary<string, List<InventoryItem>> inventoryDict;
    
    /// <summary>
    /// PlayerStats Save
    /// </summary>
    public float currentHealth;
    public float maxHealth;
    public float Money;
    /// <summary>
    /// Portal
    /// </summary>
    public bool CanTravel;
}
