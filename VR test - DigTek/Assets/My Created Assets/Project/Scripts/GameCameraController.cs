using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    public Transform characterBase;
    public float lookSpeed = 10f;
    public static float HorizontalAngle = 0;
    public static float VerticalAngle = 0;


    private float _camRotation;
    private bool lockXAxis = false;
    private bool lockYAxis = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float y = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Mouse X");

        if (lockXAxis == false)
        {
            _camRotation -= y * lookSpeed * Time.deltaTime * 10f;
            _camRotation = Mathf.Clamp(_camRotation, -90f, 90f);
        }
        
        transform.localRotation = Quaternion.Euler(_camRotation , 0f ,0f);

        if (lockYAxis == false)
        {
            characterBase.Rotate(x * lookSpeed * Time.deltaTime * 10f * Vector3.up);
        }

        // Setting angles
        HorizontalAngle = Mathf.Round(360 - transform.eulerAngles.y);
        VerticalAngle = Mathf.Round(360 - transform.eulerAngles.x);

        if (Input.GetMouseButton(0))
            Cursor.lockState = CursorLockMode.Locked;
        
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.Confined;

        // Check for button presses for axis-locking
        if (Input.GetKeyDown(KeyCode.Z))
        {
            lockXAxis = true;
            Debug.Log("Locking X Axis");
        }else if (Input.GetKeyDown(KeyCode.X))
        {
            lockYAxis = true;
            Debug.Log("Locking Y Axis");
        }else if (Input.GetKeyUp(KeyCode.Z))
        {
            lockXAxis = false;
        }else if (Input.GetKeyUp(KeyCode.X))
        {
            lockYAxis = false;
        }
        

    }

}

