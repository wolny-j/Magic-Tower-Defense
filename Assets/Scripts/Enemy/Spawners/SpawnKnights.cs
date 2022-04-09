using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnights : MonoBehaviour
{

    public GameObject knight;
    int enemies;
    List<GameObject> knights = new List<GameObject>();
    bool isChecked = false;
    bool wave1 = true;
    bool wave2 = true;
    int intervals;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("IsWave") == 1)
        {
            switch (PlayerPrefs.GetInt("Wave"))
            {
                case 1:
                    if (wave1)
                    {
                        enemies = 2;
                        wave1 = false;
                        intervals = 8;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 6;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;


                        }
                    }
                    break;
                case 2:
                    if (wave2)
                    {
                        enemies = 3;
                        wave2 = false;
                        wave1 = true;
                        intervals = 4;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 3:
                    if (wave1)
                    {
                        enemies = 3;
                        wave2 = true;
                        wave1 = false;
                        intervals = 3;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 4:
                    if (wave2)
                    {
                        enemies = 1;
                        wave2 = false;
                        wave1 = true;
                        intervals = 8;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 5:
                    if (wave1)
                    {
                        enemies = 3;
                        wave1 = false;
                        wave2 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 6:
                    if (wave2)
                    {
                        enemies = 3;
                        wave2 = false;
                        wave1 = true;
                        intervals = 3;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 7:
                    if (wave1)
                    {
                        enemies = 4;
                        wave1 = false;
                        wave2 = true;
                        intervals = 6;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 8:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 6;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 3;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 9:
                    if (wave1)
                    {
                        enemies = 3;
                        wave1 = false;
                        wave2 = true;
                        intervals = 3;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 10:
                    if (wave2)
                    {
                        enemies = 0;
                        wave2 = false;
                        wave1 = true;
                        intervals = 7;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 11:
                    if (wave1)
                    {
                        enemies = 3;
                        wave1 = false;
                        wave2 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 12:
                    if (wave2)
                    {
                        enemies = 5;
                        wave2 = false;
                        wave1 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 13:
                    if (wave1)
                    {
                        enemies = 2;
                        wave1 = false;
                        wave2 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 14:
                    if (wave2)
                    {
                        enemies = 4;
                        wave2 = false;
                        wave1 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 15:
                    if (wave1)
                    {
                        enemies = 6;
                        wave1 = false;
                        wave2 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 16:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 6;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 17:
                    if (wave1)
                    {
                        enemies = 7;
                        wave1 = false;
                        wave2 = true;
                        intervals = 7;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 18:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 7;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 19:
                    if (wave1)
                    {
                        enemies = 4;
                        wave1 = false;
                        wave2 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 20:
                    if (wave2)
                    {
                        enemies = 5;
                        wave2 = false;
                        wave1 = true;
                        intervals = 4;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 21:
                    if (wave1)
                    {
                        enemies = 6;
                        wave1 = false;
                        wave2 = true;
                        intervals = 7;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 22:
                    if (wave2)
                    {
                        enemies = 7;
                        wave2 = false;
                        wave1 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 23:
                    if (wave1)
                    {
                        enemies = 6;
                        wave1 = false;
                        wave2 = true;
                        intervals = 4;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 24:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 25:
                    if (wave1)
                    {
                        enemies = 4;
                        wave1 = false;
                        wave2 = true;
                        intervals = 4;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 26:
                    if (wave2)
                    {
                        enemies = 5;
                        wave2 = false;
                        wave1 = true;
                        intervals = 8;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 4;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 27:
                    if (wave1)
                    {
                        enemies = 5;
                        wave1 = false;
                        wave2 = true;
                        intervals = 8;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 28:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 6;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 6;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 29:
                    if (wave1)
                    {
                        enemies = 6;
                        wave1 = false;
                        wave2 = true;
                        intervals = 8;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 30:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 31:
                    if (wave1)
                    {
                        enemies = 6;
                        wave1 = false;
                        wave2 = true;
                        intervals = 8;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 32:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 33:
                    if (wave1)
                    {
                        enemies = 4;
                        wave1 = false;
                        wave2 = true;
                        intervals = 2;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 34:
                    if (wave2)
                    {
                        enemies = 4;
                        wave2 = false;
                        wave1 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 35:
                    if (wave1)
                    {
                        enemies = 4;
                        wave1 = false;
                        wave2 = true;
                        intervals = 4;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 36:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 8;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 37:
                    if (wave1)
                    {
                        enemies = 6;
                        wave1 = false;
                        wave2 = true;
                        intervals = 4;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 38:
                    if (wave2)
                    {
                        enemies = 6;
                        wave2 = false;
                        wave1 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 39:
                    if (wave1)
                    {
                        enemies = 7;
                        wave1 = false;
                        wave2 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
                case 40:
                    if (wave2)
                    {
                        enemies = 8;
                        wave2 = false;
                        wave1 = true;
                        intervals = 5;
                        isChecked = false;
                    }
                    if (PlayerPrefs.GetFloat("Timer") > intervals && enemies > 0)
                    {
                        GameObject enemy = Instantiate(knight, transform.position, Quaternion.identity);
                        knights.Add(enemy);
                        intervals += 5;
                        enemies--;

                    }
                    if (enemies == 0)
                    {
                        if (noEnemiesLeft() == true && isChecked == false)
                        {
                            PlayerPrefs.SetInt("WavePart", PlayerPrefs.GetInt("WavePart") + 1);
                            isChecked = true;

                        }
                    }
                    break;
            }
        }
    }
    private bool noEnemiesLeft()
    {
        for (int i = 0; i < knights.Count; i++)
        {
            // inverted your condition; we can short-circuit
            // and just return false
            if (knights[i] != null)
            {
                return false;
            }
        }
        // every brick passed our condition, so return true
        return true;
    }
}
