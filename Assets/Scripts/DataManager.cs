using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string highPlayer;
    public int highScore;
    private MainManager mainManager;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneLoader()
    {
        playerName = GameObject.Find("Name Input").GetComponent<InputField>().text;
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public string highPlayer;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highPlayer = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highPlayer = data.highPlayer;
            highScore = data.highScore;
        }
        else
        {
            highScore = 0;
            highPlayer = "No One";
        }
    }
}
