using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public InputField inputName;

    public int highScore;
    public string playerName;
    public string bestPlayerName;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }

    public void SetPlayerName()
    {
        playerName = inputName.text;
    }

    [System.Serializable]
    class SavaData
    {
        public int highScore;
        public string userName;
    }

    public void SaveName()
    {
        SavaData data = new SavaData();
        data.highScore = highScore;
        data.userName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavaData data = JsonUtility.FromJson<SavaData>(json);

            highScore = data.highScore;
            playerName = data.userName;
        }
    }

}
