using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootCannon : MonoBehaviour {

    public GameObject Ball;
    public GameObject ballChamber;
    public GameObject ballInChamber;
    public GameObject rotationpoint;

    public Slider horizontalSlider;
    public Slider verticalSlider;

    int horizontalAngle = 0;
    int verticalAngle = 0;

    LevelChanger LC;


    public static int power = 20;
    public static int shotsFired = 0;

    // Start is called before the first frame update
    void Start()
    {
        horizontalAngle = Rotations.HorizontalAngle;
        LC = FindObjectOfType<LevelChanger>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Shoot()
    {
        if (loadCannon.loaded)
        {
            //Quaternion rotation = Quaternion.Euler(-verticalAngle, horizontalAngle, 0);
            GameObject ball = Instantiate(Ball, transform.position, Quaternion.identity);
            //ball.transform.Rotate(-verticalAngle, horizontalAngle, 0.0f, Space.Self);
            ball.transform.Rotate(-verticalAngle, horizontalAngle + 90, 0, Space.Self);


            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * power;

            ballInChamber.SetActive(false);
            loadCannon.loaded = false;
            LC.ChangeLampColor(LC.orange, LC.maxBrightness);
            shotsFired++; 
        }
        
    }

    public void horizontalChange()
    {
        //Debug.Log("horisontalchange");
        horizontalAngle = Rotations.HorizontalAngle;
        rotationpoint.transform.rotation = Quaternion.Euler(0, horizontalAngle, verticalAngle);
    }

    public void verticalChange()
    {
        //Debug.Log("verticalchange");
        verticalAngle = Rotations.VerticalAngle;
        rotationpoint.transform.rotation = Quaternion.Euler(0, horizontalAngle, verticalAngle);
    }

    public void setChamberActive() => ballInChamber.SetActive(true);
}
