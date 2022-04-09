using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthMovement : MonoBehaviour
{
    float x;
    float y;
    float speed = 6f;

    void Start()
    {
        x = Random.Range(0, 30);
        y = Random.Range(0, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.localPosition= Vector3.MoveTowards(transform.localPosition, new Vector2(x, y), step);

        if(transform.localPosition == new Vector3(x, y, transform.localPosition.z))
        {
            x = Random.Range(0, 30);
            y = Random.Range(0, 4.5f);
        }
    }
}
