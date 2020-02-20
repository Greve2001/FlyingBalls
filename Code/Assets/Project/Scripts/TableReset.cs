using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableReset : MonoBehaviour
{
    public GameObject Balls;
    public GameObject Table;
    GameObject CurrBalls;

    Vector3 BallPosition;


    // Start is called before the first frame update
    void Start()
    {
        CurrBalls = GameObject.FindGameObjectsWithTag("TableBalls")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshBalls()
    {
        CurrBalls = GameObject.FindGameObjectsWithTag("TableBalls")[0];
        BallPosition = CurrBalls.transform.position;
        Destroy(CurrBalls);

        Instantiate(Balls, Table.transform);
    }
}
