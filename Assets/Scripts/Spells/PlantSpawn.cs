using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerPrefs.GetInt("ActivateSpawn") == 1)
        {

            StartCoroutine(WaitSeconds(3));
            
        }
    }
    IEnumerator WaitSeconds(int x)
    {
        
        yield return new WaitForSeconds(x);
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
