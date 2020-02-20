using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class VerticalAngleUpdate : MonoBehaviour
{

    public GameObject VerticalHandle;
    public TextMeshProUGUI angleNumber;
    private float y;

    public double minInputValue = 0.925;
    public double maxInputValue = 1.4;

    ShootCannon ShootCannon;



    private int minAngle = -30;
    private int maxAngle = 90;

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
        y = VerticalHandle.transform.parent.transform.position.y /*+ VerticalHandle.transform.position.y*/;
        if(y < minInputValue)
        {
            Rotations.VerticalAngle = minAngle;
            angleNumber.text = minAngle.ToString();
            ShootCannon.verticalChange();

        }
        else if (y > maxInputValue)
        {
            Rotations.VerticalAngle = maxAngle;
            angleNumber.text = maxAngle.ToString();
            ShootCannon.verticalChange();

        }
        else
        {
            int angle = mapToInt(y, minInputValue, maxInputValue, minAngle, maxAngle);
            Rotations.VerticalAngle = angle;
            angleNumber.text = angle.ToString();
            ShootCannon.verticalChange();

        }

    }

    private int mapToInt(float input, double a, double b, double c, double d)
    { //a og b er input intervallet og c og d er output intervallet
        double output = c - ((input - a) / (b - a)) * (c - d);
        //double dOutput = (double)output;
        int intOutput = (int)Math.Round(output, 0, MidpointRounding.AwayFromZero);
        return intOutput;

    }
}
