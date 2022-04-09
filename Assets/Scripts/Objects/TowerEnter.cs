using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerEnter : MonoBehaviour
{
    public GameObject doors;
    public GameObject towerWalls;
    public GameObject player;
    public AnimationClip doorOpen;
    public AnimationClip doorClose;
    public GameObject caveExit;
    Animation animator;
    public GameObject ladder;
    public bool inTower = false;
    public bool animPlay = false;
    Vector2 distance;
    Vector2 exitDistance;
    public Camera camera;
    float cameraSize1 = 14.91186f;
    float cameraSize2 = 6f;
    public float t = 0f;
    public bool zoom;

    void Start()
    {
        animator = GetComponent<Animation>();
        PlayerPrefs.SetInt("InTower", 0);
    }


    void Update()
    {
        distance = (player.transform.position - doors.transform.position);
        exitDistance = (player.transform.position - caveExit.transform.position);
        if (zoom)
        {
            camera.orthographicSize = Mathf.Lerp(cameraSize1, cameraSize2, t);

            t += 1f * Time.deltaTime;

        }
        else
        {
            camera.orthographicSize = Mathf.Lerp(cameraSize2, cameraSize1, t);

            t += 1f * Time.deltaTime;

        }




        if (distance.sqrMagnitude < 0.5 && distance.sqrMagnitude > -0.5)
        {
            if (Input.GetKeyDown(KeyCode.F) && inTower == false && animPlay == false)
            {
                zoom = true;
                t = 0;
                towerWalls.SetActive(true);
                animator.Play(doorOpen.name);
                animPlay = true;
                StartCoroutine(EnterTower(1));
                PlayerPrefs.SetInt("InTower", 1);
            }
            else if (Input.GetKeyDown(KeyCode.F) && inTower == true && animPlay == false)
            {
                player.GetComponent<SpriteRenderer>().sortingOrder = 0;
                towerWalls.SetActive(false);
                inTower = false;
                zoom = false;
                t = 0;
                animator.Play(doorClose.name);
                StartCoroutine(LeaveTower(1));
                PlayerPrefs.SetInt("InTower", 0);
                animPlay = true;
                ladder.SetActive(false);
            }
            if (inTower == true && Input.GetKeyDown(KeyCode.G))
            {
                player.GetComponent<SpriteRenderer>().sortingOrder = 0;
                towerWalls.SetActive(false);
                animator.Play(doorClose.name);
                animPlay = false;
                PlayerPrefs.SetInt("InTower", 0);
                inTower = false;
                player.transform.position = new Vector2(-70f, -43f);
            }
        }
        if (PlayerPrefs.GetInt("InTower") == 1)
        {
            if (distance.sqrMagnitude > 200 && distance.sqrMagnitude > -200)
            {
                player.transform.position = new Vector2(-59.47f, 0.21f);
            }
        }
        if (exitDistance.sqrMagnitude < 0.5 && exitDistance.sqrMagnitude > -0.5)
        {
            if (inTower == false && Input.GetKeyDown(KeyCode.G))
            {
                towerWalls.SetActive(true);
                animator.Play(doorOpen.name);
                animPlay = true;
                StartCoroutine(EnterTower(1));
                PlayerPrefs.SetInt("InTower", 1);

                player.transform.position = new Vector2(-60f, -6f);
            }
        }
    }

    IEnumerator EnterTower(int x)
    {

        yield return new WaitForSeconds(x);
        player.GetComponent<SpriteRenderer>().sortingOrder = -1;

        inTower = true;
        animPlay = false;
        ladder.SetActive(true);

    }
    IEnumerator LeaveTower(int x)
    {

        yield return new WaitForSeconds(x);
        animPlay = false;

    }
    IEnumerator WaitAndTp(int x)
    {

        yield return new WaitForSeconds(x);


    }


}
