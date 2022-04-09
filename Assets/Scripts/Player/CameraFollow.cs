using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObj;
    public Camera cam;
    public GameObject moon;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 6)
        {
            cam.backgroundColor = new Color32(6, 0, 39, 1);
            moon.SetActive(true);
        }
        /*else if (player.transform.position.y < -8)
        {
            cam.backgroundColor = new Color32(164, 116, 73, 1);
        }*/
        else
        {
            cam.backgroundColor = new Color32(39, 214, 214, 1);
            moon.SetActive(false);
        }
        
        
        cameraObj.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z - 1f);
    }
    
}
