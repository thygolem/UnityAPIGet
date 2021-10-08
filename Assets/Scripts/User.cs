//https://www.youtube.com/watch?v=6yDRbnXve_0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class User : MonoBehaviour
{
    
    string path;
    string jsonString;

    void Start()
    {
        //path = Application.streamingAssetsPath + "/Devices.json";
        path = "/home/ubuntu/Escritorio/Simó/INDOOR/Devices.json";
        jsonString = File.ReadAllText(path);
        Device ESP = JsonUtility.FromJson<Device>(jsonString);
        Debug.Log(ESP.id);
        ESP.currentRssi = -25;
        string newESP = JsonUtility.ToJson(ESP);
        Debug.Log(newESP);
    }    
}
    
[System.Serializable]
public class Device
{
    public string id;
    public string iss;
    public string esp_mac;
    public string near_mac;
    public int currentRssi;
    public int[] lastRssiS;
    public string espTime;
    public string building ;
    public string floor;
    public string zone;
    public float lat;
    public float lng;
    public bool task;
}
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*public string id { get; set;}
    public string iss { get; set;}
    public string esp_mac { get; set;}
    public string near_mac { get; set;}
    public int currentRssi { get; set;}
    public string lastRssiS { get; set;}
    public string espTime { get; set;}
    public string building { get; set;}
    public string floor { get; set;}
    public string zone { get; set;}
    public float lat { get; set; }
    public float lng { get; set; }
    public bool task { get; set; }*/



/*
{
  "id": "615b1711945a9d861ca922d2",
  "iss": "4c:11:ae:8b:4c:94, fd:04:ce:a4:90:e6",
  "esp_mac": "4c:11:ae:8b:4c:94",
  "near_mac": "fd:04:ce:a4:90:e6",
  "currentRssi": -93,
  "lastRssiS": [
    -99,
    -99,
    -94,
    -94,
    -10,
    -93
  ],
  "espTime": "b'10-06T12:28:57'",
  "building": "string",
  "floor": "string",
  "zone": "string",
  "lat": 0.0,
  "lng": 0.0,
  "task": true
}


*/