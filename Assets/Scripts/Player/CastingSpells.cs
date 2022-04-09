using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingSpells : MonoBehaviour
{
    public GameObject player;
    public GameObject spell;
    public GameObject fireSpell;
    public GameObject firePoint;
    public GameObject pixieFirePoint;
    public GameObject frostSpell;
    public GameObject natureSpell;
    public GameObject tree;
    public float spellSpeed = 50;
    PlayerStats playerStats;
    WeaponChoice weaponChoice;
    public bool facingRight;
    PlayerMovement playerMovement;
    public GameObject pixie;

    Vector3 lookDirection;
    float lookAngle;

    public int s1Counter;
    public int s2Counter;
    public int s3Counter;
    public int s4Counter;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerStats = player.GetComponent<PlayerStats>();
        weaponChoice = playerStats.GetComponent<WeaponChoice>();
    }
    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        //firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (lookDirection.x > transform.position.x)
        {

            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            pixie.transform.eulerAngles = new Vector3(transform.rotation.x, -180f, transform.rotation.z);
            facingRight = true;

        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            pixie.transform.eulerAngles = new Vector3(transform.rotation.x, -180f, transform.rotation.z);
            facingRight = false;
        }
        if (PlayerPrefs.GetInt("NoShoot") == 0)
        {
            switch (playerStats.inventory.GetItem(weaponChoice.counter).GetName())
            {
                case "Plasma":
                    if (Input.GetMouseButtonDown(0) && playerStats.p1.GetMana() >= 1.1f)
                    {
                        if (PlayerPrefs.GetInt("Scroll3") == 0)
                        {
                            playerStats.p1.SubstractMana(1.1f);
                        }
                        else if (PlayerPrefs.GetInt("Scroll3") == 1)
                        {
                            playerStats.p1.SubstractMana(0.9f);
                        }

                        firePoint.SetActive(true);
                        Vector2 castPoint;
                        s1Counter++;
                        if (facingRight)
                        {
                            castPoint = new Vector2(transform.position.x + 1, transform.position.y + 1);
                        }
                        else
                        {
                            castPoint = new Vector2(transform.position.x - 1, transform.position.y + 1);
                        }
                        firePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        pixieFirePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);

                        GameObject spellClone = Instantiate(spell, castPoint, Quaternion.identity);
                        //spellClone.transform.position = player.transform.position;
                        PlayerPrefs.SetInt("IsCasted", 1);


                    }
                    break;
                case "Fire":
                    if (Input.GetMouseButtonDown(0) && playerStats.p1.GetMana() >= 10)
                    {
                        if (PlayerPrefs.GetInt("Scroll3") == 0)
                        {
                            playerStats.p1.SubstractMana(10f);
                        }
                        else if (PlayerPrefs.GetInt("Scroll3") == 1)
                        {
                            playerStats.p1.SubstractMana(8f);
                        }
                        firePoint.SetActive(true);
                        firePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        pixieFirePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        s2Counter++;
                        if (lookDirection.x < transform.position.x)
                        {
                            GameObject spellClone = Instantiate(fireSpell, new Vector3(transform.position.x - 1.2f, transform.position.y - 2), Quaternion.identity);
                        }
                        else
                        {
                            GameObject spellClone = Instantiate(fireSpell, new Vector3(transform.position.x + 1.2f, transform.position.y - 2), Quaternion.identity);
                        }
                        //GameObject spellClone = Instantiate(fireSpell, transform.position, Quaternion.identity);
                        //spellClone.transform.position = player.transform.position;
                        PlayerPrefs.SetInt("IsCasted", 1);


                    }
                    break;
                case "Frost":
                    if (Input.GetMouseButtonDown(0) && playerStats.p1.GetMana() >= 6)
                    {
                        if (PlayerPrefs.GetInt("Scroll3") == 0)
                        {
                            playerStats.p1.SubstractMana(6);
                        }
                        else if (PlayerPrefs.GetInt("Scroll3") == 1)
                        {
                            playerStats.p1.SubstractMana(4.5f);
                        }
                        firePoint.SetActive(true);
                        firePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        pixieFirePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        s3Counter++;
                        GameObject spellClone = Instantiate(frostSpell, transform.position, Quaternion.identity);
                        //spellClone.transform.position = player.transform.position;
                        PlayerPrefs.SetInt("IsCasted", 1);


                    }
                    break;
                case "Nature":
                    if (Input.GetMouseButtonDown(0) && playerStats.p1.GetMana() >= 17 && PlayerPrefs.GetInt("IsWave") == 1 && playerMovement.isGrounded == true)
                    {
                        if (PlayerPrefs.GetInt("Scroll3") == 0)
                        {
                            playerStats.p1.SubstractMana(17f);
                        }
                        else if (PlayerPrefs.GetInt("Scroll3") == 1)
                        {
                            playerStats.p1.SubstractMana(13f);
                        }
                        firePoint.SetActive(true);
                        s4Counter++;
                        firePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        pixieFirePoint.transform.position = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z);
                        if (lookDirection.x < transform.position.x)
                        {
                            GameObject spellClone = Instantiate(tree, new Vector3(transform.position.x - 1.2f, transform.position.y - .5f), Quaternion.identity);
                        }
                        else
                        {
                            GameObject spellClone = Instantiate(tree, new Vector3(transform.position.x + 1.2f, transform.position.y - .5f), Quaternion.identity);
                        }
                        //spellClone.transform.position = player.transform.position;
                        PlayerPrefs.SetInt("IsCasted", 1);


                    }
                    break;

            }
        }

    }
}
