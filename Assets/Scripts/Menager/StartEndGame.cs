using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartEndGame : MonoBehaviour
{
    public Button loadGame;
    public Text logs;
    void Start()
    {
        PlayerPrefs.SetInt("IsLoaded", 0);
    }
    void Update()
    {

        string path = Application.persistentDataPath + "/map1.save";

        if (!File.Exists(path))
        {
            loadGame.interactable = false;
        }
        else
        {
            loadGame.interactable = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void StartAndLoadGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("IsLoaded", 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
