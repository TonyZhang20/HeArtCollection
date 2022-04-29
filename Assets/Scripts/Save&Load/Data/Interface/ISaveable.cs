
public interface ISaveable
{
    string GUID { get; }
    void RegisterSaveable()
    {
        SaveloadManager.Instance.RegisterSaveable(this);
    }
    GameSaveData GenerateSaveData();
    void RestoreData(GameSaveData saveData);
}
