using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    WorldGravity WorldGravity;
    private void Start()
    {
        WorldGravity = FindObjectOfType<WorldGravity>();

    }
    void Update()
    {

        //var s = GetComponent<Rigidbody>().velocity -= new Vector3(0, 9.82f / (1/Time.deltaTime), 0);
        GetComponent<Rigidbody>().velocity -= new Vector3(0, WorldGravity.gravity / (1 / Time.deltaTime), 0);
        //der burde ikke være nogen grund til at give det en variabel hvis ikke man bruger den variabel
    }
}

