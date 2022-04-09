using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x + 0.5f * Time.deltaTime, transform.localPosition.y);

        if (transform.localPosition.x > 70f)
        {
            transform.localPosition = new Vector2(-30, transform.localPosition.y);
        }
    }
}
