using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumber : MonoBehaviour
{
    public int levelNumber;
    public static int sceneLevel;

    // Start is called before the first frame update
    void Start()
    {
        sceneLevel = levelNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
