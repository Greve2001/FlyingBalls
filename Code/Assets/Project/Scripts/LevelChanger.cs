using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Net;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

public class LevelChanger : MonoBehaviour
{
    SpawnHoleLvl1 SpawnHole1;
    SpawnHoleLvl2 SpawnHole2;
    SpawnHoleLvl3 SpawnHole3;
    //the above is VERY dirty
    //this is because one of them is known to not exist
    TableReset TableReset;

      
    /*
    public TextMeshProUGUI FaceText;
    public TextMeshProUGUI LevelNumberText;
    public GameObject CompleteCanvas;
    */

    [HideInInspector]
    public TextMeshProUGUI FaceText;
    [HideInInspector]
    public TextMeshProUGUI LevelNumberText;
    [HideInInspector]
    public GameObject CompleteCanvas;

    private GameObject HUD;

    //private static bool created = false;

    public int numberOfLevels;
    public int thisStage;

    int Scene1 = 0;
    int Scene2 = 1;
    int Scene3 = 2;
    int endScene = 3;

    //[Tooltip("the index of level array where the correct levelnumber lives")]
    int Pointer = 0;
    private List<double> Levels = new List<double>() ;

    Boolean HueAvailable = false;


    //these below should be const, but if they are, they cannot be accesed as easily from different scripts
  
    public int red = 0; //also 65535  //this comes from the hue api website //Groundhitball now depends on this number being between zero and orange

    public int yellow = 10922; //this is a guess i came to the number by going to the middle between red and green

    public int orange = 5000; //this is a guess i came to the number by going between red and yellow

    public int purple = 47000; //this has been seen in real life as purple

    public int blue = 43690; //this comes from the hue api website
   
    public int green = 21845; //this comes from the hue api website
   
    public int maxBrightness = 254;

    int lastHue;
    

    private void Awake()
    {

        /*
        // we used this in an attempt to keep the levelchanger between scenes
        //this however proved unsuccesful
        //therefore the solution is now to enter the level number in the inspector
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }
        */
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        TableReset = FindObjectOfType(typeof(TableReset)) as TableReset;

        for (double i=1; i<=numberOfLevels; i++)
        {
            Levels.Add(thisStage + (i/10));
            //Debug.Log(thisStage + (i / 10));
        }

        
        /*
        Levels.Add(1.2);
        Levels.Add(2.1);
        Levels.Add(2.2);
        Levels.Add(3.1);
        Levels.Add(3.2);
        */

        findTextElements();

        SpawnHole1 = FindObjectOfType(typeof(SpawnHoleLvl1)) as SpawnHoleLvl1;
        SpawnHole2 = FindObjectOfType(typeof(SpawnHoleLvl2)) as SpawnHoleLvl2;
        SpawnHole3 = FindObjectOfType(typeof(SpawnHoleLvl3)) as SpawnHoleLvl3;

        SpawnHole();

    }

    // Update is called once per frame
    void Update()
    {
        //testHue(purple);
    }

    public void NewLevel()
    {
        Pointer++;


        if (Pointer >= (numberOfLevels))
        {
            if (thisStage == 1)
            {
                SpawnHole1 = null;
                changeScene(Scene1, Scene2);
                return;

            }
            else if (thisStage == 2)
            {         
                SpawnHole2 = null;
                changeScene(Scene2, Scene3);
                return;
            }
            else if (thisStage == 3)
            {
                SpawnHole3 = null;
                ChangeLampColor(green, maxBrightness);
                changeScene(Scene3, endScene);
                return;
            }
        }


        Debug.Log("NewLevel" + Levels[Pointer]);
        LevelNumberText.text = "level: " + Levels[Pointer].ToString();
        //Debug.Log(Levels);
        //Debug.Log(Levels[Pointer]);


        StartCoroutine(ShowAndHideFaceText(CompleteCanvas, 2.0f)); // 2 seconds // x.0f = x seconds
        FaceText.text = "Level "+ Levels[Pointer-1].ToString() + " complete \n Now you move to " + Levels[Pointer].ToString();



        SpawnHole();
 
    }

    //IEnumerator is necessary to use in the coroutine and to use the waitforseconds funtion
    IEnumerator ShowAndHideFaceText(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

    public void LampDelay(int startHue, int EndHue, float delay)
    {
        StartCoroutine(DelayedLamp(startHue, EndHue, delay));
    }

    IEnumerator DelayedLamp(int StartHue, int EndHue, float delay)
    {
        ChangeLampColor(StartHue, maxBrightness);
        yield return new WaitForSeconds(delay);
        if (lastHue == StartHue) //only change to the end hue if the cannon is not loaded, cause if it is loaded the lamp should be purple
        {
            ChangeLampColor(EndHue, maxBrightness);

        }

    }

    private void SpawnHole()
    {
        TableReset.RefreshBalls();
        if (SpawnHole1)
        {
            //Debug.Log("spawnhole1");
            SpawnHole1.SpawnNew();
            ChangeLampColor(yellow, maxBrightness);


        }
        else if (SpawnHole2)
        {
            //Debug.Log("spawnhole2");
            SpawnHole2.SpawnNew();
            StartCoroutine(DelayedLamp(blue, yellow, 2));

        }
        else if (SpawnHole3)
        {
            //Debug.Log("spawnhole3");
            SpawnHole3.SpawnNew();
            StartCoroutine(DelayedLamp(blue, yellow, 2));

        }
        else
        {
            Debug.Log("no spawnhole");
        }
    }


    void findTextElements()
    {
        //this should find all of the text elements that change on level completion
        HUD = GameObject.FindWithTag("HUD");
        LevelNumberText = HUD.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        CompleteCanvas = HUD.transform.GetChild(3).gameObject;
        FaceText = CompleteCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        LevelNumberText.text = "level: " + Levels[Pointer].ToString();

        /*
        Debug.Log("facetext");
        Debug.Log(FaceText);
        Debug.Log("completecanvas");
        Debug.Log(CompleteCanvas);
        Debug.Log("levelnumbertext");
        Debug.Log(LevelNumberText);
        */
    }

    /*
    public void publicLamp(String color)
    {
        if (color == "red")
        {
            ChangeLampColor(red);
        }
        else if (color == "yellow")
        {
            ChangeLampColor(yellow);

        }
        else if (color == "purple")
        {
            ChangeLampColor(purple);

        }
        else if (color == "orange")
        {
            ChangeLampColor(orange);

        }
        else if (color == "blue")
        {
            ChangeLampColor(blue);

        }
        else if (color == "green")
        {
            ChangeLampColor(green);

        }
    }
    */
    public void ChangeLampColor(int hue, int bri)
    {
        String hueIP = "192.168.0.102"; //the ip of the school bridge
        //String hueIP = "192.168.0.194"; // the ip of Thors bridge

        String hueUsername = "rLGZCRauv9Beqxx60ItdtkkoG5-20G4r4PbqmR7P"; //have not been tested in this application, but works in another case, also for school
        //String hueUsername = "tTUKSWhyNHeEYbZTIjAmBLYICpSVsaiDpKlpXF1s"; //this is the username for use at Thors home, please do not delete

        String lightNumber = "17"; //the lightnumber for a colored lamp at school
        //String lightNumber = "2"; //lightnumber of one of my lamps

        String address = "http://" + hueIP + "/api/" + hueUsername + "/lights/" + lightNumber + "/state/"; //for use in the final project
        //String address = "http://" + hueIP + "/api/"; //for getting a new username


        //String message = "{ \"bri\": 200, \"on\": true, \"transitiontime\": 0}"; //this string works 100% as input to hue from an arduino


        String message = "{ \"hue\":" + hue.ToString() + ", \"bri\":" + bri.ToString() + ", \"sat\":254, \"transitiontime\": 1}"; //this is the one to use in the final edition


        byte[] data = Encoding.ASCII.GetBytes(message);

        if (HueAvailable)
        {
            WebClient client = new WebClient();
            byte[] response = client.UploadData(address, "PUT", data); //for use in final edition
          //byte[] response = client.UploadData(address, "GET", data); //for use in setup and getting passwwords from hue

            Debug.Log("response from hue: " + Encoding.ASCII.GetString(response));
            lastHue = hue;

        }
        else
        {

            Debug.Log("testmode, lamp went to hue: " + hue + " and brightness: " + bri);
        }

    }

    void testHue(int hue)
    {
        //if t is pressed we send a http request to philips hue
        if (Input.GetKeyDown("t"))
        {
            ChangeLampColor(hue, maxBrightness);
        }

    }


    public void Failed()
    {
        changeScene(0, thisStage - 1);
    }

    void changeScene(int sceneToUnload, int sceneToLoad)
    {
        Debug.Log("ChangeScene");
        SceneManager.LoadSceneAsync(sceneToLoad);
        SceneManager.UnloadSceneAsync(sceneToUnload);

        /*
         // the below is necessary if levelchanger is not destroyed on load
        findTextElements();

        TableReset = FindObjectOfType(typeof(TableReset)) as TableReset;

        SpawnHole2 = FindObjectOfType(typeof(SpawnHoleLvl2)) as SpawnHoleLvl2;

        Debug.Log(SpawnHole2);

        SpawnHole3 = FindObjectOfType(typeof(SpawnHoleLvl3)) as SpawnHoleLvl3;

        SpawnHole();
        */

    }
    

    
}
