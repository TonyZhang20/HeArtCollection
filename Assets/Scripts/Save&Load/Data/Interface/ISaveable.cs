
public interface ISaveable
{
    void RegisterSaveable()
    {
        SaveloadManager.Instance.RegisterSaveable(this);
    }
    GameSaveData GenerateSaveData();
    void RestoreData(GameSaveData saveData);
}
