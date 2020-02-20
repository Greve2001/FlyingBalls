using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InfoboardUpdaterLvl1 : MonoBehaviour
{
    public TextMeshProUGUI XKoord;
    
    //this could potentially be worked completely into spawnhole script


    // Start is called before the first frame update
    void Start()
    {
         

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateXkoord(int value)
    {
        XKoord.text = value.ToString();
    }
}
