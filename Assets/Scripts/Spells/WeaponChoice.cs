using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoice : MonoBehaviour
{
    
    public Text currentSpell;
    GameObject player;
    PlayerStats playerStats;
    public int counter = 0;
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    public Image slot5;
    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpell.text = playerStats.inventory.GetItem(counter).GetName();
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            counter = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerStats.inventory.GetSize() >= 2)
            {
                counter = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerStats.inventory.GetSize() >= 3)
            {
                counter = 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (playerStats.inventory.GetSize() >= 4)
            {
                counter = 3;
            }
        }

        switch (counter)
        {
            case 0:
                if (playerStats.inventory.GetSize() == 3)
                {
                    slot1.color = new Color32(209, 199, 101, 255);
                    slot2.color = new Color32(176, 176, 176, 255);
                    slot3.color = new Color32(176, 176, 176, 255);
                    slot4.color = new Color32(176, 176, 176, 255);
                }
                else
                {
                    slot1.color = new Color32(209, 199, 101, 255);
                    slot2.color = new Color32(176, 176, 176, 255);
                    slot4.color = new Color32(176, 176, 176, 255);
                    slot3.color = new Color32(176, 176, 176, 255);
                }
                    break;
            case 1:
                slot2.color = new Color32(209, 199, 101, 255);
                slot1.color = new Color32(176, 176, 176, 255);
                slot3.color = new Color32(176, 176, 176, 255);
                slot4.color = new Color32(176, 176, 176, 255);
                break;
            case 2:
                if (playerStats.inventory.GetSize() == 3)
                {
                    slot3.color = new Color32(209, 199, 101, 255);
                    slot2.color = new Color32(176, 176, 176, 255);
                    slot1.color = new Color32(176, 176, 176, 255);
                    slot4.color = new Color32(176, 176, 176, 255);
                }
                else if (playerStats.inventory.GetSize() == 4)
                {
                    slot3.color = new Color32(209, 199, 101, 255);
                    slot2.color = new Color32(176, 176, 176, 255);
                    slot4.color = new Color32(176, 176, 176, 255);
                    slot1.color = new Color32(176, 176, 176, 255);
                }
                break;
            case 3:
                slot4.color = new Color32(209, 199, 101, 255);
                slot1.color = new Color32(176, 176, 176, 255);
                slot3.color = new Color32(176, 176, 176, 255);
                slot2.color = new Color32(176, 176, 176, 255);
                break;
            /*case 4:
                slot5.color = new Color32(209, 199, 101, 255);
                slot1.color = new Color32(176, 176, 176, 255);
                slot4.color = new Color32(176, 176, 176, 255);
                break;*/
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            counter++;
            
            if (counter >= playerStats.inventory.GetSize())
            {
                counter = 0;
            }
            currentSpell.text = playerStats.inventory.GetItem(counter).GetName();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            counter--;
            
            if (counter < 0)
            {
                counter = playerStats.inventory.GetSize() - 1;
            }
            currentSpell.text = playerStats.inventory.GetItem(counter).GetName();
        }

    }
}
