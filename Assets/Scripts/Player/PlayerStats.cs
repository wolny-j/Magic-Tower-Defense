using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public GameObject shopObj;
    Shop shop;

    GameObject towerObj;
    Tower tower;
    public Slider healthBar;
    public Slider manaBar;
    public Slider expBar;

    public Text gold;
    public Text level;
    public Player p1 = new Player("p1", 100, 100, 20, 0.11f, 0, 0, 3, 1, 3, 5, 3, 10, 3, 40, 0, 0);
    float manacCounter = 0;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public Text hpPotionsText;
    public Text manaPotionsText;
    public Image hp;
    public Inventory inventory;
    public PlayerStats playerStats;
    public Rigidbody2D rb;
    public GameObject spikes;
    public Slider spikesBar;
    public GameObject spikesBarObject;
    float spikesCounter = 3;
    bool isSpikes = false;
    Vector2 temp;
    float maxExp = 100;
    bool isManaReseted = false;
    public Text newLvl;
    public Text booksInfo;
    public GameObject infoDot;
    bool fired = false;
    float firedCounter;

    public GameObject fireSpell1;
    public GameObject fireSpell2;
    public GameObject fireSpell3;
    public GameObject natureSpell1;
    public GameObject natureSpell2;
    public GameObject natureSpell3;
    public GameObject frostSpell1;
    public GameObject frostSpell2;
    public GameObject frostSpell3;
    public GameObject chest;
    public GameObject doors;

    public int hpPotionCounter = 0;
    public int manaPotionCounter = 0;
    public int deathsCounter = 0;
    CastingSpells castingSpells;
    GameObject menager;
    public GameObject gameOverPanel;
    bool db = false;
    SaveToDB saveToDB;
    public GameObject commandConsole;

    public GameObject littleFriend;
    public InputField inputField;

    void Start()
    {

        p1.SetName(PlayerPrefs.GetString("Username"));
        PlayerPrefs.SetString("Username", "Player");
        PlayerPrefs.SetInt("Spell1", 0);
        PlayerPrefs.SetInt("Spell2", 0);
        PlayerPrefs.SetInt("Spell3", 0);
        PlayerPrefs.SetInt("Spell4", 0);
        PlayerPrefs.SetInt("Unlock1", 0);
        PlayerPrefs.SetInt("Unlock2", 0);
        PlayerPrefs.SetInt("Unlock3", 0);
        PlayerPrefs.SetInt("Wave", 0);
        newLvl.CrossFadeAlpha(0f, 0.01f, false);
        booksInfo.CrossFadeAlpha(0f, 0.01f, false);
        inventory = new Inventory();
        CheckKeys();
        towerObj = GameObject.Find("Tower");

        tower = towerObj.GetComponent<Tower>();
        shop = shopObj.GetComponent<Shop>();
        castingSpells = player.GetComponent<CastingSpells>();
        menager = GameObject.Find("DBmenager");
        saveToDB = menager.GetComponent<SaveToDB>();
        playerStats = player.GetComponent<PlayerStats>();

        if (PlayerPrefs.GetInt("IsLoaded") == 1)
        {
            PlayerData data = SaveSystem.LoadPlayer();

            p1 = new Player(data.name, data.health, data.maxHp, data.mana,
            data.manaRegen, data.gold, data.exp, data.slillPoint, (int)data.level,
            data.attack, data.defence, data.manaPotion, data.manaPotionPower,
            data.hpPotion, data.hpPotionPower, data.keys, data.books);

            if (data.isLittleFriend == true)
            {
                littleFriend.SetActive(true);
            }
            else
            {
                littleFriend.SetActive(false);
            }

            Debug.Log(PlayerPrefs.GetInt("Unlock1"));
            Debug.Log(PlayerPrefs.GetInt("Unlock2"));
            Debug.Log(PlayerPrefs.GetInt("Unlock3"));
            PlayerPrefs.SetInt("Unlock1", data.fireSpell);
            PlayerPrefs.SetInt("Unlock2", data.frostSpell);
            PlayerPrefs.SetInt("Unlock3", data.natureSpell);

            Debug.Log(PlayerPrefs.GetInt("Unlock1"));
            Debug.Log(PlayerPrefs.GetInt("Unlock2"));
            Debug.Log(PlayerPrefs.GetInt("Unlock3"));

            UnlockSpell2();
            UnlockSpell1();
            UnlockSpell3();

            for (int x = 1; x <= data.level; x++)
            {
                maxExp += maxExp * 0.25f;
            }
            expBar.maxValue = maxExp;
            PlayerPrefs.SetInt("Spell1", data.plasmaUpgrade);
            PlayerPrefs.SetInt("Spell2", data.fireUpgrade);
            PlayerPrefs.SetInt("Spell3", data.frostUpgrade);
            PlayerPrefs.SetInt("Spell4", data.natureUpgrade);
            PlayerPrefs.SetInt("Wave", data.wave);
            tower.maxHealth = data.towerMaxHealth;
            tower.health = data.towerHealth;
            PlayerPrefs.SetInt("IsWave", 0);
            PlayerPrefs.SetInt("IsLoaded", 0);
            PlayerPrefs.SetInt("Scroll1", data.scroll1);
            PlayerPrefs.SetInt("Scroll2", data.scroll2);
            PlayerPrefs.SetInt("Scroll3", data.scroll3);
            PlayerPrefs.SetInt("Scroll4", data.scroll4);
            PlayerPrefs.SetInt("Scroll5", data.scroll5);
            if (PlayerPrefs.GetInt("Scroll1") == 1 || PlayerPrefs.GetInt("Scroll2") == 1 || PlayerPrefs.GetInt("Scroll3") == 1 || PlayerPrefs.GetInt("Scroll4") == 1 ||
            PlayerPrefs.GetInt("Scroll5") == 1)
            {
                chest.SetActive(false);
                doors.SetActive(false);
            }
            // player.transform.position = new Vector2(data.posX, data.posY);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (p1.GetSkillPoints() > 0)
        {
            infoDot.SetActive(true);
        }
        else if (p1.GetSkillPoints() == 0)
        {
            infoDot.SetActive(false);
        }
        CheckKeys();
        if (PlayerPrefs.GetInt("WavePart") == 7 && isManaReseted == false)
        {
            isManaReseted = true;
            p1.EditMana(p1.GetMaxMana());
        }
        else if (PlayerPrefs.GetInt("WavePart") != 7 && isManaReseted == true)
        {
            isManaReseted = false;
        }
        //if (isSpikes)
        //{
        //    spikesBarObject.SetActive(true);
        //    spikesCounter -= Time.deltaTime * 3;
        //    spikesBar.value = spikesCounter;
        //}
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    temp = new Vector2(transform.position.x, transform.position.y - 2f);
        //     isSpikes = true;
        //    StartCoroutine(WaitSeconds(1));
        //}
        //if (spikesCounter < 0)
        //{
        //    spikesBarObject.SetActive(false);
        //    isSpikes = false;
        //    spikesCounter = 3;
        //}

        manacCounter += Time.deltaTime;
        healthBar.value = p1.GetHealth();
        healthBar.maxValue = p1.GetMaxHealth();
        manaBar.value = p1.GetMana();
        manaBar.maxValue = p1.GetMaxMana();
        expBar.value = p1.GetExp();

        gold.text = Mathf.RoundToInt(p1.GetGold()).ToString();
        level.text = p1.GetLevel().ToString();
        hpPotionsText.text = p1.GetHPPotion().ToString();
        manaPotionsText.text = p1.GetManaPotion().ToString();
        if (Input.GetKeyDown(KeyCode.Equals) && commandConsole.activeSelf == false)
        {

            commandConsole.SetActive(true);
            inputField.Select();


        }
        else if (Input.GetKeyDown(KeyCode.Equals) && commandConsole.activeSelf == true)
        {
            inputField.text = "";
            commandConsole.SetActive(false);
        }
        if (p1.GetHealth() < (100 * 0.3))
        {
            hp.color = new Color32(255, 0, 48, 255);
        }
        else
        {
            hp.color = new Color32(12, 137, 2, 255);
        }
        if (manacCounter > 0.1)
        {
            if (p1.GetMana() < p1.GetMaxMana())
            {
                p1.AddMana(p1.GetManaRegen());
            }
            manacCounter = 0;
        }
        if (p1.GetHealth() <= 0)
        {
            player.transform.position = respawnPoint.position;

            p1.SubstractGold(p1.GetGold() * 0.4f);
            p1.EditHealth(100);
            deathsCounter++;
        }
        if (p1.GetExp() >= maxExp)
        {

            p1.AddLevel(1);
            p1.AddSkillPoints(2);
            p1.AddGold(50);
            p1.EditExp(p1.GetExp() - maxExp);
            maxExp += maxExp * 0.25f;
            expBar.maxValue = maxExp;
            StartCoroutine(WaitToFade(4));
        }

        if (Input.GetKeyDown(KeyCode.E) && p1.GetHPPotion() > 0 && commandConsole.activeSelf == false)
        {
            p1.AddHealth(p1.GetHPPotionPower());
            hpPotionCounter++;
            if (p1.GetHealth() > p1.GetMaxHealth())
            {
                p1.EditHealth(p1.GetMaxHealth());
            }
            p1.SubstractHPPotion();
        }
        if (Input.GetKeyDown(KeyCode.R) && p1.GetManaPotion() > 0 && commandConsole.activeSelf == false)
        {
            manaPotionCounter++;
            p1.AddMana(p1.GetManaPotionPower());
            if (p1.GetMana() > p1.GetMaxMana())
            {
                p1.EditMana(p1.GetMaxMana());
            }
            p1.SubstractManaPotion();
        }

        if (PlayerPrefs.GetInt("AddBook") == 1)
        {
            StartCoroutine(WaitToFadeBooks(3));
            PlayerPrefs.SetInt("AddBook", 0);
        }
        if (Input.GetKeyDown(KeyCode.P) && commandConsole.activeSelf == false)
        {
            saveToDB.SaveDB(playerStats, tower, castingSpells);
            RestatGame();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("CHUJ1");
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("CHUJ2");
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("CHUJ3");
                }
            }
        }

        if (fired)
        {


            firedCounter += Time.deltaTime;

            if (firedCounter >= 1)
            {
                p1.SubstractHealth(5);
                firedCounter = 0;
            }

        }

        if (gameOverPanel.activeSelf && db == false)
        {
            saveToDB.SaveDB(playerStats, tower, castingSpells);
            db = true;
        }
        if (Input.GetKeyDown(KeyCode.Return) && commandConsole.activeSelf == false)
        {
            if (PlayerPrefs.GetInt("Wave") == 40)
            {
                SaveSystem.DeletePlayer();
                RestatGame();
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySpell")
        {
            p1.SubstractHealth(20 - 20 * (p1.GetDefence() / 100));



        }
        if (collision.gameObject.tag == "Spikes")
        {
            p1.SubstractHealth(5);
            fired = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            fired = false;
        }
    }

    IEnumerator WaitSeconds(int x)
    {
        yield return new WaitForSeconds(x);
        GameObject spikesObject = Instantiate(spikes, temp, Quaternion.identity);
    }


    IEnumerator WaitToFade(int x)
    {
        newLvl.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(x);
        newLvl.CrossFadeAlpha(0f, 2f, false);
    }

    IEnumerator WaitToFadeBooks(int x)
    {
        booksInfo.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(x);
        booksInfo.CrossFadeAlpha(0f, 2f, false);
    }

    void CheckKeys()
    {
        if (p1.GetKeys() == 0)
        {
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
        }
        if (p1.GetKeys() == 1)
        {
            key1.SetActive(true);
            key2.SetActive(false);
            key3.SetActive(false);
        }
        else if (p1.GetKeys() == 2)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(false);
        }
        else if (p1.GetKeys() == 3)
        {
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
        }
    }

    public void UnlockSpell1()
    {
        Debug.Log("Unlock frost: " + PlayerPrefs.GetInt("Unlock2"));
        if (PlayerPrefs.GetInt("Unlock2") == 1)
        {
            Debug.Log("size: " + inventory.GetSize());
            switch (inventory.GetSize())
            {
                case 1:
                    frostSpell1.SetActive(true);
                    break;
                case 2:
                    frostSpell2.SetActive(true);
                    break;
                case 3:
                    frostSpell3.SetActive(true);
                    break;
            }
            Debug.Log("DUPA");
            inventory.AddItem(new SpellType("Frost", 10));
        }

    }

    public void UnlockSpell2()
    {
        Debug.Log("Unlock fire: " + PlayerPrefs.GetInt("Unlock1"));
        if (PlayerPrefs.GetInt("Unlock1") == 1)
        {
            Debug.Log("size: " + inventory.GetSize());
            switch (inventory.GetSize())
            {
                case 1:
                    fireSpell1.SetActive(true);
                    break;
                case 2:
                    fireSpell2.SetActive(true);
                    break;
                case 3:
                    fireSpell3.SetActive(true);
                    break;
            }
            inventory.AddItem(new SpellType("Fire", 15));
        }
    }
    public void UnlockSpell3()
    {
        Debug.Log("Unlock nature: " + PlayerPrefs.GetInt("Unlock3"));
        if (PlayerPrefs.GetInt("Unlock3") == 1)
        {
            Debug.Log("size: " + inventory.GetSize());
            switch (inventory.GetSize())
            {
                case 1:
                    natureSpell1.SetActive(true);
                    break;
                case 2:
                    natureSpell2.SetActive(true);
                    break;
                case 3:
                    natureSpell3.SetActive(true);
                    break;
            }
            inventory.AddItem(new SpellType("Nature", 15));
        }
    }

    void OnApplicationQuit()
    {
        saveToDB.SaveDB(playerStats, tower, castingSpells);
    }
    public void RestatGame()
    {

        SceneManager.LoadScene(0);
    }
}

