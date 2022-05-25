using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public int playerScore;
    public string highScoreName;
    public int highScoreScore;
    public Text inputName;

    private List<SaveData> highScoreList;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSettings();
    }
    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        
    }

    [System.Serializable]
    private class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveSettings()
    {
        SaveData saveData = new SaveData();
        saveData.name = highScoreName;
        saveData.score = highScoreScore;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadSettings()
    {
        string dataFile = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(dataFile))
        {
            string json = File.ReadAllText(dataFile);
            SaveData loadData = JsonUtility.FromJson<SaveData>(json);

            highScoreName = loadData.name;
            highScoreScore = loadData.score;
        }
        
    }
    public void AfterNameUpdate()
    {
        playerName = inputName.text;
    }
}
