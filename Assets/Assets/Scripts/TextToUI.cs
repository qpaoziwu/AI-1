using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextToUI : MonoBehaviour
{
    public string silent = ""; 

    public string g_hungry = "Gollum wants food!";
    public string g_searching = "Shiny!";
    public string g_chasing = "Come back!";
    public string g_catching = "Yummy!";
    public string g_artifact = "My precious!";
    public string g_bargaining = "Give Gollum Food!";
    public string g_satisfied = "Here you go!";

    public string s_checking = "On my way sir";
    public string s_limping = "Mr Frodo, I'm hurt";
    public string s_walking = "Mr Frodo, I'm not hurt anymore";
    public string s_resting = "Mr Frodo, I just need a second";
    public string s_cooking = "Right away Mr Frodo";
    public string s_waiting = "Food is ready Sir!";

    public TextMeshPro text;
    public string displayText;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<TextMeshPro>() != null)
        {
            text = GetComponent<TextMeshPro>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string line)
    {
        text.text = line;
    }

}
