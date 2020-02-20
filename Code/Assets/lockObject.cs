using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockObject : MonoBehaviour
{
    public GameObject cannonPosition;
    private Vector3 cannonPos;

    // Start is called before the first frame update
    void Start()
    {
        cannonPos = cannonPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cannonPos;
    }
}
