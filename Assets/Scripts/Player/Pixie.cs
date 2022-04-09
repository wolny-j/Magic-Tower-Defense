using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixie : MonoBehaviour
{
    float x;
    float y;
    float speed = 3f;
    public GameObject spell;
    Vector2 castPoint;
    public float castingSpeed = 2;
    float counter = 0;

    void Start()
    {
        x = Random.Range(-4, 4);
        y = Random.Range(0, 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > castingSpeed)
        {
            Shoot();
            counter = 0;
        }
        float step = speed * Time.deltaTime;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(x, y), step);

        if (transform.localPosition == new Vector3(x, y, transform.localPosition.z))
        {
            x = Random.Range(-4, 4);
            y = Random.Range(0, 5.5f);
        }
    }

    void Shoot()
    {
        castPoint = transform.position;
        GameObject spellClone = Instantiate(spell, castPoint, Quaternion.identity);
    }
}
