using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    public InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nameInput.text.Length > 15)
        {
            nameInput.text = Truncate(nameInput.text, 15);
        }
        PlayerPrefs.SetString("Username", nameInput.text);
    }
    string Truncate(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}
