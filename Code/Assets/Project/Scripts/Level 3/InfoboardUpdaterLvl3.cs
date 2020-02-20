using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InfoboardUpdaterLvl3 : MonoBehaviour
{
    public TextMeshProUGUI XKoord;
    public TextMeshProUGUI YKoord;
    public TextMeshProUGUI HulStørrelse;
    public TextMeshProUGUI Tyngde;
    public TextMeshProUGUI Vind;
    public TextMeshProUGUI Skråning;

    public GameObject yContainer;
    public GameObject HulStørrelseContainer;
    public GameObject TyngdeContainer;
    public GameObject VindContainer;
    public GameObject SkråningContainer;


    // Start is called before the first frame update
    void Start()
    {
        yContainer.SetActive(false);
        HulStørrelseContainer.SetActive(false);
        TyngdeContainer.SetActive(false);
        VindContainer.SetActive(false);
        SkråningContainer.SetActive(false);

   

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
