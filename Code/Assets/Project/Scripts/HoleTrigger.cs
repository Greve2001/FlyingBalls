using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoleTrigger : MonoBehaviour
{
    public static bool hit = false;

    LevelChanger LevelChange;

    // Start is called before the first frame update
    void Start()
    {
        LevelChange = FindObjectOfType<LevelChanger>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider hitBy)
    {
        Destroy(hitBy.gameObject);
        hit = true;
        Debug.Log("hit");
        //LevelChange.ChangeLampColor(LevelChange.green, LevelChange.maxBrightness); //the logic behind this line is that the hole sends a message to turn the lamp green but levelchanger should make it blue immediatedly after. 
        //this is a bandaid fix, to make the lamp green in the end screen and relies heavily on fast communication to hue 
        //this should be fixed in levelchanger now
        LevelChange.NewLevel();



    }
}
