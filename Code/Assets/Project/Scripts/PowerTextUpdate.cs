using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PowerTextUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    // public TextMeshProUGUI text;

    public TextMeshProUGUI TextPro;
    public GameObject lever;
    public static int mappedPowerValue;


    /*
    void Start()
    {
        mappedPowerValue = mapToInt(LeverScript.speedValue, -0.375, 0.075, 0, 100);  
        TextPro.text = mappedPowerValue.ToString();
    }*/

    // Update is called once per frame
    void Update()
    {
        //mappedPowerValue = mapToInt(LeverScript.speedValue, -0.375, 0.075, 0, 100);  
        //TextPro.text = mappedPowerValue.ToString();



    }


    public void UpdatePowerDisplay(int powerLevel)
    {
        TextPro.text = powerLevel.ToString();

        double mapInput = powerLevel; 

        float leverY = (float)mapToDouble(mapInput, 5, 40, -0.375, 0.075);

        lever.transform.localPosition = new Vector3(lever.transform.localPosition.x, leverY, lever.transform.localPosition.z);

    }

//hjemmebrygget map funktion
    private int mapToInt(double input, double a, double b, double c, double d){ //a og b er input intervallet og c og d er output intervallet
        double output = c - ( (input - a) / (b-a)) * (c-d);
        //double dOutput = (double)output;
        int intOutput = (int)Math.Round(output, 0, MidpointRounding.AwayFromZero);
        return intOutput;

    }

    private double mapToDouble(double input, double a, double b, double c, double d)
    {
        double output = c - ((input - a) / (b - a)) * (c - d);
        return output;
    }
}
