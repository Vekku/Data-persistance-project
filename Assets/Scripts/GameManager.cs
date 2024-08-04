using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public string currentName;
    public string highscoreName;
    public int highscore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public string currentName;
        public int highscore;
    }

    public class Highscore
    {

        public string name { get; set; }
        public int highscore { get; set; }

        public Highscore(string name, int highscore)
        {
            this.name = name;
            this.highscore = highscore;
        }
    }

    public void SaveCurrentName(string name)
    {
        this.currentName = name;
    }

    public void SaveScore(int score)
    {
        if (score > highscore)
        {
            highscoreName = currentName;
            highscore = score;
        }
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.currentName = currentName;
        if (highscoreName != null)
        {
            saveData.name = highscoreName;
            saveData.highscore = highscore;
        }

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            currentName = saveData.currentName;
            if (saveData.name != null)
            {
                highscoreName = saveData.name;
                highscore = saveData.highscore;
            }
        }
    }
}
