using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadCannon : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool loaded = false;
    ShootCannon SC;
    LevelChanger levelChanger;

    void Start()
    {
       SC = FindObjectOfType<ShootCannon>();
       levelChanger = FindObjectOfType<LevelChanger>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider hitBy)
    {
        if (hitBy.tag == "BallNoTrail")
        {
            if (!loaded)
            {
                loaded = true;
                Destroy(hitBy.gameObject);
                SC.setChamberActive();
                levelChanger.ChangeLampColor(levelChanger.purple, levelChanger.maxBrightness);
            }
        }
    }
}
