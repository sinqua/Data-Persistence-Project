using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuDataHandler : MonoBehaviour
{
    public static MenuDataHandler Instance;
    public TextMeshProUGUI title;

    public string playerName;

    public int bestScore;
    public string bestUser;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();

        title.text = "Best Score: " + bestScore;
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = bestUser;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestUser = data.name;
            bestScore = data.score;
        }
        else
        {
            bestScore = 0;
        }
    }
}
