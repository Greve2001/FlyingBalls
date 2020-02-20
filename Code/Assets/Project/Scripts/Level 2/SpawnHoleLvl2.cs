using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class SpawnHoleLvl2 : MonoBehaviour
{

    public GameObject hole;
    public string ButtonsTag;
    public static int HoleX;

    public TextMeshProUGUI XKoord;
    public TextMeshProUGUI YKoord;

    //InfoboardUpdaterLvl2 InfoUpdater;
    PowerTextUpdate PowerUpdate;
    LevelChanger LevelChanger;

    //public GameObject InfoBoard;
    

    // Start is called before the first frame update
    void Start()
    {
        //InfoUpdater = FindObjectOfType(typeof(InfoboardUpdaterLvl2)) as InfoboardUpdaterLvl2;
        //InfoUpdater.UpdateXkoord(0);

        PowerUpdate = FindObjectOfType<PowerTextUpdate>();
        LevelChanger = FindObjectOfType<LevelChanger>();

    }



    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            Vector3 fwd = GameCameraController.instance.transform.TransformDirection(Vector3.forward);

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
        */
        
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

        int HoleY = generateY(HoleX, maxLength, 60);

        var holes = GameObject.FindGameObjectsWithTag("Hole");

        foreach (GameObject hole in holes)
        {
            Destroy(hole);
            //Instantiate(hole, respawn.transform.position, respawn.transform.rotation);
        }

        Instantiate(hole, new Vector3(HoleY, 0, HoleX), Quaternion.identity);
        //InfoUpdater.UpdateXkoord(HoleX);
        UpdateInfoBoard(HoleX, HoleY);
        Debug.Log(HoleX);
    }

    private int generateY(int x, int maxLength, int maxAngle)
    {
        float b = Mathf.Sqrt( Mathf.Pow(maxLength, 2) - Mathf.Pow(x, 2) );

        float bMax = x * Mathf.Tan((maxAngle * Mathf.PI) / 180);

        if (b> bMax)
        {
            int r = Mathf.FloorToInt(bMax);
            int y = Random.Range(-r, r);
            return y;
        }
        else
        {
            int r = Mathf.FloorToInt(b);
            int y = Random.Range(-r, r);
            return y;
        }

    }


    private void UpdateInfoBoard(int x, int y)
    {
        XKoord.text = x.ToString();
        YKoord.text = y.ToString();
    }
}


