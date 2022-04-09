using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    float counter = 5;

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if(counter < 0)
        {
            Destroy(gameObject);
        }
    }
}
