using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


//this script is legacy as it made more sense to do this in spawnhole
public class InfoboardUpdaterLvl2 : MonoBehaviour
{
    public TextMeshProUGUI XKoord;
    public TextMeshProUGUI YKoord;






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
