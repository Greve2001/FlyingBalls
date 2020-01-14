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



    private String horizontalText = "Horizontal Angle: " + GameCameraController.HorizontalAngle;
    private String verticalText = "Vertical Angle: " + GameCameraController.VerticalAngle;


    void Start()
{

}
    void Update()
    {
        horizontalText = "Horizontal Angle: " + GameCameraController.HorizontalAngle;
        verticalText = "Vertical Angle: " + GameCameraController.VerticalAngle;

        Hori.text = horizontalText;
        Vert.text = verticalText;

    }
}
