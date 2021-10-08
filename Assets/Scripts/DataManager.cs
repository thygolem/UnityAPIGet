using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public Text dataText;
    private string[] espMacs = { "00:00:00:00:00:00","00:00:00:00:00:01","00:00:00:00:00:02"};
    private int[] rssiS = {-55, -57, -59, -60};


    // Start is called before the first frame update
    void Start()
    {
        for(int mac = 0; mac < espMacs.Length; mac++){
            //Debug.Log(espMacs[mac]);
            if(espMacs[mac].Contains("00:00:00:00:00:02")){
                //Debug.Log("dispositivo encontrado");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //dataText.text = "JSON HERE, NOW";
        //Debug.Log("Hay "+ espMacs.Length+" dispositivos");
        int median = rssiS[0] +rssiS[1] + rssiS[2] + rssiS[3]; 
        //Debug.Log(median/4);
    }
}
