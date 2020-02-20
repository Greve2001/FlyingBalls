using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject lever;
    public static double speedValue;


    
    /*
    private InfoboardUpdater sn = InfoBoard.GetComponent<InfoboardUpdater>();
    private sn.updatexKoord(100);*/

    // Start is called before the first frame update

    
    void Update()
    {
        /*
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        

        if (Input.GetMouseButton(0)) {
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(transform.position, fwd, out hit, 5))
                {
                if (hit.transform.tag == "Handle")
                    {
                        Debug.Log("handle is getting changed");
                        
                        lever.transform.position = new Vector3(lever.transform.position.x, hit.point.y, lever.transform.position.z);

                        if(lever.transform.localPosition.y < -0.375){
                            lever.transform.localPosition = new Vector3(lever.transform.localPosition.x, -(float)0.375, lever.transform.localPosition.z);
                        }else if(lever.transform.localPosition.y > 0.075){
                            lever.transform.localPosition = new Vector3(lever.transform.localPosition.x, (float)0.075, lever.transform.localPosition.z);
                        }

                        speedValue = (double)lever.transform.localPosition.y;

                    }else
                    {
                        
                        //Debug.Log("handle is not at all getting changed");
                        //Debug.Log(hit.transform.tag);
                        
                    }
                }
        }
        */
    }


}
