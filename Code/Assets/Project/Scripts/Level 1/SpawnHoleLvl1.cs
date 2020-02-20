using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class SpawnHoleLvl1 : MonoBehaviour
{

    public GameObject hole;
    public string ButtonsTag;
    public static int HoleX;

    public TextMeshProUGUI XKoord;

    //InfoboardUpdaterLvl1 InfoUpdater;
    PowerTextUpdate PowerUpdate;
    LevelChanger LevelChanger;

    //public GameObject InfoBoard;
    

    // Start is called before the first frame update
    void Start()
    {
        //InfoUpdater = FindObjectOfType(typeof(InfoboardUpdaterLvl1)) as InfoboardUpdaterLvl1;
        //InfoUpdater.UpdateXkoord(0);

      
        PowerUpdate = FindObjectOfType<PowerTextUpdate>();
        LevelChanger = FindObjectOfType<LevelChanger>();

    }



    // Update is called once per frame
    void Update()
    {


        //spawnNewRaycast();
    }


    private void spawnNewRaycast(){
        
        RaycastHit hit;

        Vector3 fwd = GameCameraController.instance.transform.TransformDirection(Vector3.forward);
        

        if (Input.GetMouseButtonDown(0)) {
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(GameCameraController.instance.transform.position, fwd, out hit, 5))
                {
                if (hit.transform.CompareTag(ButtonsTag))
                    {
                        Debug.Log("button is getting pressed");

                    //SpawnNew();
                    LevelChanger.NewLevel();


                    }else{
                        Debug.Log(hit.transform.name);
                    }
                }
        }
    }

    private float MaxDistance(int power, float g)
    {
        float Distance = power * Mathf.Sin((45 * Mathf.PI) / 180) * (Mathf.Sin((45 * Mathf.PI) / 180) * power + Mathf.Pow(10, -9) * Mathf.Sqrt((float)3.6 * Mathf.Pow(10, 18) * g + (float)4.99999997 * Mathf.Pow(10, 17) * Mathf.Pow(power, 2))) / g;

        return Distance;
    }

    public void SpawnNew()
    {
        int NewPower = Random.Range(12, 40);

        ShootCannon.power = NewPower;

        PowerUpdate.UpdatePowerDisplay(NewPower);

        int maxLength = (int)MaxDistance(NewPower, (float)9.82);

        HoleX = Random.Range(15, maxLength);

        var holes = GameObject.FindGameObjectsWithTag("Hole");

        foreach (GameObject hole in holes)
        {
            Destroy(hole);
            //Instantiate(hole, respawn.transform.position, respawn.transform.rotation);
        }

        Instantiate(hole, new Vector3(0, 0, HoleX), Quaternion.identity);
        //InfoUpdater.UpdateXkoord(HoleX);  //used to be a separate script which only did the line below
        XKoord.text = HoleX.ToString();
        Debug.Log("HoleX: " + HoleX);
    }
}


