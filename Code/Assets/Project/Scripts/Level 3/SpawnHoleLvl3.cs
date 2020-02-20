using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class SpawnHoleLvl3 : MonoBehaviour
{

    public GameObject hole;
    public string ButtonsTag;
    public static int HoleX;

    public TextMeshProUGUI XKoord;
    public TextMeshProUGUI YKoord;
    public TextMeshProUGUI gravity;

    //InfoboardUpdaterLvl3 InfoUpdater;
    PowerTextUpdate PowerUpdate;
    LevelChanger LevelChanger;

    WorldGravity WorldGravity;

    

    //public GameObject InfoBoard;
    

    // Start is called before the first frame update
    void Start()
    {
        //InfoUpdater = FindObjectOfType(typeof(InfoboardUpdaterLvl3)) as InfoboardUpdaterLvl3;
        //InfoUpdater.UpdateXkoord(0);

        WorldGravity = FindObjectOfType<WorldGravity>();
        PowerUpdate = FindObjectOfType<PowerTextUpdate>();
        LevelChanger = FindObjectOfType<LevelChanger>();

    }



    // Update is called once per frame
    void Update()
    {

        
        
    }

    private float MaxDistance(int power, float g)
    {
        float Distance = power * Mathf.Sin((45 * Mathf.PI) / 180) * (Mathf.Sin((45 * Mathf.PI) / 180) * power + Mathf.Pow(10, -9) * Mathf.Sqrt((float)3.6 * Mathf.Pow(10, 18) * g + (float)4.99999997 * Mathf.Pow(10, 17) * Mathf.Pow(power, 2))) / g;

        return Distance;
    }

    private float generateGravity()
    {
        float g = Random.Range(5, 20);

        if(WorldGravity == null)
        {
            WorldGravity = FindObjectOfType<WorldGravity>();

        }

        WorldGravity.gravity = g;
        return g;
    }

    public void SpawnNew()
    {
        if (PowerUpdate == null)
        {
            PowerUpdate = FindObjectOfType<PowerTextUpdate>();

        }
     


        int NewPower = Random.Range(12, 40);

        ShootCannon.power = NewPower;

        Debug.Log("NewPower: " + NewPower + ", powerUpdate" + PowerUpdate);

        PowerUpdate.UpdatePowerDisplay(NewPower);

        float g = generateGravity();

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
        UpdateInfoBoard(HoleX, HoleY, g);
        Debug.Log(HoleX);
    }

    private int generateY(int x, int maxLength, int maxAngle)
    {
        float b = Mathf.Sqrt(Mathf.Pow(maxLength, 2) - Mathf.Pow(x, 2));

        float bMax = x * Mathf.Tan((maxAngle * Mathf.PI) / 180);

        if (b > bMax)
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


    private void UpdateInfoBoard(int x, int y, float g)
    {
        XKoord.text = x.ToString();
        YKoord.text = y.ToString();
        gravity.text = g.ToString();
    }
}


