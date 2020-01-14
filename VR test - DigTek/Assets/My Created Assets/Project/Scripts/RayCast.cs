using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject ballInHand;

    void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 2))
        {
            //print("There is something in front of the object!");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, fwd, out hit, 2))
                {
                if (hit.transform.tag == "BallNoTrail")
                {
                    if (ballInHand.activeSelf == false)
                    {
                        print("Pick up");
                        Destroy(obj: hit.transform.gameObject);
                        ballInHand.SetActive(true);
                    }

                }

            }
        }

    }
}
