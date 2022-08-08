using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public int playerScore;

    private MenuHandler menuHandler;

    void Awake()
    {
        if (Instance == null)
        {
            menuHandler = GameObject.Find("Canvas").GetComponent<MenuHandler>();

            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPLayerData();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();

        data.playerName = playerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path, json);
    }

    public void LoadPLayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            playerScore = data.playerScore;

            menuHandler.UpdatePlayerNameAndScore();
        }
    }
}
