using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSlot
{
    /// <summary>
    /// 存档条/进度条
    /// </summary>
    /// <typeparam name="string"> GUID </typeparam>
    /// <typeparam name="GameSaveData"></typeparam>
    /// <returns></returns>
    public Dictionary<string, GameSaveData> dataDic = new Dictionary<string, GameSaveData>();
}
