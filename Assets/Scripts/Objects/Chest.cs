using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    public GameObject player;
    public GameObject chestInfo;
    public Text chestText;
    Vector2 distance;
    public GameObject doors;
    void Start()
    {
        PlayerPrefs.SetInt("Scroll1", 0);
        PlayerPrefs.SetInt("Scroll2", 0);
        PlayerPrefs.SetInt("Scroll3", 0);
        PlayerPrefs.SetInt("Scroll4", 0);
        PlayerPrefs.SetInt("Scroll5", 0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (doors.activeSelf == false)
            {
                float random = Random.Range(1, 6);
                switch (random)
                {
                    case 1:
                        PlayerPrefs.SetInt("Scroll1", 1);
                        chestText.text = "Scroll of speed";
                        break;
                    case 2:
                        PlayerPrefs.SetInt("Scroll2", 1);
                        chestText.text = "Scroll of intelligence";
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Scroll3", 1);
                        chestText.text = "Scroll of mana";
                        break;
                    case 4:
                        PlayerPrefs.SetInt("Scroll4", 1);
                        chestText.text = "Scroll of slowness";
                        break;
                    case 5:
                        PlayerPrefs.SetInt("Scroll5", 1);
                        chestText.text = "Scroll of toughness";
                        break;


                }
                chestText.CrossFadeAlpha(0f, 3f, false);
                StartCoroutine(WaitToFade(3));
            }

        }
    }

    IEnumerator WaitToFade(int x)
    {

        yield return new WaitForSeconds(x);
        Destroy(chestInfo);
        Destroy(gameObject);
    }
}
