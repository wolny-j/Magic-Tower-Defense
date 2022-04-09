using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SaveToDB : MonoBehaviour
{
    float counterTime;
    int token;
    string url = "http://cicadagames.000webhostapp.com/serverAPI.php";
    private void Start()
    {
        token = Random.Range(10000, 99999);
    }
    void Update()
    {
        counterTime += Time.deltaTime;
    }
    public void SaveDB(PlayerStats playerStats, Tower tower, CastingSpells castingSpells)
    {
        PlayerData data = new PlayerData(playerStats, tower, castingSpells);
        StartCoroutine(SaveData(data));
    }

    IEnumerator SaveData(PlayerData data)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", data.name);
        form.AddField("level", (int)data.level);
        form.AddField("wave", data.wave);
        form.AddField("money", (int)data.gold);
        form.AddField("deaths", data.deaths);
        form.AddField("playTime", (int)counterTime);
        form.AddField("sessionToken", token);
        form.AddField("sessionDate", data.date);
        form.AddField("hpPotionCounter", data.hpPotionCounter);
        form.AddField("hpPotionPower", data.hpPotionPower);
        form.AddField("manaPotionCounter", data.manaPotionCounter);
        form.AddField("manaPotionPower", data.manaPotionPower);
        form.AddField("manaPotion", data.manaPotion);
        form.AddField("hpPotion", data.hpPotion);
        form.AddField("keys", data.keys);
        form.AddField("books", data.books);
        form.AddField("s1Counter", data.s1Counter);
        form.AddField("s1Upgrades", data.plasmaUpgrade);
        form.AddField("s2Counter", data.s2Counter);
        form.AddField("s2Upgrades", data.fireUpgrade);
        form.AddField("s3Counter", data.s3Counter);
        form.AddField("s3Upgrades", data.frostUpgrade);
        form.AddField("s4Counter", data.s4Counter);
        form.AddField("s4Upgrades", data.natureUpgrade);
        form.AddField("health", data.maxHp.ToString());
        form.AddField("mana", data.maxMana.ToString());
        form.AddField("manaRegen", (data.manaRegen * 10).ToString());
        form.AddField("attack", data.attack.ToString());
        form.AddField("defence", data.defence.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("Upload correct to: " + url);
                Debug.Log(www.downloadHandler.text);
                PlayerPrefs.SetString("ConnLOG", www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Upload correct to: " + url);
                Debug.Log(www.downloadHandler.text);
                PlayerPrefs.SetString("ConnLOG", www.downloadHandler.text);

            }
        }

    }
}
