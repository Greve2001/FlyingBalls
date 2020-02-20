using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextChanger : MonoBehaviour
 {

    public TextMeshProUGUI Hori; // assign it from inspector
    public TextMeshProUGUI Vert; // assign it from inspector



    private String horizontalText = "Horizontal Angle: " + Rotations.HorizontalAngle;
    private String verticalText = "Vertical Angle: " + Rotations.VerticalAngle;


    void Start()
{

}
    void Update()
    {
        horizontalText = "Horizontal Angle: " + Rotations.HorizontalAngle;
        verticalText = "Vertical Angle: " + (Rotations.VerticalAngle - 270);

        Hori.text = horizontalText;
        Vert.text = verticalText;

    }
}
