using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    void Update()
    {
        var s = GetComponent<Rigidbody>().velocity -= new Vector3(0, 9.82f / (1/Time.deltaTime), 0);
    }
}

