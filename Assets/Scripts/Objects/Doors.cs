using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    PlayerStats playerStats;
    public GameObject player;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject info;
    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerStats.p1.GetKeys() >= 1)
            {
                OpenDoor();
                info.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    void OpenDoor()
    {
        playerStats.p1.SubstractKeys();
        CheckKeys();
    }

    void CheckKeys()
    {
        if (playerStats.p1.GetKeys() == 0)
        {
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
        }
        else if (playerStats.p1.GetKeys() == 1)
        {
            key1.SetActive(true);
            key2.SetActive(false);
            key3.SetActive(false);
        }
        else if (playerStats.p1.GetKeys() == 2)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(false);
        }
        else if (playerStats.p1.GetKeys() == 3)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
        }
    }
}


