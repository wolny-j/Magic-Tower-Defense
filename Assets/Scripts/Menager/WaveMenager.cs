using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveMenager : MonoBehaviour
{
    public Text waveInfo;
    public Text waveNumber;
    GameObject towerObj;
    Tower tower;
    GameObject player;
    CastingSpells castingSpells;
    PlayerStats playerStats;
    GameObject playerStatsObject;
    GameObject shopObj;

    void Start()
    {
        PlayerPrefs.SetInt("WavePart", 7);

        PlayerPrefs.SetFloat("Timer", 0);
        PlayerPrefs.SetInt("ActivateSpawn", 0);
        PlayerPrefs.SetInt("IsWave", 0);
        player = GameObject.Find("Player");
        towerObj = GameObject.Find("Tower");
        shopObj = GameObject.Find("ShopPanel");
        playerStats = player.GetComponent<PlayerStats>();
        tower = towerObj.GetComponent<Tower>();
        castingSpells = player.GetComponent<CastingSpells>();

    }

    // Update is called once per frame
    void Update()
    {
        waveNumber.text = PlayerPrefs.GetInt("Wave").ToString();
        PlayerPrefs.SetFloat("Timer", PlayerPrefs.GetFloat("Timer") + Time.deltaTime);
        if (PlayerPrefs.GetInt("WavePart") == 7)
        {
            waveInfo.text = "Press enter for next wave";
            if (PlayerPrefs.GetInt("Wave") == 40)
            {
                waveInfo.text = "YOU WON! Press enter for end game";
            }

            PlayerPrefs.SetInt("IsWave", 0);
            SavePlayer();
            //PlayerPrefs.SetInt("Wave", PlayerPrefs.GetInt("Wave") + 1);
            if (Input.GetKeyDown(KeyCode.Return))
            {

                PlayerPrefs.SetInt("Wave", PlayerPrefs.GetInt("Wave") + 1);
                PlayerPrefs.SetInt("WavePart", 0);
                PlayerPrefs.SetFloat("Timer", 0);
                PlayerPrefs.SetInt("IsWave", 1);
                waveInfo.text = "";



                StartCoroutine(WaitSeconds(5));

            }
        }

    }
    IEnumerator WaitSeconds(int x)
    {
        PlayerPrefs.SetInt("ActivateSpawn", 1);
        yield return new WaitForSeconds(x);
        PlayerPrefs.SetInt("ActivateSpawn", 0);

    }
    public void RestatGame()
    {
        SaveSystem.DeletePlayer();
        SceneManager.LoadScene(0);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerStats, tower, castingSpells);
    }

}
