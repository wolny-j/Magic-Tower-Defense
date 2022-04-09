using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEye : MonoBehaviour
{
    float nextFire;
    float fireRate = 1.1f;
    public GameObject spell;
    public GameObject hearth;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            GameObject spellClone = Instantiate(spell, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
        if(hearth== null)
        {
            Destroy(gameObject);
        }    
    }
}
