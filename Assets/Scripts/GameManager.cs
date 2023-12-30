using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName = "";
    public string highestScorePlayerName = "";
    public int score = 999;
    private void Awake(){
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }
    public void SaveHighestScoreData(int score)
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SetPlayerName(string name){
        playerName = name;
    }

    public void LoadHighestScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highestScorePlayerName = data.playerName;
            score = data.score;
        }
    }

    public void EraseScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
