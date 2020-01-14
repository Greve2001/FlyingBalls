using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject lever;

    // Start is called before the first frame update
    void Update()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Input.GetMouseButton(0)) {

            if (Physics.Raycast(transform.position, fwd, out hit, 5))
                {
                if (hit.transform.tag == "Lever")
                    {
                        lever.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y - 0.01f, hit.transform.position.z);
                    }
                }
        }
    }
}
