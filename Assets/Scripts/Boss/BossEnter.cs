using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour
{
    public Camera camera;
    float cameraSize1 = 14.91186f;
    float cameraSize2 = 6f;
    float t = 0f;
    bool zoom = false;
    public GameObject doors;
    TowerEnter towerEnter;
    void Start()
    {
        towerEnter = doors.GetComponent<TowerEnter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (towerEnter.zoom)
            {
                towerEnter.zoom = false;
                towerEnter.t = 0;
            }
            else
            {
                towerEnter.zoom = true;
                towerEnter.t = 0;
            }
        }
    }
}
