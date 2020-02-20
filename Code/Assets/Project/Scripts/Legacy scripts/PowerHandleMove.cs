using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHandleMove : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject HandlePrefab;
    private float PowerValue;
    void Start()
    {
        PowerValue = SliderGet.PowerSliderValue;
        transform.localPosition = new Vector3(transform.localPosition.x, PowerValue, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        PowerValue = SliderGet.PowerSliderValue;
        transform.localPosition = new Vector3(transform.localPosition.x, PowerValue, transform.localPosition.z);
    }
}
