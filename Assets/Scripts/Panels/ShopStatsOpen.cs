using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStatsOpen : MonoBehaviour
{
    public GameObject player;
    public GameObject shopPanel;
    public GameObject statsPanel;
    public GameObject spellsPanel;
    public GameObject shopInfo;
    bool isShopOpened = false;
    bool isStatsOpened = false;
    bool isSpellsOpened = false;
    Vector2 distance;


    PlayerStats playerStats;
    GameObject towerObj;
    Tower tower;
    void Start()
    {
        PlayerPrefs.SetInt("NoShoot", 0);
        towerObj = GameObject.Find("Tower");

        tower = towerObj.GetComponent<Tower>();
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position);
        if (distance.sqrMagnitude < 15 && distance.sqrMagnitude > -15)
        {
            shopInfo.SetActive(true);
        }
        else
        {
            shopInfo.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C) && (distance.sqrMagnitude < 15 && distance.sqrMagnitude > -15) && isShopOpened == false && isStatsOpened == false && isSpellsOpened == false)
        {
            shopPanel.SetActive(true);
            //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y);
            isShopOpened = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            PlayerPrefs.SetInt("NoShoot", 1);
        }
        else if ((isShopOpened == true && Input.GetKeyDown(KeyCode.C)) || (isShopOpened == true && Input.GetKeyDown(KeyCode.Escape)))
        {
            shopPanel.SetActive(false);
            isShopOpened = false;
            //SavePlayer();
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            PlayerPrefs.SetInt("NoShoot", 0);
        }

        if (Input.GetKeyDown(KeyCode.V) && (distance.sqrMagnitude < 15 && distance.sqrMagnitude > -15) && isShopOpened == false && isStatsOpened == false && isSpellsOpened == false)
        {
            statsPanel.SetActive(true);

            isStatsOpened = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            PlayerPrefs.SetInt("NoShoot", 1);
        }
        else if ((isStatsOpened == true && Input.GetKeyDown(KeyCode.V)) || (isStatsOpened == true && Input.GetKeyDown(KeyCode.Escape)))
        {
            statsPanel.SetActive(false);

            isStatsOpened = false;
            //SavePlayer();
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            PlayerPrefs.SetInt("NoShoot", 0);
        }

        if (Input.GetKeyDown(KeyCode.X) && (distance.sqrMagnitude < 15 && distance.sqrMagnitude > -15) && isSpellsOpened == false && isStatsOpened == false && isShopOpened == false)
        {
            spellsPanel.SetActive(true);
            isSpellsOpened = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            PlayerPrefs.SetInt("NoShoot", 1);
        }
        else if ((isSpellsOpened == true && Input.GetKeyDown(KeyCode.X)) || (isSpellsOpened == true && Input.GetKeyDown(KeyCode.Escape)))
        {
            spellsPanel.SetActive(false);
            isSpellsOpened = false;
            //SavePlayer();
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            PlayerPrefs.SetInt("NoShoot", 0);
        }


    }


}
