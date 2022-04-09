using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    [SerializeField]
    GameObject spell;
    [SerializeField]
    GameObject spellTower;
    [SerializeField]
    GameObject meteorSpawn1;
    [SerializeField]
    GameObject meteor;

    float fireRate;
    float nextFire;
    GameObject enemyStop;
    GameObject player;
    Vector2 distance;
    bool move = true;
    float health;
    float maxHealth;
    public Slider healthBar;
    public Image hp;
    float moveSpeed = 1.5f;
    Vector2 localScale;
    Rigidbody2D rb;
    PlayerStats playerStats;
    CastingSpells controller2D;
    bool fired = false;
    float firedCounter = 0;
    int fireRepeat = 0;
    public SpriteRenderer sprite;
    bool frosted = false;
    float frostCounter = 0;
    public bool aimTower = false;
    GameObject tree;
    Vector2 treeDistance;
    public bool treeTouched = false;
    bool shoot = true;
    bool isMeteor = false;

    void Start()
    {

        fireRate = 1f;
        nextFire = Time.time;

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        controller2D = player.GetComponent<CastingSpells>();
        enemyStop = GameObject.Find("EnemyStop");
        maxHealth = 2500 + (PlayerPrefs.GetInt("Wave") * 2);
        health = maxHealth;
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("EnemyKnight").GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1500 && isMeteor == false)
        {
            moveSpeed = 0;
            isMeteor = true;
            shoot = false;
            StartCoroutine(SpawnMeteors(1));
        }
        else if (health < 1000)
        {
            shoot = true;
            isMeteor = true;
            moveSpeed = 1.5f;
        }
        if (treeTouched)
        {

            treeDistance = (tree.transform.position - transform.position);
            if (treeDistance.sqrMagnitude < 20)
            {
                move = false;
            }
            else
            {
                move = true;
            }
        }
        distance = (player.transform.position - transform.position);

        if (shoot)
        {
            if (Time.time > nextFire && (distance.sqrMagnitude < 1400 && distance.sqrMagnitude > -1400) && move == true)
            {
                GameObject spellClone = Instantiate(spell, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
            else if (!move && Time.time > nextFire)
            {
                GameObject spellClone = Instantiate(spellTower, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
        if (transform.position.x < enemyStop.transform.position.x)
        {
            move = false;
            aimTower = true;
            rb.velocity = new Vector2(0f, 0f);
            rb.mass = 100;

        }
        else
        {
            move = true;
        }

        if (health <= 0)
        {
            playerStats.p1.AddGold(200);
            if (PlayerPrefs.GetInt("Scroll2") == 0)
            {
                playerStats.p1.AddExp(15);
            }
            else if (PlayerPrefs.GetInt("Scroll2") == 1)
            {
                playerStats.p1.AddExp(18);
            }

            AddKey();
            playerStats.p1.AddBooks();
            PlayerPrefs.SetInt("AddBook", 1);
            PlayerPrefs.SetFloat("Gold", PlayerPrefs.GetFloat("Gold") + 200);
            Destroy(gameObject);
        }

        if (health < (maxHealth * 0.3))
        {
            hp.color = new Color32(255, 0, 48, 255);
        }


        healthBar.value = health;
        healthBar.maxValue = maxHealth;

    }

    private void FixedUpdate()
    {
        if (move == true)
        {
            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jump")
        {

            rb.AddForce(Vector2.up * 3600f);
        }

        if (collision.gameObject.tag == "Tree")
        {

            tree = collision.gameObject;
            treeTouched = true;
        }

        if (collision.gameObject.tag == "Spell")
        {
            if (PlayerPrefs.GetInt("Spell1") >= 1)
            {
                if (controller2D.facingRight == true)
                {
                    rb.AddForce(new Vector2((PlayerPrefs.GetInt("Spell1") * 4000), 0f));
                }
            }
            health -= playerStats.p1.GetAttack() * 6;
            healthBar.value = health;
        }
        if (collision.gameObject.tag == "FireSpell")
        {

            health -= playerStats.p1.GetAttack() * 8;
            healthBar.value = health;
            fired = true;

        }
        if (collision.gameObject.tag == "FrostSpell")
        {
            health -= playerStats.p1.GetAttack() * 8;
            healthBar.value = health;
            moveSpeed = moveSpeed / 3;
            frosted = true;
        }
        if (collision.gameObject.tag == "PixieSpell")
        {
            health -= (playerStats.p1.GetAttack() * 6) / 4;
            healthBar.value = health;

        }
        if (collision.gameObject.tag == "Enemy")
        {
            move = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            move = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyKnight")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.gameObject.tag == "EnemyTank")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.collider.tag == "Ladder")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.collider.tag == "Wall")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }

    }

    void AddKey()
    {
        if (Random.Range(1, 1000) <= 15 && playerStats.p1.GetKeys() < 3)
        {
            playerStats.p1.AddKeys();
        }
    }
    void AddBook()
    {
        if (Random.Range(1, 1000) <= 40)
        {
            playerStats.p1.AddBooks();
            PlayerPrefs.SetInt("AddBook", 1);
        }
    }
    IEnumerator SpawnMeteors(int x)
    {
        yield return new WaitForSeconds(0.5f);
        int rand = Random.Range(-5, 5);
        Instantiate(meteor, new Vector3(player.transform.position.x + rand, transform.position.y + 30), Quaternion.identity);
        yield return new WaitForSeconds(x);
        rand = Random.Range(-5, 5);
        Instantiate(meteor, new Vector3(player.transform.position.x + rand, transform.position.y + 30), Quaternion.identity);
        yield return new WaitForSeconds(x);
        rand = Random.Range(-5, 5);
        Instantiate(meteor, new Vector3(player.transform.position.x + rand, transform.position.y + 30), Quaternion.identity);
        isMeteor = false;

    }
}
