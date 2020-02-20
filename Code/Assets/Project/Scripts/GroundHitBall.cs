using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundHitBall : MonoBehaviour
{
    const float bounciness = 0.5f;
    const int maxBounces = 2;

    int bounceNumber = 0;
    LevelChanger LC;
    int orange;
    int red;
    int offset;
    List<int> calculatedCols = new List<int>();
    List<int> calculatedBris = new List<int>();

    Vector3 prevVelocity;

    Rigidbody Rigidbody;



    // Start is called before the first frame update
    void Start()
    {
        LC = FindObjectOfType<LevelChanger>();

        orange = LC.orange;
        red = LC.red;

        offset = (orange - red) / (maxBounces + 1); // this is dependent on red being 0 as color code, or atleast on the zero side rather than on the 65000 side

        //these are for fill in the arrays so the indexnumbers match with bounceNumber
        calculatedCols.Add(0);
        calculatedBris.Add(0);

        for (int i=1; i<=maxBounces; i++)
        {
            calculatedCols.Add((int)Math.Round((double)orange - i * offset));
            calculatedBris.Add((int)Math.Round((double)(LC.maxBrightness/3) * (maxBounces + 1 - i)));

            Debug.Log("calculatedCols[" + i + "]: " + calculatedCols[i]);
            Debug.Log("calculatedBris[" + i + "]: " + calculatedBris[i]);
        }

        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collisionObject)
    {

        if (collisionObject.CompareTag("Terrain") && bounceNumber < maxBounces )
        {
            bounceNumber++;
            LC.ChangeLampColor(calculatedCols[bounceNumber], calculatedBris[bounceNumber]);
            bounce();
            Debug.Log("floorbounce number: " + bounceNumber);

        }else if (collisionObject.CompareTag("Terrain"))
        {
       
            Debug.Log("floorbounce number: " + (bounceNumber + 1) + "destroying the ball");

            if(ShootCannon.shotsFired < 10)
            {
                LC.LampDelay(LC.red, LC.yellow, 1);

            }
            else
            {
                LC.LampDelay(55000, LC.yellow, 2);
                LC.Failed();
            }
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("ball hit something other than terrain");

        }
     

    }

    void bounce()
    {
        prevVelocity = Rigidbody.velocity;
        Debug.Log(prevVelocity);
        float velx = prevVelocity.x;
        float vely = prevVelocity.y * bounciness * (-1);
        float velz = prevVelocity.z;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (float)0.1, gameObject.transform.position.z);

        Rigidbody.velocity = new Vector3(velx, vely, velz); //maybe x and z should not be multiplied by bouncinesss, but we will try it
        //Rigidbody.velocity = new Vector3( 0* bounciness, 1 * bounciness , 0 * bounciness); //maybe x and z should not be multiplied by bouncinesss, but we will try it

        Debug.Log("velx: " + velx + ", vely: " + vely + ", velz: " + velz+ ", rigidbody velocity: " +  Rigidbody.velocity + ", prevvelocity: " + prevVelocity);

    }
  
}
