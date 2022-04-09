using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    public InputField input;
    public Text placeholder;
    public Text line1;
    public Text line2;
    public Text line3;
    public Text line4;
    public Text line5;
    public Text line6;
    GameObject player;
    PlayerStats playerStats;
    public GameObject pixie;
    KnightEnemy addkey;

    void Start()
    {
        player = GameObject.Find("Player");

        playerStats = player.GetComponent<PlayerStats>();
    }


    // Update is called once per frame
    void Update()
    {
        input.Select();
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            EnterButton();
        }
    }

    public void EnterButton()
    {
        string command = input.text;

        string value;
        bool success = false;
        switch (command.Split(':')[0])
        {
            case "cash":
                int money = 0;
                value = command.Split(':')[1];
                success = int.TryParse(value, out money);
                if (success)
                {
                    playerStats.p1.AddGold(money);
                    EnterToLine(money + " gold successfully added");
                }
                else
                {
                    EnterToLine("Wrong number after 'cash' command");
                }
                break;
            case "level":
                int level = 0;
                value = command.Split(':')[1];
                success = int.TryParse(value, out level);
                if (success)
                {
                    playerStats.p1.AddLevel(level);
                    if (level == 1)
                    {

                        EnterToLine(level + " level successfully added");
                    }
                    else
                    {
                        EnterToLine(level + " levels successfully added");
                    }
                }
                else
                {
                    EnterToLine("Wrong value after 'level' command");
                }
                break;
            case "hp":
                int hp = 0;
                value = command.Split(':')[1];
                success = int.TryParse(value, out hp);
                if (success)
                {
                    playerStats.p1.AddHealth(hp);
                    EnterToLine(hp + " hp successfully added");
                }
                else
                {
                    EnterToLine("Wrong value after 'hp' command");
                }
                break;
            case "skillpoints":
                int skillpoints = 0;
                value = command.Split(':')[1];
                success = int.TryParse(value, out skillpoints);
                if (success)
                {
                    playerStats.p1.AddSkillPoints(skillpoints);
                    EnterToLine(skillpoints + " skill points successfully added");
                }
                else
                {
                    EnterToLine("Wrong value after 'skillpoints' command");
                }
                break;
            case "pixie":

                value = command.Split(':')[1];

                if (value == "on")
                {
                    pixie.SetActive(true);
                    EnterToLine("Pixie set active = true");
                }
                else if (value == "off")
                {
                    pixie.SetActive(false);
                    EnterToLine("Pixie set active = false");
                }
                else
                {
                    EnterToLine("Wrong value after 'pixie' command");
                }
                break;
            case "addkey":

                EnterToLine("2 Keys Added");
                playerStats.p1.AddKeys();
                playerStats.p1.AddKeys();


                break;
            default:
                EnterToLine("Wrong command: " + command);
                break;
        }
        placeholder.text = "Enter text...";
        input.text = "";
        input.Select();
    }

    void EnterToLine(string output)
    {
        line6.text = line5.text;
        line5.text = line4.text;
        line4.text = line3.text;
        line3.text = line2.text;
        line2.text = line1.text;
        line1.text = output;
    }
}
