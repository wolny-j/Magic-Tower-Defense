using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    GameObject laser;
    Vector3 temp;
    float timer;
    bool setup = false;
    bool setHeight = false;
    Vector3 start;
    void Start()
    {
        start = laser.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (setHeight == false)
        {
            laser.transform.position = new Vector3(-23.9571f, Random.Range(-7, -1.5f), 0);
            setHeight = true;
        }
        timer += Time.deltaTime;
        if (timer > 2 && timer < 4)
        {
            laser.transform.localScale += new Vector3(0, 0.0008f, 0);
            temp = laser.transform.localScale;
        }
        else if (timer > 4 && timer < 4.1f)
        {
            laser.transform.localScale = new Vector3(0, 0.000f, 0);
        }
        else if (timer > 4.3 && timer < 5)
        {
            if (setup == false)
            {
                laser.transform.localScale = new Vector3(0, 0.8f, 0);
                setup = true;
            }
            laser.transform.localScale += new Vector3(1f, 0, 0);
        }
        else if (timer > 5)
        {
            laser.transform.localScale = start;
            timer = 0;
            setup = false;
            setHeight = false;
        }
    }
}
