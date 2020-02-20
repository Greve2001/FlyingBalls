using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class SliderGet : MonoBehaviour {

    public static float PowerSliderValue;

    private int debugCounter;

    void Start () {
        PowerSliderValue = GameObject.Find ("Power Slider").GetComponent <Slider> ().value;
         
    }

    void Update () {
        PowerSliderValue = GameObject.Find ("Power Slider").GetComponent <Slider> ().value;
        
        if(debugCounter == 80){
            Debug.Log(PowerSliderValue);
            debugCounter =0;
        }
        debugCounter++;

    }



}

