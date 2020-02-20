using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HorizontalAngleUpdate : MonoBehaviour
{

    public GameObject HorizontalHandle;
    public TextMeshProUGUI angleNumber;
    private float x;

    ShootCannon ShootCannon;

    public double minInputValue = -1.225;
    public double maxInputValue = 1 - 0.225;

    private static int maxAngle = 60;
    private static int minAngle = -maxAngle;


    // Start is called before the first frame update
    void Start()
    {
        ShootCannon = FindObjectOfType<ShootCannon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateAngle()
    {

        x = HorizontalHandle.transform.parent.transform.position.x /*+ HorizontalHandle.transform.position.x*/;
        Debug.Log("updateangle before conversions" + x);

        if (x < minInputValue)
        {
            Rotations.HorizontalAngle = minAngle -90;
            angleNumber.text = minAngle.ToString();
            ShootCannon.horizontalChange();

        }
        else if (x > maxInputValue)
        {
            Rotations.HorizontalAngle = maxAngle -90;
            angleNumber.text = maxAngle.ToString();
            ShootCannon.horizontalChange();


        }
        else
        {
            int angle = mapToInt(x, minInputValue, maxInputValue, minAngle, maxAngle);
            Rotations.HorizontalAngle = angle - 90;
            angleNumber.text = angle.ToString();
            ShootCannon.horizontalChange();

        }
        Debug.Log("updateangle after conversions" + mapToInt(x, minInputValue, maxInputValue, minAngle, maxAngle));


    }

    private int mapToInt(float input, double a, double b, double c, double d)
    { //a og b er input intervallet og c og d er output intervallet
        double output = c - ((input - a) / (b - a)) * (c - d);
        //double dOutput = (double)output;
        int intOutput = (int)Math.Round(output, 0, MidpointRounding.AwayFromZero);
        return intOutput;

    }
}
