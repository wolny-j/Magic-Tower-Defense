using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatReverse : MonoBehaviour
{
    Vector2 temp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (temp.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else if (temp.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        temp = transform.position;
    }
}
