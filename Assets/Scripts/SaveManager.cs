using UnityEngine;
using UnityEngine.Serialization;

public static class SavesManager
{
    public static SavePlayerData SavePlayerData { get; private set; }
    private static void Save()
    {
        PlayerPrefs.SetString("SavedPlayer", JsonUtility.ToJson(SavePlayerData));
        PlayerPrefs.Save();
    }
    public static void Load()
    {
        SavePlayerData = JsonUtility.FromJson<SavePlayerData>(PlayerPrefs.GetString("SavedPlayer"));

        if (SavePlayerData == null)
        {
            SavePlayerData = new SavePlayerData(0);
            Save();
        }
    }
    public static void Reset()
    {
        SavePlayerData = new SavePlayerData(0);
        Save();
    }

    /// <summary>
    /// set volume to value and also save the entire savePlayerData
    /// </summary>
    /// <param name="value"></param>
    public static void SetBestScore(int value)
    {
        //SavePlayerData = new SavePlayerData(SavePlayerData, SavePlayerData,
        //  SavePlayerData, value);
        //According to chatgpt this code is better?
        SavePlayerData.bestScore = value;
    
        Save();
    }
}

[System.Serializable]
public class SavePlayerData
{
    public int bestScore;
    public SavePlayerData(int bestScore)
    {
        this.bestScore = bestScore;
    }
}